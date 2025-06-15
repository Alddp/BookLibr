using BookBLL;
using BookModels;
using BookModels.Constants;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookLiber.SubForm {

    public partial class ReturnForm : MaterialForm {

        public ReturnForm() {
            InitializeComponent();
        }

        //private void query_button_Click(object sender, System.EventArgs e) {
        //    textBox1.Text = Reader.Instance.UserId;
        //    textBox2.Text = Reader.Instance.UserName;

        // // 准备表格 BorrowView.Columns.Clear();

        // if (!BorrowView.Columns.Contains("Select")) { var checkBoxColumn = new
        // DataGridViewCheckBoxColumn { Name = "Select", HeaderText = "选择", Width = 50 };
        // BorrowView.Columns.Insert(0, checkBoxColumn); }

        // var res = BookManager.QueryBorrowRecord(Reader.Instance.UserId); if (!res.Success) {
        // MessageBox.Show(res.Message); return; }

        //    BorrowView.DataSource = res.Data;
        //}
        private void return_button_Click(object sender, System.EventArgs e) {
            var selectedBooks = new List<string>(); // 存储选中的图书ID

            foreach (DataGridViewRow row in BorrowView.Rows) {
                if (row.Cells["Select"].Value == null)
                    continue;

                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected) {
                    string bookId = row.Cells[BorrowTableFields.BookId].Value.ToString(); // 或其他主键字段
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

            // 刷新表格==============================================================
            BorrowView.Columns.Clear();
            var res = BookManager.QueryBorrowRecord(Reader.Instance.UserId);
            if (!res.Success) {
                MessageBox.Show(res.Message);
                return;
            }

            BorrowView.DataSource = res.Data;
        }
    }
}