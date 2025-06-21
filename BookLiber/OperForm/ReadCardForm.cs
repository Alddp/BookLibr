using BookBLL;
using BookModels;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace BookLiber.OperForm {

    public partial class ReadCardForm : MaterialForm {

        public ReadCardForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);
        }

        private void read_button_Click(object sender, System.EventArgs e) {
            ////测试代码
            string cardNum = "2025062117152256016";

            // TODO:测试
            //获取卡号
            //var cardNumRes = CardManager.ReadCardNum();
            //if (!cardNumRes.Success) {
            //    MessageBox.Show(cardNumRes.Message);
            //    return;
            //}
            //string cardNum = cardNumRes.Data;

            // 根据卡号查询用户信息
            var sutInfoRes = ReaderManager.GetStuInfo(cardNum);

            if (!sutInfoRes.Success) {
                MessageBox.Show("查询失败：" + sutInfoRes.Message);
                return;
            }
            if (sutInfoRes.Data.IsValid == false) {
                MessageBox.Show("此卡已注销");
                return;
            }
            Reader.Instance = sutInfoRes.Data;
            // 显示用户信息
            cardNum_tbx.Text = Reader.Instance.CardNum;
            readerName_tbx.Text = Reader.Instance.UserName;
            stuID_tbx.Text = Reader.Instance.StudentId;
            phone_tbx.Text = Reader.Instance.Phone;
            class_tbx.Text = Reader.Instance.ClassName;
            pictureBox1.ImageLocation = Reader.Instance.Photo;
            startTime_tbx.Text = Reader.Instance.StartTime.ToString();
            endTime_tbx.Text = Reader.Instance.EndTime.ToString();
        }
    }
}