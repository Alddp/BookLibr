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

namespace BookLiber.AdminForm {

    public partial class AddBookForm : MaterialForm {
        private BindingList<Book> bookList = new BindingList<Book>();
        private string _imagePath = "";
        private int? _selectedSlotId;

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
            // 检查是否有临时图片路径，并且ISBN不为空
            if (!string.IsNullOrEmpty(_imagePath) && !File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _imagePath))) {
                string isbn = ISBN_tbx.Text.Trim();
                if (string.IsNullOrEmpty(isbn)) {
                    MessageBox.Show("为图片命名需要ISBN号，请先填写ISBN。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                try {
                    // 确保Images文件夹存在
                    string imagesDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images");
                    if (!Directory.Exists(imagesDir)) {
                        Directory.CreateDirectory(imagesDir);
                    }
                    // 用ISBN号命名图片
                    string fileName = isbn + Path.GetExtension(_imagePath);
                    string destPath = Path.Combine(imagesDir, fileName);

                    File.Copy(_imagePath, destPath, true);
                    finalImagePath = Path.Combine("Images", fileName); // 更新为相对路径
                }
                catch (Exception ex) {
                    MessageBox.Show($"图片处理失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // 阻止添加
                }
            }

            Book book = new Book() {
                BookName = bookName_tbx.Text,
                Author = author_tbx.Text,
                ISBN = ISBN_tbx.Text,
                Picture = finalImagePath, // 使用处理后的最终路径
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
                        // 暂存原始路径，并显示预览图
                        _imagePath = openFileDialog.FileName;
                        pictureBox1.Image = Image.FromFile(_imagePath);
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"图片加载失败: {ex.Message}");
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
    }
}