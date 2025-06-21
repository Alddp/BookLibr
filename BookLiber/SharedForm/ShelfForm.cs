using BookBLL;
using BookModels;
using MaterialSkin.Controls;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BookLiber.SheredForm {

    public partial class ShelfForm : MaterialForm {
        private Book _book;
        private BookShelfSlot _slotInfo;
        private bool isAdmin;
        private MaterialButton selectedButton = null;

        public BookShelfSlot SelectedSlot { get; private set; }

        public ShelfForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);
        }

        public ShelfForm(bool isAdminMode) : this() {
            isAdmin = isAdminMode;
        }

        public ShelfForm(Book book, BookShelfSlot slotInfo) : this() {
            _book = book;
            _slotInfo = slotInfo;
            if (isAdmin == false)
                LoadSlotInfo();
        }

        private void ShelfForm_Load(object sender, EventArgs e) {
            if (isAdmin) {
                AdminLoad();
            } else {
                OperLoad();
            }
        }

        public void AdminLoad() {
            materialComboBox1.Enabled = true;

            materialButton2.Visible = true;
            materialTextBox21.Visible = false;
            materialTextBox22.ReadOnly = true;
            materialTextBox21.ReadOnly = true;

            foreach (var control in tableLayoutPanel2.Controls) {
                if (control is MaterialTextBox2 textBox) {
                    textBox.ReadOnly = false;
                }
            }
            foreach (var control in tableLayoutPanel3.Controls.OfType<MaterialButton>()) {
                control.Click += GridButton_Click;
            }
        }

        public void OperLoad() {
            // Operator mode for viewing a slot
            isAdmin = false;
            materialComboBox1.Enabled = false;
            materialButton2.Visible = false;
            foreach (var control in tableLayoutPanel2.Controls) {
                if (control is MaterialTextBox2 textBox) {
                    textBox.ReadOnly = true;
                }
            }
        }

        private void GridButton_Click(object sender, EventArgs e) {
            if (selectedButton != null) {
                selectedButton.UseAccentColor = false;
            }
            selectedButton = sender as MaterialButton;
            selectedButton.UseAccentColor = true;

            string name = selectedButton.Name;
            materialTextBox22.Text = name.Substring(name.IndexOf('R') + 1, 1);
            materialTextBox23.Text = name.Substring(name.IndexOf('C') + 1, 1);
        }

        private void ConfirmButton_Click(object sender, EventArgs e) {
            try {
                int floor = materialComboBox1.SelectedIndex + 1;
                int row = int.Parse(materialTextBox22.Text);
                int col = int.Parse(materialTextBox23.Text);
                string face = materialComboBox2.SelectedItem.ToString();
                int level = int.Parse(materialComboBox3.SelectedItem.ToString());

                if (floor <= 0) {
                    MessageBox.Show("请选择楼层。");
                    return;
                }
                if (face != "A" && face != "B") {
                    MessageBox.Show("面必须是 'A' 或 'B'。");
                    return;
                }

                string slotCode = $"F{floor:D2}-R{row}-C{col}-{face}-{level:D2}";

                var result = BookShelfSlotManager.GetSlotByCode(slotCode);
                if (result.Success) {
                    SelectedSlot = result.Data;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } else {
                    MessageBox.Show($"未找到指定的书架位置: {slotCode}\n请检查输入或联系管理员添加该位置。");
                }
            }
            catch (FormatException) {
                MessageBox.Show("请确保排、列、层为有效的数字。");
            }
            catch (Exception ex) {
                MessageBox.Show("发生错误: " + ex.Message);
            }
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
                materialComboBox2.SelectedText = _slotInfo.Face;
                materialComboBox3.SelectedIndex = _slotInfo.Level - 1;

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
            foreach (var control in tableLayoutPanel3.Controls.OfType<MaterialButton>()) {
                if (control.Name == buttonName) {
                    control.UseAccentColor = true;
                    control.Text = $"第{_slotInfo.Level}层";
                    break;
                }
            }
        }
    }
}