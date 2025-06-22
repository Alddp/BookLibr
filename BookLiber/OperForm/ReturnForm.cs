using BookBLL;
using BookModels;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookLiber.OperForm {

    public partial class ReturnForm : MaterialForm {

        public ReturnForm() {
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
            cardNum_tbx.Text = Reader.Instance.CardNum;
            userName_tbx.Text = Reader.Instance.UserName;
            pictureBox1.ImageLocation = Reader.Instance.Photo;
        }

        private void InitializeDataGridView() {
            BorrowView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            BorrowView.MultiSelect = true;
            BorrowView.AllowUserToAddRows = false;
            BorrowView.ReadOnly = true;
            BorrowView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ReturnForm_Load(object sender, EventArgs e) {
            // 准备表格
            BorrowView.Columns.Clear();

            // 添加列
            BorrowView.Columns.Add("BorrowId", "借阅ID");
            BorrowView.Columns.Add("BookName", "书名");
            BorrowView.Columns.Add("BookId", "图书ID");
            BorrowView.Columns.Add("UserId", "用户ID");
            BorrowView.Columns.Add("BorrowAdminId", "借书管理员");
            BorrowView.Columns.Add("ReturnAdminId", "还书管理员");
            BorrowView.Columns.Add("BorrowDate", "借书日期");
            BorrowView.Columns.Add("ReturnDate", "还书日期");

            BorrowView.Columns["UserId"].Visible = false;
            BorrowView.Columns["BookId"].Visible = false;

            // 设置列宽
            foreach (DataGridViewColumn column in BorrowView.Columns) {
                if (column.Name != "Select") {
                    column.Width = 100;
                }
            }

            // 加载数据
            LoadBorrowRecords();
        }

        private void LoadBorrowRecords() {
            var res = BookManager.QueryBorrowRecord(Reader.Instance.UserId);
            if (!res.Success) {
                MessageBox.Show(res.Message);
                return;
            }

            BorrowView.Rows.Clear();
            foreach (var record in res.Data) {
                int rowIndex = BorrowView.Rows.Add(
                    record.BorrowId,
                    record.BookName,
                    record.BookId,
                    record.UserId,
                    record.BorrowAdminId,
                    record.ReturnAdminId,
                    record.BorrowDate?.ToString("yyyy-MM-dd HH:mm:ss"),
                    record.ReturnDate?.ToString("yyyy-MM-dd HH:mm:ss")
                );

                if (record.ReturnDate != null) {
                    BorrowView.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                }
            }

            // 更新用户信息
            cardNum_tbx.Text = Reader.Instance.CardNum;
            userName_tbx.Text = Reader.Instance.UserName;
            pictureBox1.ImageLocation = Reader.Instance.Photo;
        }

        private void query_button_Click(object sender, EventArgs e) {
            LoadBorrowRecords();
        }

        private void materialButton1_Click(object sender, EventArgs e) {
            string searchText = search_tbx.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) {
                LoadBorrowRecords();
                return;
            }

            var res = BookManager.QueryBorrowRecord(Reader.Instance.UserId);
            if (!res.Success) {
                MessageBox.Show(res.Message);
                return;
            }

            BorrowView.Rows.Clear();
            foreach (var record in res.Data) {
                if (record.BookName.Contains(searchText)) {
                    int rowIndex = BorrowView.Rows.Add(
                        record.BorrowId,
                        record.BookName,
                        record.BookId,
                        record.UserId,
                        record.BorrowAdminId,
                        record.ReturnAdminId,
                        record.BorrowDate?.ToString("yyyy-MM-dd HH:mm:ss"),
                        record.ReturnDate?.ToString("yyyy-MM-dd HH:mm:ss")
                    );

                    if (record.ReturnDate != null) {
                        BorrowView.Rows[rowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                    }
                }
            }
        }

        private void return_button_Click(object sender, EventArgs e) {
            var selectedBookIds = new List<string>(); // 存储选中的图书ID

            foreach (DataGridViewRow row in BorrowView.SelectedRows) {
                // 检查这本书是否已经归还
                if (row.Cells["ReturnDate"].Value != null && !string.IsNullOrEmpty(row.Cells["ReturnDate"].Value.ToString())) {
                    MessageBox.Show($"图书《{row.Cells["BookName"].Value}》已经归还，无法重复操作。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // 阻止后续操作
                }

                string bookId = row.Cells["BookId"].Value.ToString();
                selectedBookIds.Add(bookId);
            }

            if (selectedBookIds.Count == 0) {
                MessageBox.Show("请至少选择一本图书。");
                return;
            }

            foreach (var item in selectedBookIds) {
                var returnRes = BookManager.ReturnBook(Reader.Instance.UserId, item, Admin.Instance.AdminId);
                if (!returnRes.Success)
                    MessageBox.Show($"还书失败：{returnRes.Message}");
            }

            MessageBox.Show("还书成功！");
            LoadBorrowRecords();
        }
    }
}