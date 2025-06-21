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
        }

        private void ReturnForm_Load(object sender, EventArgs e) {
            // 准备表格
            BorrowView.Columns.Clear();

            // 添加选择列
            var checkBoxColumn = new DataGridViewCheckBoxColumn {
                Name = "Select",
                HeaderText = "选择",
                Width = 50
            };
            BorrowView.Columns.Add(checkBoxColumn);

            // 添加列
            BorrowView.Columns.Add("BorrowId", "借阅ID");
            BorrowView.Columns.Add("BookId", "图书ID");
            BorrowView.Columns.Add("UserId", "用户ID");
            BorrowView.Columns.Add("BorrowAdminId", "借书管理员");
            BorrowView.Columns.Add("ReturnAdminId", "还书管理员");
            BorrowView.Columns.Add("BorrowDate", "借书日期");
            BorrowView.Columns.Add("ReturnDate", "还书日期");

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
                // 只显示未还的图书
                if (record.ReturnDate == null) {
                    BorrowView.Rows.Add(
                        false, // 选择列的默认值
                        record.BorrowId,
                        record.BookId,
                        record.UserId,
                        record.BorrowAdminId,
                        record.ReturnAdminId,
                        record.BorrowDate?.ToString("yyyy-MM-dd HH:mm:ss"),
                        record.ReturnDate?.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }

            // 更新用户信息
            cardNum_lb.Text = Reader.Instance.CardNum;
            userName_lb.Text = Reader.Instance.UserName;
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
                // 只显示未还的图书
                if (record.ReturnDate == null && record.BookId.Contains(searchText)) {
                    BorrowView.Rows.Add(
                        false, // 选择列的默认值
                        record.BorrowId,
                        record.BookId,
                        record.UserId,
                        record.BorrowAdminId,
                        record.ReturnAdminId,
                        record.BorrowDate?.ToString("yyyy-MM-dd HH:mm:ss"),
                        record.ReturnDate?.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
        }

        private void return_button_Click(object sender, EventArgs e) {
            var selectedBooks = new List<string>(); // 存储选中的图书ID

            foreach (DataGridViewRow row in BorrowView.Rows) {
                if (row.Cells["Select"].Value == null)
                    continue;

                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected) {
                    string bookId = row.Cells["BookId"].Value.ToString();
                    selectedBooks.Add(bookId);
                }
            }

            if (selectedBooks.Count == 0) {
                MessageBox.Show("请至少选择一本图书。");
                return;
            }

            foreach (var item in selectedBooks) {
                var returnRes = BookManager.ReturnBook(Reader.Instance.UserId, item, Admin.Instance.AdminId);
                if (!returnRes.Success)
                    MessageBox.Show($"还书失败：{returnRes.Message}");
            }

            MessageBox.Show("还书成功！");
            LoadBorrowRecords();
        }
    }
}