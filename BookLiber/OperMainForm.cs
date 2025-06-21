using BookBLL;
using BookLiber.OperForm;
using BookLiber.SheredForm;
using BookModels;
using MaterialSkin.Controls;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BookLiber {

    public partial class OperMainForm : MaterialForm {
        private Dictionary<string, Form> forms;

        public OperMainForm() {
            InitializeComponent();
            InitializeForms();
            ThemeManager.Initialize(this);
        }

        private void MaterialTabControl1_SelectedIndexChanged(object sender, System.EventArgs e) {
            switch (materialTabControl1.SelectedIndex) {
                case 0: // 卡操作
                    ShowForm("readCard");
                    break;

                case 1: // 借阅操作
                    ShowForm("borrow");
                    break;

                case 2: // 设置
                    ShowForm("settings");
                    break;
            }
        }

        private void InitializeForms() {
            forms = new Dictionary<string, Form> {
                { "readCard", new ReadCardForm() },
                { "card", new CardForm() },
                { "borrow", new BorrowForm() },
                { "return", new ReturnForm() },
                { "shelfSearch", new ShelfForm() },
                { "settings", new SettingForm() }
            };
            foreach (var form in forms.Values) {
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
            }

            cardManage.Controls.Add(forms["readCard"]);
            cardManage.Controls.Add(forms["card"]);
            bookManage.Controls.Add(forms["borrow"]);
            bookManage.Controls.Add(forms["return"]);
            bookManage.Controls.Add(forms["shelfSearch"]);
            settings.Controls.Add(forms["settings"]);

            ShowForm("readCard");
        }

        private void ShowForm(string formName) {
            foreach (var form in forms.Values) {
                form.Hide();
            }
            if (forms.TryGetValue(formName, out var formToShow)) {
                formToShow.Show();
                formToShow.Focus();
                if (formToShow is MaterialForm materialForm) {
                    ThemeManager.Initialize(materialForm);
                }
            }
        }

        private void ReadCardStripButton_Click(object sender, System.EventArgs e) {
            ShowForm("readCard");
        }

        private void CreateCardStripButton_Click(object sender, System.EventArgs e) {
            ShowForm("card");
        }

        private void DistoryCardStripButton_Click(object sender, System.EventArgs e) {
            if (materialTabControl1.SelectedIndex == 0) {
                // 销卡
                var infRes = ReaderManager.GetStuInfo(Reader.Instance.CardNum);
                if (!infRes.Success) {
                    MessageBox.Show("未找到该卡信息!", "提示");
                    return;
                }
                var result = MessageBox.Show($"卡号为{Reader.Instance.CardNum}是否删除?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    var destroyRes = ReaderManager.DestroyCard(Reader.Instance.CardNum);
                    if (destroyRes.Success) {
                        MessageBox.Show("销卡成功!", "提示");
                        Reader.Instance = new Reader(); // 重置用户信息
                        ShowForm("readCard");
                    } else {
                        MessageBox.Show("销卡失败!", "提示");
                    }
                }
            }
        }

        private void BorrowStripButton6_Click(object sender, System.EventArgs e) {
            ShowForm("borrow");
        }

        private void ReturnStripButton_Click(object sender, System.EventArgs e) {
            ShowForm("return");
        }
    }
}