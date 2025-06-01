using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookBLL;
using BookLiber.Forms;
using BookModels.Errors;

namespace BookLiber
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            UserName_tb.Focus();
        }

        private void Login_bt_Click(object sender, EventArgs e)
        {
            var result = UserManager.Login(UserName_tb.Text.ToString(), Pwd_tb.Text.ToString());
            if (!result.Success)
            {
                MessageBox.Show(result.Message);

                return;
            }
                MainForm mainForm = new MainForm();
                Hide();
                mainForm.ShowDialog();
                Show();
            }

        private void Register_bt_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();

            registerForm.ShowDialog();

            if (registerForm.returnName != null && registerForm.returnPwd != null)
            {
                UserName_tb.Text = registerForm.returnName;
                Pwd_tb.Text = registerForm.returnPwd;
            }
        }
    }
}
