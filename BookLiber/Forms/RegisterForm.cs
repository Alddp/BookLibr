using BookBLL;
using BookModels;
using System;
using System.Windows.Forms;

namespace BookLiber.Forms {

    public partial class RegisterForm : Form {
        public string returnName;
        public string returnPwd;

        public RegisterForm() {
            InitializeComponent();
            UserName_tb.Focus();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e) {
            Admin admin = new Admin {
                Username = UserName_tb.Text.Trim(),
                Pwd = Pwd_tb.Text.Trim(),
                Phone = Phone_tb.Text.Trim(),
            };

            if (radioButton1.Checked)
                admin.Type = "operator";
            else admin.Type = "admin";

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