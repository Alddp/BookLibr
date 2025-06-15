using BookBLL;
using BookModels;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BookLiber {

    public partial class RegisterForm : MaterialForm {
        public string returnName;
        public string returnPwd;

        public RegisterForm() {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            UserName_tb.Focus();
        }

        private void button1_Click(object sender, EventArgs e) {
            Admin admin = new Admin {
                UserName = UserName_tb.Text.Trim(),
                Pwd = Pwd_tb.Text.Trim(),
                Phone = Phone_tb.Text.Trim(),
            };

            switch (materialComboBox1.SelectedIndex) {
                case 0:
                    admin.Type = "operator";
                    break;

                case 1:
                    admin.Type = "admin";
                    break;
            }

            var res = AdminManager.UsersInsert(admin);

            if (!res.Success) {
                MessageBox.Show(res.Message);
                return;
            }
            MessageBox.Show("注册成功", "提示");
            returnName = UserName_tb.Text.Trim();
            returnPwd = Pwd_tb.Text.Trim();
            Close();
        }
    }
}