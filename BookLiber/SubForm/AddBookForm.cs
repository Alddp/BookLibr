using BookBLL;
using BookModels;
using BookModels.Errors;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace BookLiber.SubForm {

    public partial class AddBookForm : MaterialForm {
        private BindingList<Book> bookList = new BindingList<Book>();

        public AddBookForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);
        }

        private void add_button_Click(object sender, System.EventArgs e) {
            string bookName = ISBN_tbx.Text.Trim();
            string author = bookName_tbx.Text.Trim();

            if (!int.TryParse(author_tbx.Text, out int Inventory)) {
                MessageBox.Show("库存输入无效，请输入有效的数字");
                return;
            }
            if (!decimal.TryParse(price_tbx.Text, out decimal price)) {
                MessageBox.Show("价格输入无效，请输入有效的数字");
                return;
            }

            string ISBN = inventory_tbx.Text.Trim();
            string shelfId = shelfId_tbx.Text.Trim();
            // TODO: 添加图片控件
            string picture = "test";

            bookList.Add(new Book() {
                BookName = bookName_tbx.Text.Trim(),
                Author = author_tbx.Text.Trim(),
                Inventory = inventory_tbx.Text,
                Price = price_tbx.Text,
                ISBN = ISBN_tbx.Text.Trim(),
                ShelfId = int.Parse(shelfId_tbx.Text.Trim()),
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

        private void button1_Click(object sender, EventArgs e) {
            string filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Filter = "Excel Files|*.xlsx";
                openFileDialog.Title = "选择Excel文件";

                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    filePath = openFileDialog.FileName;
                }
            }
            if (filePath == string.Empty) {
                MessageBox.Show("未选择文件");
                return;
            }
            var result = BookManager.ImportBooksFromExcel(filePath);

            if (result.Success) {
                MessageBox.Show(result.Message, "执行完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}