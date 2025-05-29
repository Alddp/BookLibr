using BookBLL;
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
            string cardNum = carnumtxt.Text.Trim();
            string userName = usernametxt.Text.Trim();
            string studentId = stuIDtxt.Text.Trim();
            string phone = phonetxt.Text.Trim();
            string className = classtxt.Text.Trim();
            // 如果图片不存在则为空字符串, 如果图片存在则为图片路径
            string photoPath = File.Exists($".\\Images\\{cardNum}.jpg") ? $".\\Images\\{cardNum}.jpg" : "";
            DateTime startTime = dateTimePicker1.Value;
            DateTime endTime = dateTimePicker2.Value;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(studentId) || string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(className))
            {
                MessageBox.Show("Username, Student ID, Phone, and Class Name cannot be empty.");
                return;
            }

            switch (StuInfoManager.InsertStuInfo(cardNum, userName, studentId, phone, className, photoPath, startTime, endTime))
            {
                case 1:
                    MessageBox.Show("成功");
                    break;
                case -1:
                    MessageBox.Show("数据库出错");
                    return;
                case -2:
                    MessageBox.Show("卡号已存在");
                    return;
            }
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
