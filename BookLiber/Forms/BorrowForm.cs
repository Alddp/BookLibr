using BookBLL;
using BookModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLiber
{
    public partial class BorrowForm : Form
    {
        public BorrowForm()
        {
            InitializeComponent();
        }

        private void card_button_Click(object sender, EventArgs e)
        {
            //测试代码
            //string cardNum = "2025053118004627";

            //获取卡号
            if (!CardManager.ReadCardNum(out string cardNum, out string errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            // 根据卡号查询用户信息
            UserTable stuInfo = StuInfoManager.GetStuInfo(cardNum, out errorMessage);
            if (stuInfo == null)
            {
                MessageBox.Show("未找到用户信息，请检查卡号是否正确或联系管理员。");
                return;
            }
            // 显示用户信息
            cardNumtxt.Text = stuInfo.CardNum;
            nametxt.Text = stuInfo.UserName;
            stuIDtxt.Text = stuInfo.StudentId;
            phoentxt.Text = stuInfo.Phone;
            classtxt.Text = stuInfo.ClassName;
        }
    }
}
