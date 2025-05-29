using BookBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLiber.Forms
{
    public partial class RegisterForm : Form
    {

        public string returnName;
        public string returnPwd;


        public RegisterForm()
        {
            InitializeComponent();
            UserName_tb.Focus();
            radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = UserName_tb.Text;
            string pwd = Pwd_tb.Text;
            string phone = Phone_tb.Text;
            string type;

            if (radioButton1.Checked)
                type = "operator";
            else type = "admin";

            int state = UserManager.UsersInsert(name, pwd, type, phone);
            if (1 == state)
            {
                MessageBox.Show("注册成功", "提示");
                returnName = UserName_tb.Text.Trim();
                returnPwd = Pwd_tb.Text.Trim();
                Close();
            }
        }
    }
}
