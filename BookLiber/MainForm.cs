using BookBLL;
using BookLiber.SubForm;
using BookModels;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BookLiber;

namespace BookLiber {

    public partial class MainForm : MaterialForm {
        private Dictionary<string, Form> forms;
        private string currentForm = "readCard"; // 记录当前显示的窗体

        public MainForm() {
            InitializeComponent();
            InitializeForms();
            ThemeManager.Initialize(this);
        }

        private void MaterialTabControl1_SelectedIndexChanged
            (object sender, EventArgs e) {
            // 根据当前选中的标签页确定要显示的窗体
            string formToShow = currentForm;
            switch (materialTabControl1.SelectedIndex) {
                case 0: // 卡管理
                    formToShow = "readCard";
                    break;

                case 1: // 借还管理
                    formToShow = "borrow";
                    break;

                case 2: // 图书管理
                    formToShow = "addBook";
                    break;

                case 3: // 设置
                    formToShow = "settings";
                    break;
            }

            // 如果窗体发生变化，则刷新显示
            if (formToShow != currentForm) {
                currentForm = formToShow;
                ShowForm(formToShow);
            }
        }

        private void InitializeForms() {
            // 初始化窗体字典
            forms = new Dictionary<string, Form> {
                { "readCard", new ReadCardForm() },
                { "borrow", new BorrowForm() },
                { "return", new ReturnForm() },
                { "card", new CardForm() },
                { "addBook", new AddBookForm() },
                { "settings", new SettingForm() }
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
            settings.Controls.Add(forms["settings"]);

            // 默认显示读卡窗体
            ShowForm("readCard");
        }

        private void ShowForm(string formName) {
            // 隐藏所有窗体
            foreach (var form in forms.Values) {
                form.Hide();
            }

            // 显示指定的窗体
            if (forms.ContainsKey(formName)) {
                // 重新创建窗体实例以触发 Load 事件
                Form oldForm = forms[formName];
                Form newForm = null;
                Control parent = null;

                // 保存父控件引用
                if (oldForm != null && oldForm.Parent != null) {
                    parent = oldForm.Parent;
                } else {
                    // 根据窗体名称确定父控件
                    switch (formName) {
                        case "readCard":
                        case "card":
                            parent = cardManage;
                            break;

                        case "borrow":
                        case "return":
                            parent = operManage;
                            break;

                        case "addBook":
                            parent = bookManage;
                            break;

                        case "settings":
                            parent = settings;
                            break;
                    }
                }

                // 创建新窗体
                switch (formName) {
                    case "readCard":
                        newForm = new ReadCardForm();
                        break;

                    case "borrow":
                        newForm = new BorrowForm();
                        break;

                    case "return":
                        newForm = new ReturnForm();
                        break;

                    case "card":
                        newForm = new CardForm();
                        break;

                    case "addBook":
                        newForm = new AddBookForm();
                        break;

                    case "settings":
                        newForm = new SettingForm();
                        break;
                }

                if (newForm != null && parent != null) {
                    newForm.TopLevel = false;
                    newForm.FormBorderStyle = FormBorderStyle.None;
                    newForm.Dock = DockStyle.Fill;

                    // 从父控件中移除旧窗体
                    if (oldForm != null && oldForm.Parent != null) {
                        oldForm.Parent.Controls.Remove(oldForm);
                    }

                    // 添加新窗体
                    parent.Controls.Add(newForm);
                    // 更新字典中的窗体引用
                    forms[formName] = newForm;
                    // 初始化主题
                    if (newForm is MaterialForm materialForm) {
                        ThemeManager.Initialize(materialForm);
                    }
                    // 显示新窗体
                    newForm.Show();
                    newForm.Focus();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            materialTabControl1.SelectedIndex = 0;
            toolStrip1.Focus();
        }

        private void HideAllForms() {
            foreach (var form in forms.Values) {
                form.Hide();
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
            var infRes = ReaderManager.GetStuInfo(Reader.Instance.CardNum);
            if (infRes.Success) {
                var result = MessageBox.Show($"卡号为{Reader.Instance.CardNum}是否删除?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) {
                    var destroyRes = ReaderManager.DestroyCard(Reader.Instance.CardNum);
                    if (destroyRes.Success) {
                        MessageBox.Show("销卡成功!", "提示");
                        Reader.Instance = new Reader(); // 重置用户信息
                        HideAllForms();
                        ShowForm("readCard");
                    } else {
                        MessageBox.Show("销卡失败!", "提示");
                    }
                }
            } else {
                MessageBox.Show("未找到该卡信息!", "提示");
            }
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
            ThemeManager.ToggleTheme();
            // 重新显示当前窗体以强制更新主题
            ShowForm(currentForm);
        }
    }
}