using BookBLL;
using System;
using System.Windows.Forms;

namespace BookLiber {

    public partial class BorrowForm : Form {

        public BorrowForm() {
            InitializeComponent();
        }

        private void card_button_Click(object sender, EventArgs e) {
            //测试代码
            string cardNum = "2025060219421564";

            ////获取卡号
            //if (!CardManager.ReadCardNum(out string cardNum, out string errorMessage)) {
            //    MessageBox.Show(errorMessage);
            //    return;
            //}

            // 根据卡号查询用户信息
            var res = ReaderManager.GetStuInfo(cardNum);

            if (!res.Success) {
                MessageBox.Show("查询失败：" + res.Message);
                return;
            }
            var stuInfo = res.Data;
            // 显示用户信息
            cardNumtxt.Text = stuInfo.CardNum;
            nametxt.Text = stuInfo.UserName;
            stuIDtxt.Text = stuInfo.StudentId;
            phoentxt.Text = stuInfo.Phone;
            classtxt.Text = stuInfo.ClassName;
            pictureBox1.ImageLocation = stuInfo.Photo;
        }

        private void borrow_button_Click(object sender, EventArgs e) {
            //var selectedBooks = new List<string>(); // 存储选中的图书ID或ISBN

            //foreach (DataGridViewRow row in dataGridView1.Rows) {
            //    bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
            //    if (isSelected) {
            //        string bookId = row.Cells["ISBN"].Value.ToString(); // 或其他主键字段
            //        selectedBooks.Add(bookId);
            //    }
            //}

            //if (selectedBooks.Count == 0) {
            //    MessageBox.Show("请至少选择一本图书。");
            //    return;
            //}

            //// 传给 BLL 层执行批量借书逻辑
            //var result = BookManager.BorrowBooks(userId, selectedBooks);
            //if (result.IsSuccess) {
            //    MessageBox.Show("借书成功！");
            //} else {
            //    MessageBox.Show($"借书失败：{result.ErrorMessage}");
            //}
        }

        private void search_button_Click(object sender, EventArgs e) {
            string info = textBox1.Text;

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