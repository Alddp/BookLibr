using BookBLL;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BookLiber {

    public partial class LoginForm : MaterialForm {
        private readonly MaterialSkinManager materialSkinManager;

        public LoginForm() {
            InitializeComponent();

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
            MainForm mainForm = new MainForm();
            MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Hide();
            mainForm.ShowDialog();
            Show();
        }

        private void Register_bt_Click(object sender, EventArgs e) {
            RegisterForm registerForm = new RegisterForm();

            registerForm.ShowDialog();

            if (registerForm.returnName != null && registerForm.returnPwd != null) {
                txtUsername.Text = registerForm.returnName;
                txtPassword.Text = registerForm.returnPwd;
            }
        }
    }
}