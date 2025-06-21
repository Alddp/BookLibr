using BookLiber.AdminForm;
using BookLiber.OperForm;
using BookLiber.SheredForm;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookLiber {

    public partial class AdminMainForm : MaterialForm {
        private Dictionary<string, Form> forms;

        public AdminMainForm() {
            InitializeComponent();
            InitializeForms();
            ThemeManager.Initialize(this);
        }

        private void MaterialTabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            switch (materialTabControl1.SelectedIndex) {
                case 0: // 用户操作
                    ShowForm("createOper");
                    break;

                case 1: // 图书操作
                    ShowForm("importBook");
                    break;

                case 2: // 设置
                    ShowForm("settings");
                    break;
            }
        }

        private void InitializeForms() {
            // 初始化所有子功能窗体
            forms = new Dictionary<string, Form> {
                { "createOper", new AddUserForm() }, // 创建操作员
                { "delUser", new DelUserForm() },    // 删除用户
                { "importBook", new AddBookForm() }, // 批量导入书籍
                { "setShelf", new ShelfForm() },    // 设置书架位置
                { "settings", new SettingForm() },  // 主题切换
            };

            foreach (var form in forms.Values) {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
            }

            // 将窗体添加到对应的主TabPage
            cardManage.Controls.Add(forms["createOper"]);
            cardManage.Controls.Add(forms["delUser"]);
            bookManage.Controls.Add(forms["importBook"]);
            bookManage.Controls.Add(forms["setShelf"]);
            settings.Controls.Add(forms["settings"]);

            // 默认显示创建操作员窗体
            ShowForm("createOper");
        }

        private void ShowForm(string formName) {
            // 只隐藏当前TabPage下的所有窗体
            Control parentTab = null;
            if (cardManage.Controls.Contains(forms[formName])) parentTab = cardManage;
            else if (bookManage.Controls.Contains(forms[formName])) parentTab = bookManage;
            else if (settings.Controls.Contains(forms[formName])) parentTab = settings;
            if (parentTab != null) {
                foreach (Control ctrl in parentTab.Controls) {
                    if (ctrl is Form f) f.Hide();
                }
                forms[formName].Show();
                forms[formName].Focus();
                if (forms[formName] is MaterialForm materialForm) {
                    ThemeManager.Initialize(materialForm);
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            materialTabControl1.SelectedIndex = 0;
            toolStrip1.Focus();
        }

        private void CreateOperStripButton_Click(object sender, EventArgs e) {
            ShowForm("createOper");
        }

        private void DelOperStripButton_Click(object sender, EventArgs e) {
            ShowForm("delUser");
        }

        private void ImportBookStripButton_Click(object sender, EventArgs e) {
            ShowForm("importBook");
        }

        private void SetShelfStripButton_Click(object sender, EventArgs e) {
            ShowForm("setShelf");
        }
    }
}