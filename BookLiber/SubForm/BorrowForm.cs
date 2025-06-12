using BookBLL;
using BookModels;
using BookModels.Constants;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookLiber.MainWindow {

    public partial class BorrowForm : Form {

        public BorrowForm() {
            InitializeComponent();
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
            textBox1.Text = Reader.Instance.CardNum;
            textBox2.Text = Reader.Instance.UserName;
            pictureBox1.ImageLocation = Reader.Instance.Photo;
        }

        private void button1_Click(object sender, EventArgs e) {
            var selectedBooks = new List<string>(); // 存储选中的图书ID

            foreach (DataGridViewRow row in dataGridView1.Rows) {
                if (row.Cells["Select"].Value == null)
                    continue;

                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected) {
                    string bookId = row.Cells[BookTableFields.BookId].Value.ToString(); // 或其他主键字段
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
            string info = textBox3.Text;

            var res = BookManager.SearchBook(info);

            if (!res.Success) {
                MessageBox.Show("查询失败：" + res.Message);
                return;
            }

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

            // 自动绑定列
            dataGridView1.DataSource = res.Data;

            //// 设置显示列名（可选）
            //dataGridView1.Columns["ISBN"].HeaderText = "ISBN";
            //dataGridView1.Columns["Title"].HeaderText = "书名";
            //dataGridView1.Columns["Author"].HeaderText = "作者";
            //dataGridView1.Columns["Stock"].HeaderText = "库存";
        }
    }
}