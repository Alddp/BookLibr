using BookBLL;
using BookModels;
using BookModels.Constants;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BookLiber.OperForm {

    public partial class BorrowForm : MaterialForm {
        private List<Book> _searchedBooks;

        public BorrowForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);
            InitializeDataGridView();
            Reader.ReaderInfoUpdated += UpdateReaderInfo; // 订阅事件
        }

        private void UpdateReaderInfo() {
            // 确保在UI线程上更新
            if (InvokeRequired) {
                Invoke(new Action(UpdateReaderInfo));
                return;
            }
            cardNum_lb.Text = Reader.Instance.CardNum;
            userName_lb.Text = Reader.Instance.UserName;
            pictureBox1.ImageLocation = Reader.Instance.Photo;
        }

        private void InitializeDataGridView() {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // 添加列
            dataGridView1.Columns.Add(BookTableFields.BookId, "图书编号");
            dataGridView1.Columns.Add(BookTableFields.BookName, "图书名称");
            dataGridView1.Columns.Add(BookTableFields.Author, "作者");
            dataGridView1.Columns.Add(BookTableFields.ISBN, "ISBN");
            dataGridView1.Columns.Add(BookTableFields.Price, "价格");
            dataGridView1.Columns.Add(BookTableFields.Inventory, "库存");
            dataGridView1.Columns.Add(BookTableFields.SlotId, "书架编号");
        }

        private void button2_Click(object sender, EventArgs e) {
            //测试代码
            string cardNum = "2025053121504189000";

            // TODO:测试
            //获取卡号
            //var cardNumRes = CardManager.ReadCardNum();
            //if (!cardNumRes.Success) {
            //    MessageBox.Show(cardNumRes.Message);
            //    return;
            //}
            //string cardNum = cardNumRes.Data;

            // 根据卡号查询用户信息
            var sutInfoRes = ReaderManager.GetStuInfo(cardNum);

            if (!sutInfoRes.Success) {
                MessageBox.Show("查询失败：" + sutInfoRes.Message);
                return;
            }
            Reader.Instance = sutInfoRes.Data;
            // 因为设置Reader.Instance会触发事件，所以下面的代码可以省略
            // UpdateReaderInfo(); // 直接调用或等待事件触发
        }

        private void button1_Click(object sender, EventArgs e) {
            var selectedBooks = new Dictionary<string, string>(); // bookId -> bookName

            foreach (DataGridViewRow row in dataGridView1.SelectedRows) {
                string bookId = row.Cells[BookTableFields.BookId].Value.ToString();
                string bookName = row.Cells[BookTableFields.BookName].Value.ToString();
                if (!selectedBooks.ContainsKey(bookId)) {
                    selectedBooks.Add(bookId, bookName);
                }
            }

            if (selectedBooks.Count == 0) {
                MessageBox.Show("请至少选择一本图书。");
                return;
            }

            var failedBorrows = new List<string>();
            var successfulBorrows = 0;

            foreach (var book in selectedBooks) {
                var result = BookManager.BorrowBook(Reader.Instance.UserId, book.Key, Admin.Instance.AdminId);
                if (!result.Success) {
                    failedBorrows.Add($"《{book.Value}》: {result.Message}");
                } else {
                    successfulBorrows++;
                }
            }

            if (failedBorrows.Any()) {
                string errorMessage = "以下图书借阅失败：\n" + string.Join("\n", failedBorrows);
                if (successfulBorrows > 0) {
                    errorMessage += $"\n\n另外 {successfulBorrows} 本图书借阅成功。";
                }
                MessageBox.Show(errorMessage, "借阅结果");
            } else {
                MessageBox.Show("所有图书均借阅成功！", "借阅成功");
            }

            // 刷新书籍列表以显示更新的库存
            var res = BookManager.SearchBook(search_tbx.Text);
            if (res.Success) {
                PopulateGrid(res.Data);
            } else {
                PopulateGrid(new List<Book>()); // Clear grid
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            string info = search_tbx.Text;

            var res = BookManager.SearchBook(info);

            if (!res.Success) {
                MessageBox.Show("查询失败：" + res.Message);
                PopulateGrid(new List<Book>()); // Clear grid
                return;
            }
            PopulateGrid(res.Data);
        }

        private void PopulateGrid(List<Book> books) {
            _searchedBooks = books;
            dataGridView1.Rows.Clear();

            if (_searchedBooks == null) return;

            foreach (var book in _searchedBooks) {
                dataGridView1.Rows.Add(
                    book.BookId,
                    book.BookName,
                    book.Author,
                    book.ISBN,
                    book.Price,
                    book.Inventory,
                    book.SlotId
                );
            }
        }

        private void BorrowForm_Load(object sender, EventArgs e) {
            UpdateReaderInfo(); // 初始加载时更新一次
            var hotBooks = BookManager.GetPopulerBooks();

            if (!hotBooks.Success) {
                MessageBox.Show(hotBooks.Message);
                return;
            }
            // 设置视图为Details
            listView1.View = View.Details;
            listView1.Columns.Add("书名", 100);
            listView1.Columns.Add("热度", 100);

            foreach (var book in hotBooks.Data) {
                ListViewItem item = new ListViewItem(book.BookName.ToString());
                item.SubItems.Add(book.PopulerPercent.ToString());
                listView1.Items.Add(item);
            }
        }

        private void listView1_Click(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count > 0) {
                // 获取第一个选中的项目
                ListViewItem selectedItem = listView1.SelectedItems[0];
                search_tbx.Text = selectedItem.Text;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            // 检查是否双击的是有效的行和列
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                // 获取双击的图书信息
                var bookId = dataGridView1.Rows[e.RowIndex].Cells[BookTableFields.BookId].Value?.ToString();
                var shelfId = dataGridView1.Rows[e.RowIndex].Cells[BookTableFields.SlotId].Value?.ToString();

                if (!string.IsNullOrEmpty(bookId) && _searchedBooks != null) {
                    var book = _searchedBooks.FirstOrDefault(b => b.BookId == bookId);
                    if (book == null) {
                        MessageBox.Show("未找到图书信息。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!string.IsNullOrEmpty(shelfId)) {
                        // 根据ShelfId获取书架格子信息
                        if (int.TryParse(shelfId, out int slotId)) {
                            var slotResult = BookShelfSlotManager.GetSlotById(slotId);

                            if (slotResult.Success) {
                                // 创建并显示ShelfForm
                                var shelfForm = new SheredForm.ShelfForm(book, slotResult.Data);
                                shelfForm.ShowDialog();
                            } else {
                                MessageBox.Show($"获取书架位置信息失败：{slotResult.Message}", "提示",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        } else {
                            MessageBox.Show("书架编号格式错误", "提示",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } else {
                        MessageBox.Show("该图书暂无书架位置信息", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        // 在窗体关闭时取消订阅，防止内存泄漏
        private void BorrowForm_FormClosed(object sender, FormClosedEventArgs e) {
            Reader.ReaderInfoUpdated -= UpdateReaderInfo;
        }
    }
}