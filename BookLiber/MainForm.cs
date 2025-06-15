using BookLiber.SubForm;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookLiber {

    public partial class MainForm : MaterialForm {
        private Dictionary<string, Form> forms;
        private Dictionary<int, ToolStrip> toolStrips;

        public MainForm() {
            InitializeComponent();
            InitializeForms();
        }

        private void InitializeForms() {
            // 初始化窗体字典
            forms = new Dictionary<string, Form> {
                { "readCard", new ReadCardForm() },
                { "borrow", new BorrowForm() },
                { "return", new ReturnForm() },
                { "card", new CardForm() },
                { "addBook", new AddBookForm() }
            };

            // 初始化ToolStrip字典
            toolStrips = new Dictionary<int, ToolStrip> {
                { 0, toolStrip1 },
                { 1, toolStrip2 },
                { 2, toolStrip3 }
            };

            // 设置窗体属性
            foreach (var form in forms.Values) {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
            }

            // 将窗体添加到对应的标签页
            cardManage.Controls.Add(forms["readCard"]);
            cardManage.Controls.Add(forms["card"]);
            operManage.Controls.Add(forms["borrow"]);
            operManage.Controls.Add(forms["return"]);
            bookManage.Controls.Add(forms["addBook"]);

            // 默认显示读卡窗体
            ShowForm("readCard");
        }

        private void MainForm_Load(object sender, EventArgs e) {
            materialTabControl1.SelectedIndex = 0;
            toolStrip1.Focus();
        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            HideAllForms();
            switch (materialTabControl1.SelectedIndex) {
                case 0:  // 卡管理标签页
                    ShowForm("readCard");
                    break;
                case 1:  // 借阅管理标签页
                    ShowForm("borrow");
                    break;
                case 2:  // 图书管理标签页
                    ShowForm("addBook");
                    break;
            }
        }

        private void HideAllForms() {
            foreach (var form in forms.Values) {
                form.Hide();
            }
        }

        private void ShowForm(string formKey) {
            if (forms.ContainsKey(formKey)) {
                forms[formKey].Show();
                if (toolStrips.ContainsKey(materialTabControl1.SelectedIndex)) {
                    toolStrips[materialTabControl1.SelectedIndex].Focus();
                }
            }
        }

        private void ReadCardScrip_Click(object sender, EventArgs e) {
            if (materialTabControl1.SelectedIndex == 0) {
                HideAllForms();
                ShowForm("readCard");
            }
        }

        private void WriteCardScip_Click(object sender, EventArgs e) {
            if (materialTabControl1.SelectedIndex == 0) {
                HideAllForms();
                ShowForm("card");
            }
        }

        private void DistoryCardScirp_Click(object sender, EventArgs e) {
        }

        private void toolStripButton4_Click(object sender, EventArgs e) {
            if (materialTabControl1.SelectedIndex == 1) {
                HideAllForms();
                ShowForm("borrow");
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e) {
            if (materialTabControl1.SelectedIndex == 1) {
                HideAllForms();
                ShowForm("return");
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e) {
        }
    }
}
