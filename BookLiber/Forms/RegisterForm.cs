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
            switch (state)
            {
                case 1:
                    MessageBox.Show("注册成功", "提示");
                    returnName = UserName_tb.Text.Trim();
                    returnPwd = Pwd_tb.Text.Trim();
                    Close();
                    break;
                case -1:
                    MessageBox.Show("数据库异常，请稍后再试", "错误");
                    return;
                case -2:
                    MessageBox.Show("用户名已存在，请更换用户名", "错误");
                    return;
                case -3:
                    MessageBox.Show("用户名、密码、用户类型和电话不能为空", "错误");
                    return;
                case 0:
                    MessageBox.Show("注册失败，请稍后再试", "错误");
                    return;
            }
        }
    }
}
