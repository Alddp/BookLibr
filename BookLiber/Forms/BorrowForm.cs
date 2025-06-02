using BookBLL;
using System;
using System.Windows.Forms;

namespace BookLiber {

    public partial class BorrowForm : Form {

        public BorrowForm() {
            InitializeComponent();
        }

        private void card_button_Click(object sender, EventArgs e) {
            //测试代码
            //string cardNum = "2025053118004627";

            //获取卡号
            if (!CardManager.ReadCardNum(out string cardNum, out string errorMessage)) {
                MessageBox.Show(errorMessage);
                return;
            }

            // 根据卡号查询用户信息
            var res = StuInfoManager.GetStuInfo(cardNum);

            if (!res.Success) {
                MessageBox.Show("查询失败：" + res.Message);
            }
            var stuInfo = res.Data;
            // 显示用户信息
            cardNumtxt.Text = stuInfo.CardNum;
            nametxt.Text = stuInfo.UserName;
            stuIDtxt.Text = stuInfo.StudentId;
            phoentxt.Text = stuInfo.Phone;
            classtxt.Text = stuInfo.ClassName;
        }
    }
}