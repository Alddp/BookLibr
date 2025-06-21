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
            // 显示用户信息
            cardNum_lb.Text = Reader.Instance.CardNum;
            userName_lb.Text = Reader.Instance.UserName;
            pictureBox1.ImageLocation = Reader.Instance.Photo;
        }

        private void button1_Click(object sender, EventArgs e) {
            var selectedBooks = new List<string>(); // 存储选中的图书ID

            foreach (DataGridViewRow row in dataGridView1.Rows) {
                if (row.Cells["Select"].Value == null)
                    continue;

                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected) {
                    string bookId = row.Cells[BookTableFields.BookId].Value.ToString();
                    selectedBooks.Add(bookId);
                }
            }

            if (selectedBooks.Count == 0) {
                MessageBox.Show("请至少选择一本图书。");
                return;
            }
            foreach (var item in selectedBooks) {
                var result = BookManager.BorrowBook(Reader.Instance.UserId, item, Admin.Instance.AdminId);
                if (!result.Success)
                    MessageBox.Show($"借书失败：{result.Message}");
            }
            MessageBox.Show("借书成功！");
        }

        private void button4_Click(object sender, EventArgs e) {
            string info = search_tbx.Text;

            var res = BookManager.SearchBook(info);

            if (!res.Success) {
                MessageBox.Show("查询失败：" + res.Message);
                return;
            }

            _searchedBooks = res.Data;

            // 准备表格
            dataGridView1.Columns.Clear();

            if (!dataGridView1.Columns.Contains("Select")) {
                var checkBoxColumn = new DataGridViewCheckBoxColumn {
                    Name = "Select",
                    HeaderText = "选择",
                    Width = 50
                };
                dataGridView1.Columns.Insert(0, checkBoxColumn);
            }

            // 添加列
            dataGridView1.Columns.Add(BookTableFields.BookId, "图书编号");
            dataGridView1.Columns.Add(BookTableFields.BookName, "图书名称");
            dataGridView1.Columns.Add(BookTableFields.Author, "作者");
            dataGridView1.Columns.Add(BookTableFields.ISBN, "ISBN");
            dataGridView1.Columns.Add(BookTableFields.Price, "价格");
            dataGridView1.Columns.Add(BookTableFields.Inventory, "库存");
            dataGridView1.Columns.Add(BookTableFields.ShelfId, "书架编号");

            // 自动调整列宽度
            dataGridView1.AutoResizeColumns();

            // 填充数据
            dataGridView1.Rows.Clear();
            foreach (var book in _searchedBooks) {
                dataGridView1.Rows.Add(
                    false, // Select column
                    book.BookId,
                    book.BookName,
                    book.Author,
                    book.ISBN,
                    book.Price,
                    book.Inventory,
                    book.ShelfId
                );
            }
        }

        private void BorrowForm_Load(object sender, EventArgs e) {
            cardNum_lb.Text = Reader.Instance.CardNum;
            userName_lb.Text = Reader.Instance.UserName;
            pictureBox1.ImageLocation = Reader.Instance.Photo;
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
                var shelfId = dataGridView1.Rows[e.RowIndex].Cells[BookTableFields.ShelfId].Value?.ToString();

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
    }
}