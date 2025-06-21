namespace BookLiber.AdminForm {
    partial class AddBookForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnSelectImage = new MaterialSkin.Controls.MaterialButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.ISBN_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.price_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.inventory_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.author_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.bookName_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.AddButton3 = new MaterialSkin.Controls.MaterialButton();
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.confim_button = new MaterialSkin.Controls.MaterialButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSelectImage.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSelectImage.Depth = 0;
            this.btnSelectImage.HighEmphasis = true;
            this.btnSelectImage.Icon = null;
            this.btnSelectImage.Location = new System.Drawing.Point(0, 0);
            this.btnSelectImage.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSelectImage.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSelectImage.Size = new System.Drawing.Size(75, 36);
            this.btnSelectImage.TabIndex = 0;
            this.btnSelectImage.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSelectImage.UseAccentColor = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.81742F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.18258F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 239F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.confim_button, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1007, 619);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.bookName_tbx);
            this.flowLayoutPanel3.Controls.Add(this.author_tbx);
            this.flowLayoutPanel3.Controls.Add(this.ISBN_tbx);
            this.flowLayoutPanel3.Controls.Add(this.price_tbx);
            this.flowLayoutPanel3.Controls.Add(this.inventory_tbx);
            this.flowLayoutPanel3.Controls.Add(this.materialButton1);
            this.flowLayoutPanel3.Controls.Add(this.materialButton2);
            this.flowLayoutPanel3.Controls.Add(this.AddButton3);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(721, 203);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(233, 406);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // ISBN_tbx
            // 
            this.ISBN_tbx.AnimateReadOnly = false;
            this.ISBN_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ISBN_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ISBN_tbx.Depth = 0;
            this.ISBN_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ISBN_tbx.HideSelection = true;
            this.ISBN_tbx.Hint = "图书编号";
            this.ISBN_tbx.LeadingIcon = null;
            this.ISBN_tbx.Location = new System.Drawing.Point(3, 106);
            this.ISBN_tbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ISBN_tbx.MaxLength = 32767;
            this.ISBN_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.ISBN_tbx.Name = "ISBN_tbx";
            this.ISBN_tbx.PasswordChar = '\0';
            this.ISBN_tbx.PrefixSuffixText = null;
            this.ISBN_tbx.ReadOnly = false;
            this.ISBN_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ISBN_tbx.SelectedText = "";
            this.ISBN_tbx.SelectionLength = 0;
            this.ISBN_tbx.SelectionStart = 0;
            this.ISBN_tbx.ShortcutsEnabled = true;
            this.ISBN_tbx.Size = new System.Drawing.Size(229, 48);
            this.ISBN_tbx.TabIndex = 2;
            this.ISBN_tbx.TabStop = false;
            this.ISBN_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ISBN_tbx.TrailingIcon = null;
            this.ISBN_tbx.UseSystemPasswordChar = false;
            // 
            // price_tbx
            // 
            this.price_tbx.AnimateReadOnly = false;
            this.price_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.price_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.price_tbx.Depth = 0;
            this.price_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.price_tbx.HideSelection = true;
            this.price_tbx.Hint = "价格";
            this.price_tbx.LeadingIcon = null;
            this.price_tbx.Location = new System.Drawing.Point(3, 158);
            this.price_tbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.price_tbx.MaxLength = 32767;
            this.price_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.price_tbx.Name = "price_tbx";
            this.price_tbx.PasswordChar = '\0';
            this.price_tbx.PrefixSuffixText = null;
            this.price_tbx.ReadOnly = false;
            this.price_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.price_tbx.SelectedText = "";
            this.price_tbx.SelectionLength = 0;
            this.price_tbx.SelectionStart = 0;
            this.price_tbx.ShortcutsEnabled = true;
            this.price_tbx.Size = new System.Drawing.Size(231, 48);
            this.price_tbx.TabIndex = 3;
            this.price_tbx.TabStop = false;
            this.price_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.price_tbx.TrailingIcon = null;
            this.price_tbx.UseSystemPasswordChar = false;
            // 
            // inventory_tbx
            // 
            this.inventory_tbx.AnimateReadOnly = false;
            this.inventory_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.inventory_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.inventory_tbx.Depth = 0;
            this.inventory_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.inventory_tbx.HideSelection = true;
            this.inventory_tbx.Hint = "数量";
            this.inventory_tbx.LeadingIcon = null;
            this.inventory_tbx.Location = new System.Drawing.Point(3, 210);
            this.inventory_tbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inventory_tbx.MaxLength = 32767;
            this.inventory_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.inventory_tbx.Name = "inventory_tbx";
            this.inventory_tbx.PasswordChar = '\0';
            this.inventory_tbx.PrefixSuffixText = null;
            this.inventory_tbx.ReadOnly = false;
            this.inventory_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.inventory_tbx.SelectedText = "";
            this.inventory_tbx.SelectionLength = 0;
            this.inventory_tbx.SelectionStart = 0;
            this.inventory_tbx.ShortcutsEnabled = true;
            this.inventory_tbx.Size = new System.Drawing.Size(231, 48);
            this.inventory_tbx.TabIndex = 4;
            this.inventory_tbx.TabStop = false;
            this.inventory_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.inventory_tbx.TrailingIcon = null;
            this.inventory_tbx.UseSystemPasswordChar = false;
            // 
            // author_tbx
            // 
            this.author_tbx.AnimateReadOnly = false;
            this.author_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.author_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.author_tbx.Depth = 0;
            this.author_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.author_tbx.HideSelection = true;
            this.author_tbx.Hint = "作者";
            this.author_tbx.LeadingIcon = null;
            this.author_tbx.Location = new System.Drawing.Point(3, 54);
            this.author_tbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.author_tbx.MaxLength = 32767;
            this.author_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.author_tbx.Name = "author_tbx";
            this.author_tbx.PasswordChar = '\0';
            this.author_tbx.PrefixSuffixText = null;
            this.author_tbx.ReadOnly = false;
            this.author_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.author_tbx.SelectedText = "";
            this.author_tbx.SelectionLength = 0;
            this.author_tbx.SelectionStart = 0;
            this.author_tbx.ShortcutsEnabled = true;
            this.author_tbx.Size = new System.Drawing.Size(229, 48);
            this.author_tbx.TabIndex = 1;
            this.author_tbx.TabStop = false;
            this.author_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.author_tbx.TrailingIcon = null;
            this.author_tbx.UseSystemPasswordChar = false;
            // 
            // bookName_tbx
            // 
            this.bookName_tbx.AnimateReadOnly = false;
            this.bookName_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bookName_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bookName_tbx.Depth = 0;
            this.bookName_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.bookName_tbx.HideSelection = true;
            this.bookName_tbx.Hint = "书名";
            this.bookName_tbx.LeadingIcon = null;
            this.bookName_tbx.Location = new System.Drawing.Point(3, 2);
            this.bookName_tbx.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookName_tbx.MaxLength = 32767;
            this.bookName_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.bookName_tbx.Name = "bookName_tbx";
            this.bookName_tbx.PasswordChar = '\0';
            this.bookName_tbx.PrefixSuffixText = null;
            this.bookName_tbx.ReadOnly = false;
            this.bookName_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bookName_tbx.SelectedText = "";
            this.bookName_tbx.SelectionLength = 0;
            this.bookName_tbx.SelectionStart = 0;
            this.bookName_tbx.ShortcutsEnabled = true;
            this.bookName_tbx.Size = new System.Drawing.Size(231, 48);
            this.bookName_tbx.TabIndex = 0;
            this.bookName_tbx.TabStop = false;
            this.bookName_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bookName_tbx.TrailingIcon = null;
            this.bookName_tbx.UseSystemPasswordChar = false;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(4, 266);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(229, 36);
            this.materialButton1.TabIndex = 5;
            this.materialButton1.Text = "设置书架位置";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.btnSelectLocation_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(4, 314);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(229, 36);
            this.materialButton2.TabIndex = 6;
            this.materialButton2.Text = "选择图片";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // AddButton3
            // 
            this.AddButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddButton3.Depth = 0;
            this.AddButton3.HighEmphasis = true;
            this.AddButton3.Icon = null;
            this.AddButton3.Location = new System.Drawing.Point(4, 362);
            this.AddButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddButton3.Name = "AddButton3";
            this.AddButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddButton3.Size = new System.Drawing.Size(64, 36);
            this.AddButton3.TabIndex = 7;
            this.AddButton3.Text = "添加";
            this.AddButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddButton3.UseAccentColor = false;
            this.AddButton3.UseVisualStyleBackColor = true;
            this.AddButton3.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(34, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(113, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "从excel导入";
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(33, 79);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 82;
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 2);
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(533, 530);
            this.dataGridView1.TabIndex = 3;
            // 
            // confim_button
            // 
            this.confim_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.confim_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.confim_button.Depth = 0;
            this.confim_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confim_button.HighEmphasis = true;
            this.confim_button.Icon = null;
            this.confim_button.Location = new System.Drawing.Point(265, 36);
            this.confim_button.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.confim_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.confim_button.Name = "confim_button";
            this.confim_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.confim_button.Size = new System.Drawing.Size(300, 35);
            this.confim_button.TabIndex = 1;
            this.confim_button.Text = "确认入库";
            this.confim_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.confim_button.UseAccentColor = false;
            this.confim_button.UseVisualStyleBackColor = true;
            this.confim_button.Click += new System.EventHandler(this.confim_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(721, 33);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(233, 165);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "封面";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 141);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // AddBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1013, 621);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddBookForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.Sizable = false;
            this.Text = "AddBookForm";
            this.Load += new System.EventHandler(this.AddBookForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton btnSelectImage;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private MaterialSkin.Controls.MaterialTextBox2 ISBN_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 price_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 inventory_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 author_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 bookName_tbx;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton AddButton3;
        private MaterialSkin.Controls.MaterialButton button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialButton confim_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}