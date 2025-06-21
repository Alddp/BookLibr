using BookBLL;

using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BookLiber {

    public partial class LoginForm : MaterialForm {

        public LoginForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);
            txtUsername.Focus();
        }

        private void BtnLogin_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text)) {
                MessageBox.Show("请输入用户名和密码", "提示");
                return;
            }
            var result = AdminManager.Login(txtUsername.Text.ToString(), txtPassword.Text.ToString());
            if (!result.Success) {
                MessageBox.Show(result.Message);
                return;
            }

            if (result.Data.Type == "操作员") {
                OperMainForm operMainForm = new OperMainForm();
                MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
                operMainForm.ShowDialog();
                Show();
            } else if (result.Data.Type == "管理员") {
                AdminMainForm adminMainForm = new AdminMainForm();
                MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
                adminMainForm.ShowDialog();
                Show();
            }
        }
    }
}