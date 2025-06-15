using BookLiber.SubForm;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BookLiber {

    public partial class MainForm : MaterialForm {
        private ReadCardForm readCardForm;
        private BorrowForm borrowForm;
        private ReturnForm returnForm;
        private CardForm cardForm;
        private AddBookForm addBookForm;

        public MainForm() {
            InitializeComponent();
            InitializeForms();
        }

        private void InitializeForms() {
            // 初始化所有窗体
            readCardForm = new ReadCardForm();
            borrowForm = new BorrowForm();
            returnForm = new ReturnForm();
            cardForm = new CardForm();
            addBookForm = new AddBookForm();

            // 设置窗体属性
            foreach (var form in new Form[] {
                    readCardForm,
                    borrowForm,
                    returnForm,
                    cardForm,
                    addBookForm }) {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
            }

            // 将窗体添加到对应的标签页
            tabPage1.Controls.Add(readCardForm);
            tabPage2.Controls.Add(borrowForm);
            tabPage3.Controls.Add(returnForm);
            tabPage4.Controls.Add(cardForm);
            tabPage5.Controls.Add(addBookForm);

            // 显示第一个窗体
            readCardForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            materialTabControl1.SelectedIndex = 0;
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            // 隐藏所有窗体
            readCardForm.Hide();
            borrowForm.Hide();
            returnForm.Hide();
            cardForm.Hide();
            addBookForm.Hide();

            // 显示选中的窗体
            switch (materialTabControl1.SelectedIndex) {
                case 0:
                    readCardForm.Show();
                    break;

                case 1:
                    borrowForm.Show();
                    break;

                case 2:
                    returnForm.Show();
                    break;

                case 3:
                    cardForm.Show();
                    break;

                case 4:
                    addBookForm.Show();
                    break;
            }
        }
    }
}