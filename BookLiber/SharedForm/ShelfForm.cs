using BookModels;
using MaterialSkin.Controls;
using System;

namespace BookLiber.SheredForm {

    public partial class ShelfForm : MaterialForm {
        private Book _book;
        private BookShelfSlot _slotInfo;
        private bool isAdmin;

        public ShelfForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);
        }

        private void ShelfForm_Load(object sender, EventArgs e) {
            if (Admin.Instance.Type == "操作员") {
                OperLoad();
            } else if (Admin.Instance.Type == "管理员") {
                AdminLoad();
            }
        }

        public void AdminLoad() {
            isAdmin = false;
        }

        public void OperLoad() {
            isAdmin = true;
            materialComboBox1.Enabled = false;
            materialButton2.Visible = false;
            foreach (var control in tableLayoutPanel2.Controls) {
                if (control is MaterialTextBox2 textBox) {
                    textBox.ReadOnly = true;
                }
            }
        }

        public ShelfForm(Book book, BookShelfSlot slotInfo) : this() {
            _book = book;
            _slotInfo = slotInfo;
            if (isAdmin == false)
                LoadSlotInfo();
        }

        private void LoadSlotInfo() {
            if (_slotInfo != null) {
                // 设置窗体标题
                this.Text = $"书架位置";

                // 填充文本框信息
                materialTextBox21.Text = _slotInfo.SlotCode;
                materialComboBox1.SelectedIndex = _slotInfo.Floor - 1;
                materialTextBox22.Text = _slotInfo.RowNumber.ToString();
                materialTextBox23.Text = _slotInfo.ColumnNumber.ToString();
                materialTextBox24.Text = _slotInfo.Face;
                materialTextBox25.Text = _slotInfo.Level.ToString();

                // 高亮显示对应的书架位置按钮
                HighlightShelfPosition();
            }
            if (_book != null) {
                pictureBox1.ImageLocation = _book.Picture;
            }
        }

        private void HighlightShelfPosition() {
            if (_slotInfo == null) return;

            string buttonName = $"materialButtonR{_slotInfo.RowNumber}C{_slotInfo.ColumnNumber}";

            // 查找并高亮对应的按钮
            foreach (var control in tableLayoutPanel3.Controls) {
                if (control is MaterialButton button) {
                    if (button.Name == buttonName) {
                        button.UseAccentColor = true;
                        button.Text = $"第{_slotInfo.Level}层";
                        break;
                    }
                } else {
                    continue;
                }
            }
        }

        public void SetSlotInfo(BookShelfSlot slotInfo) {
            _slotInfo = slotInfo;
            LoadSlotInfo();
        }
    }
}