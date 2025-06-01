using BookBLL;
using BookModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLiber
{
    public partial class CardForm : Form
    {
        public CardForm()
        {
            InitializeComponent();
        }

        private void CardForm_Load(object sender, EventArgs e)
        {
            carnumtxt.Text = DateTime.Now.ToString("yyyyMMddHHmmssff");
        }

        private void submit_button_Click(object sender, EventArgs e)
        {
            UserTable user = new UserTable
            {
                CardNum = carnumtxt.ToString().Trim(),
                UserName = usernametxt.Text.Trim(),
                StudentId = stuIDtxt.Text.Trim(),
                Phone = phonetxt.Text.Trim(),
                ClassName = classtxt.Text.Trim(),
            };
            // 如果图片不存在则为空字符串, 如果图片存在则为图片路径
            user.Photo = File.Exists($".\\Images\\{user.CardNum}.jpg") ? $".\\Images\\{user.CardNum}.jpg" : "";
            user.StartTime = dateTimePicker1.Value;
            user.EndTime = dateTimePicker2.Value;

            if (string.IsNullOrEmpty(user.UserName) ||
                string.IsNullOrEmpty(user.StudentId) ||
                string.IsNullOrEmpty(user.Phone) ||
                string.IsNullOrEmpty(user.ClassName))
            {
                MessageBox.Show("用户名、学号、电话、班级不能为空");
                return;
            }

            if (0 > StuInfoManager.InsertStuInfo(user, out string errorMessage))
                MessageBox.Show(errorMessage);
        }

        private void picture_button_Click(object sender, EventArgs e)
        {
            //选择图片
            DialogResult r = openFile.ShowDialog();
            if (r == DialogResult.OK)
            {
                //如果文件夹不存在
                if (!Directory.Exists(".\\Images\\"))
                {
                    Directory.CreateDirectory(".\\Images\\");
                }

                pictureBox1.Image = Image.FromFile(openFile.FileName);
                File.Copy(openFile.FileName, ".\\Images\\" + carnumtxt.Text + ".jpg", true);
            }
            else
                return;
        }
    }
}
