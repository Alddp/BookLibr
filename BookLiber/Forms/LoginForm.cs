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
            int state = UserManager.CountByNamePwd(UserName_tb.Text, Pwd_tb.Text);
            if (state == 1)
            {
                MainForm mainForm = new MainForm();
                Hide();
                mainForm.ShowDialog();
                Show();
            }
            else
            {
                MessageBox.Show("账号或密码错误");
            }
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
