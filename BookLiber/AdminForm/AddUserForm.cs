using BookBLL;
using BookModels;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BookLiber.AdminForm {

    public partial class AddUserForm : MaterialForm {

        public AddUserForm() {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            UserName_tb.Focus();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (Pwd_tb.Text.Trim() != ConfirmPwd_tb.Text.Trim()) {
                MessageBox.Show("密码不一致");
                return;
            }
            Admin admin = new Admin {
                UserName = UserName_tb.Text.Trim(),
                Pwd = Pwd_tb.Text.Trim(),
                Phone = Phone_tb.Text.Trim(),
            };

            switch (materialComboBox1.SelectedIndex) {
                case 0:
                    admin.Type = "操作员";
                    break;

                case 1:
                    admin.Type = "管理员";
                    break;
            }

            var res = AdminManager.UsersInsert(admin);

            if (!res.Success) {
                MessageBox.Show(res.Message);
                return;
            }
            MessageBox.Show("注册成功", "提示");
        }
    }
}