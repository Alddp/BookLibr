using BookBLL;
using BookModels;
using BookModels.Errors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BookLiber {

    public partial class AddBookForm : Form {
        private BindingList<Book> bookList = new BindingList<Book>();

        public AddBookForm() {
            InitializeComponent();
        }

        private void add_button_Click(object sender, System.EventArgs e) {
            string bookName = textBox1.Text.Trim();
            string author = textBox2.Text.Trim();

            if (!int.TryParse(textBox3.Text, out int Inventory)) {
                MessageBox.Show("库存输入无效，请输入有效的数字");
                return;
            }
            if (!decimal.TryParse(textBox5.Text, out decimal price)) {
                MessageBox.Show("价格输入无效，请输入有效的数字");
                return;
            }

            string ISBN = textBox4.Text.Trim();
            string shelfId = textBox6.Text.Trim();
            // TODO: 添加图片控件
            string picture = "test";

            bookList.Add(new Book() {
                BookName = textBox1.Text.Trim(),
                Author = textBox2.Text.Trim(),
                Inventory = int.Parse(textBox3.Text),
                Price = decimal.Parse(textBox5.Text),
                ISBN = textBox4.Text.Trim(),
                ShelfId = int.Parse(textBox6.Text.Trim()),
                Picture = "test"
            });
        }

        private void confim_button_Click(object sender, EventArgs e) {
            List<OperationResult<Book>> errorBooks = new List<OperationResult<Book>>();

            foreach (var book in bookList) {
                var res = BookManager.InsertBook(book);
                if (!res.Success) {
                    errorBooks.Add(OperationResult<Book>.Fail(ErrorCode.AdminNotFound));
                    MessageBox.Show(res.Message);
                    continue;
                }
            }
        }

        private void AddBookForm_Load(object sender, EventArgs e) {
            dataGridView1.DataSource = bookList;
        }
    }
}