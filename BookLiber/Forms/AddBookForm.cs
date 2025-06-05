using BookBLL;
using BookModels;
using System;
using System.Windows.Forms;

namespace BookLiber {

    public partial class AddBookForm : Form {

        public AddBookForm() {
            InitializeComponent();
        }

        private void add_button_Click(object sender, System.EventArgs e) {
            string bookName = textBox1.Text.Trim();
            string author = textBox2.Text.Trim();
            int Inventory = Convert.ToInt32(textBox3.Text.Trim());
            string ISBN = textBox4.Text.Trim();
            decimal price = Convert.ToDecimal(textBox5.Text);
            string shelfId = textBox6.Text.Trim();
            string picture = "test";

            var res = BookManager.InsertBook(book: new Book {
                BookName = bookName,
                Author = author,
                ISBN = ISBN,
                Inventory = Inventory,
                Price = price,
                Picture = picture,
                ShelfId = Convert.ToInt32(shelfId)
            });

            if (res.Success) {
                MessageBox.Show("添加成功");
            } else {
                MessageBox.Show(res.Message);
            }
        }
    }
}