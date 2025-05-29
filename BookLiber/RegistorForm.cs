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
    partial class RegistorForm : Form
    {

        public string returnName;
        public string returnPwd;

        public RegistorForm()
        {
            InitializeComponent();

            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = account_tb.Text;
            string pwd = pwd_tb.Text;
            string phone = phone_tb.Text;
            string type;

            if (radioButton1.Checked)
                type = "operator";
            else type = "admin";

            int state = UserManager.UsersInsert(name, pwd, type, phone);
            if (1 == state)
            {
                MessageBox.Show("注册成功", "提示");
                returnName = account_tb.Text;
                returnPwd = pwd_tb.Text;
                Close();
            }
        }
    }
}
