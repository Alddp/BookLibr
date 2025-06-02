using BookBLL;
using BookModels;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BookLiber {

    public partial class CardForm : Form {

        public CardForm() {
            InitializeComponent();
        }

        private void CardForm_Load(object sender, EventArgs e) {
            carnumtxt.Text = DateTime.Now.ToString("yyyyMMddHHmmssff");
        }

        private void submit_button_Click(object sender, EventArgs e) {
            Reader user = new Reader {
                CardNum = carnumtxt.Text.Trim(),
                UserName = usernametxt.Text.Trim(),
                StudentId = stuIDtxt.Text.Trim(),
                Phone = phonetxt.Text.Trim(),
                ClassName = classtxt.Text.Trim(),
            };
            // 如果图片不存在则为空字符串, 如果图片存在则为图片路径
            user.Photo = File.Exists($".\\Images\\{user.CardNum}.jpg") ? $".\\Images\\{user.CardNum}.jpg" : "";
            user.StartTime = dateTimePicker1.Value;
            user.EndTime = dateTimePicker2.Value;

            var res = ReaderManager.InsertStuInfo(user);

            if (!res.Success) {
                MessageBox.Show(res.Message);
                return;
            }
            MessageBox.Show("开卡成功");
        }

        private void picture_button_Click(object sender, EventArgs e) {
            //选择图片
            DialogResult r = openFile.ShowDialog();
            if (r == DialogResult.OK) {
                //如果文件夹不存在
                if (!Directory.Exists(".\\Images\\")) {
                    Directory.CreateDirectory(".\\Images\\");
                }

                pictureBox1.Image = Image.FromFile(openFile.FileName);
                File.Copy(openFile.FileName, ".\\Images\\" + carnumtxt.Text + ".jpg", true);
            } else
                return;
        }
    }
}