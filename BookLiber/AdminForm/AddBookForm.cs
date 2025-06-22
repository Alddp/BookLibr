using BookBLL;
using BookLiber.SheredForm;
using BookModels;
using BookModels.Constants;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BookLiber.AdminForm {

    public partial class AddBookForm : MaterialForm {
        private BindingList<Book> bookList = new BindingList<Book>();
        private string _imagePath = "";
        private int? _selectedSlotId;
        private Dictionary<int, string> _slotIdToCode = new Dictionary<int, string>();

        public AddBookForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);
        }

        private void AddBookForm_Load(object sender, EventArgs e) {
            dataGridView1.DataSource = bookList;
            // 自动生成列后，移除不需要的列，并设置中文表头
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[BookTableFields.BookId].Visible = false;
            dataGridView1.Columns["PopulerPercent"].Visible = false;
            dataGridView1.Columns[BookTableFields.BookName].HeaderText = "书名";
            dataGridView1.Columns[BookTableFields.Author].HeaderText = "作者";
            dataGridView1.Columns[BookTableFields.ISBN].HeaderText = "ISBN";
            dataGridView1.Columns[BookTableFields.Price].HeaderText = "价格";
            dataGridView1.Columns[BookTableFields.Inventory].HeaderText = "库存";
            dataGridView1.Columns[BookTableFields.Picture].HeaderText = "图片路径";
            dataGridView1.Columns[BookTableFields.SlotId].HeaderText = "书架位置";

            LoadSlotCodeMap();
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        }

        private void LoadSlotCodeMap() {
            _slotIdToCode.Clear();
            var allSlotsResult = BookShelfSlotManager.GetAllSlots();
            if (allSlotsResult.Success && allSlotsResult.Data != null) {
                foreach (var slot in allSlotsResult.Data) {
                    _slotIdToCode[slot.SlotId] = slot.SlotCode;
                }
            }
        }

        private void ClearInputFields() {
            bookName_tbx.Clear();
            author_tbx.Clear();
            ISBN_tbx.Clear();
            price_tbx.Clear();
            inventory_tbx.Clear();
            materialButton1.Text = "设置书架位置";
            pictureBox1.Image = null;
            _imagePath = null;
            _selectedSlotId = null;
            bookName_tbx.Focus();
        }

        private void button1_Click(object sender, EventArgs e) {
            DataToolsForm dataToolsForm = new DataToolsForm();
            dataToolsForm.ShowDialog();
        }

        private void confim_button_Click(object sender, EventArgs e) {
            if (bookList.Count == 0) {
                MessageBox.Show("没有需要入库的图书。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int successCount = 0;
            var failedBooks = new System.Text.StringBuilder();

            foreach (var item in bookList) {
                var result = BookManager.InsertBook(item);
                if (result.Success) {
                    successCount++;
                } else {
                    failedBooks.AppendLine($" -《{item.BookName}》: {result.Message}");
                }
            }

            var summary = new System.Text.StringBuilder();
            summary.AppendLine($"入库操作完成。");
            summary.AppendLine($"成功: {successCount} 本");
            summary.AppendLine($"失败: {bookList.Count - successCount} 本");

            if (failedBooks.Length > 0) {
                summary.AppendLine("\n失败详情:");
                summary.Append(failedBooks.ToString());
            }

            MessageBox.Show(summary.ToString(), "入库结果");
            bookList.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(bookName_tbx.Text) ||
                string.IsNullOrWhiteSpace(author_tbx.Text) ||
                string.IsNullOrWhiteSpace(ISBN_tbx.Text) ||
                string.IsNullOrWhiteSpace(price_tbx.Text) ||
                string.IsNullOrWhiteSpace(inventory_tbx.Text)) {
                MessageBox.Show("请填写所有必填项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!decimal.TryParse(price_tbx.Text, out _)) {
                MessageBox.Show("价格格式不正确。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(inventory_tbx.Text, out _)) {
                MessageBox.Show("库存格式不正确，请输入整数。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string finalImagePath = _imagePath;
            // 检查图片是否存在于BookPicture目录
            if (!string.IsNullOrEmpty(_imagePath)) {
                string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _imagePath);
                if (!File.Exists(absolutePath)) {
                    MessageBox.Show("图片未正确保存，请重新选择图片。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            Book book = new Book() {
                BookName = bookName_tbx.Text,
                Author = author_tbx.Text,
                ISBN = ISBN_tbx.Text,
                Picture = finalImagePath, // 使用BookPicture/xxx.jpg相对路径
                Price = price_tbx.Text,
                Inventory = inventory_tbx.Text,
                SlotId = _selectedSlotId ?? 0,
            };

            bookList.Add(book);

            ClearInputFields();
        }

        private void btnSelectImage_Click(object sender, EventArgs e) {
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Title = "选择图书图片";
                openFileDialog.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp|所有文件|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    try {
                        // 需要ISBN号来命名图片
                        string isbn = ISBN_tbx.Text.Trim();
                        if (string.IsNullOrEmpty(isbn)) {
                            MessageBox.Show("请先填写ISBN号再选择图片。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string bookPictureDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BookPicture");
                        if (!Directory.Exists(bookPictureDir)) {
                            Directory.CreateDirectory(bookPictureDir);
                        }
                        string ext = Path.GetExtension(openFileDialog.FileName);
                        string fileName = isbn + ext;
                        string destPath = Path.Combine(bookPictureDir, fileName);
                        File.Copy(openFileDialog.FileName, destPath, true);
                        _imagePath = $"/BookPicture/{fileName}"; // 相对路径
                        pictureBox1.Image = Image.FromFile(destPath);
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"图片加载或复制失败: {ex.Message}");
                        _imagePath = null;
                        pictureBox1.Image = null;
                    }
                }
            }
        }

        private void btnSelectLocation_Click(object sender, EventArgs e) {
            using (var shelfForm = new ShelfForm(true)) {
                if (shelfForm.ShowDialog() == DialogResult.OK) {
                    if (shelfForm.SelectedSlot != null) {
                        _selectedSlotId = shelfForm.SelectedSlot.SlotId;
                        materialButton1.Text = "已选择：" + shelfForm.SelectedSlot.SlotCode;
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            if (dataGridView1.Columns[e.ColumnIndex].Name == BookTableFields.SlotId && e.Value != null) {
                if (int.TryParse(e.Value.ToString(), out int slotId) && _slotIdToCode.TryGetValue(slotId, out var code)) {
                    e.Value = code;
                    e.FormattingApplied = true;
                }
            }
        }
    }
}