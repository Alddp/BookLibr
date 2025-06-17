using BookBLL;
using BookModels;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BookLiber.SubForm {

    public partial class CardForm : MaterialForm {

        public CardForm() {
            InitializeComponent();
        }

        private void CardForm_Load(object sender, EventArgs e) {
            carNum_txb.Text = DateTime.Now.ToString("yyyyMMddHHmmssff");
        }

        private void submit_button_Click(object sender, EventArgs e) {
            Reader user = new Reader {
                CardNum = carNum_txb.Text.Trim(),
                UserName = userName_tbx.Text.Trim(),
                StudentId = stuId_tbx.Text.Trim(),
                Phone = phone_tbx.Text.Trim(),
                ClassName = calssName_tbx.Text.Trim(),
            };
            // 如果图片不存在则为空字符串, 如果图片存在则为图片路径
            user.Photo = File.Exists($".\\Images\\{user.CardNum}.jpg") ? $".\\Images\\{user.CardNum}.jpg" : "";

            //user.StartTime = dateTimePicker1.Value;
            //user.EndTime = dateTimePicker2.Value;
            user.StartTime = datePickerRange1.Value[0];
            user.EndTime = datePickerRange1.Value[1];

            var res = ReaderManager.InsertStuInfo(user);

            if (!res.Success) {
                MessageBox.Show(res.Message);
                return;
            }
            res = CardManager.WriteCardNum(user.CardNum);

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
                File.Copy(openFile.FileName, ".\\Images\\" + carNum_txb.Text + ".jpg", true);
            } else
                return;
        }
    }
}