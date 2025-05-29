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

namespace BookLiber
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int state = UserManager.CountByNamePwd(userName_tb.Text, pwd_tb.Text);
            if (state == 1)
            {
                MessageBox.Show("ok", "ok");
            }
            else
            {
                MessageBox.Show("error", "error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistorForm form1 = new RegistorForm();

            form1.ShowDialog();
            userName_tb.Text = form1.returnName;
            pwd_tb.Text = form1.returnPwd;

        }
    }
}
