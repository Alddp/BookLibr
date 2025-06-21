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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.ISBN_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.shelfId_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.price_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.inventory_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.author_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.bookName_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.add_button = new MaterialSkin.Controls.MaterialButton();
            this.lab7 = new System.Windows.Forms.Label();
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.confim_button = new MaterialSkin.Controls.MaterialButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridView1, 2);
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(17, 53);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 37;
            this.dataGridView1.Size = new System.Drawing.Size(420, 384);
            this.dataGridView1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.81742F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.18258F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 55F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.confim_button, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lab7, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.656036F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.961276F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.38269F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 7F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 447);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.ISBN_tbx);
            this.flowLayoutPanel3.Controls.Add(this.shelfId_tbx);
            this.flowLayoutPanel3.Controls.Add(this.price_tbx);
            this.flowLayoutPanel3.Controls.Add(this.inventory_tbx);
            this.flowLayoutPanel3.Controls.Add(this.author_tbx);
            this.flowLayoutPanel3.Controls.Add(this.bookName_tbx);
            this.flowLayoutPanel3.Controls.Add(this.panel1);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(552, 53);
            this.flowLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(171, 384);
            this.flowLayoutPanel3.TabIndex = 5;
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
            this.ISBN_tbx.Location = new System.Drawing.Point(2, 2);
            this.ISBN_tbx.Margin = new System.Windows.Forms.Padding(2);
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
            this.ISBN_tbx.Size = new System.Drawing.Size(172, 48);
            this.ISBN_tbx.TabIndex = 0;
            this.ISBN_tbx.TabStop = false;
            this.ISBN_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ISBN_tbx.TrailingIcon = null;
            this.ISBN_tbx.UseSystemPasswordChar = false;
            // 
            // shelfId_tbx
            // 
            this.shelfId_tbx.AnimateReadOnly = false;
 
            this.shelfId_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.shelfId_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.shelfId_tbx.Depth = 0;
            this.shelfId_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.shelfId_tbx.HideSelection = true;
            this.shelfId_tbx.Hint = "书架编号";
            this.shelfId_tbx.LeadingIcon = null;
            this.shelfId_tbx.Location = new System.Drawing.Point(2, 54);
            this.shelfId_tbx.Margin = new System.Windows.Forms.Padding(2);
            this.shelfId_tbx.MaxLength = 32767;
            this.shelfId_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.shelfId_tbx.Name = "shelfId_tbx";
            this.shelfId_tbx.PasswordChar = '\0';
            this.shelfId_tbx.PrefixSuffixText = null;
            this.shelfId_tbx.ReadOnly = false;
            this.shelfId_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.shelfId_tbx.SelectedText = "";
            this.shelfId_tbx.SelectionLength = 0;
            this.shelfId_tbx.SelectionStart = 0;
            this.shelfId_tbx.ShortcutsEnabled = true;
            this.shelfId_tbx.Size = new System.Drawing.Size(172, 48);
            this.shelfId_tbx.TabIndex = 1;
            this.shelfId_tbx.TabStop = false;
            this.shelfId_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.shelfId_tbx.TrailingIcon = null;
            this.shelfId_tbx.UseSystemPasswordChar = false;
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
            this.price_tbx.Location = new System.Drawing.Point(2, 106);
            this.price_tbx.Margin = new System.Windows.Forms.Padding(2);
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
            this.price_tbx.Size = new System.Drawing.Size(173, 48);
            this.price_tbx.TabIndex = 2;
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
            this.inventory_tbx.Location = new System.Drawing.Point(2, 158);
            this.inventory_tbx.Margin = new System.Windows.Forms.Padding(2);
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
            this.inventory_tbx.Size = new System.Drawing.Size(173, 48);
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
            this.author_tbx.Location = new System.Drawing.Point(2, 210);
            this.author_tbx.Margin = new System.Windows.Forms.Padding(2);
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
            this.author_tbx.Size = new System.Drawing.Size(172, 48);
            this.author_tbx.TabIndex = 5;
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
            this.bookName_tbx.Location = new System.Drawing.Point(2, 262);
            this.bookName_tbx.Margin = new System.Windows.Forms.Padding(2);
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
            this.bookName_tbx.Size = new System.Drawing.Size(173, 48);
            this.bookName_tbx.TabIndex = 6;
            this.bookName_tbx.TabStop = false;
            this.bookName_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bookName_tbx.TrailingIcon = null;
            this.bookName_tbx.UseSystemPasswordChar = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.add_button);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 336);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 24, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(173, 31);
            this.panel1.TabIndex = 13;
            // 
            // add_button
            // 
            this.add_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.add_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.add_button.Depth = 0;
            this.add_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add_button.HighEmphasis = true;
            this.add_button.Icon = null;
            this.add_button.Location = new System.Drawing.Point(0, 0);
            this.add_button.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.add_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.add_button.Name = "add_button";
            this.add_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.add_button.Size = new System.Drawing.Size(173, 31);
            this.add_button.TabIndex = 0;
            this.add_button.Text = "添加";
            this.add_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.add_button.UseAccentColor = false;
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // lab7
            // 
            this.lab7.AutoSize = true;
            this.lab7.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab7.Location = new System.Drawing.Point(211, 10);
            this.lab7.Margin = new System.Windows.Forms.Padding(15, 10, 2, 0);
            this.lab7.Name = "lab7";
            this.lab7.Size = new System.Drawing.Size(60, 14);
            this.lab7.TabIndex = 2;
            this.lab7.Text = "暂存0本";
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(18, 5);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(110, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "从excel导入";
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // confim_button
            // 
            this.confim_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.confim_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.confim_button.Depth = 0;
            this.confim_button.HighEmphasis = true;
            this.confim_button.Icon = null;
            this.confim_button.Location = new System.Drawing.Point(553, 5);
            this.confim_button.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.confim_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.confim_button.Name = "confim_button";
            this.confim_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.confim_button.Size = new System.Drawing.Size(79, 28);
            this.confim_button.TabIndex = 0;
            this.confim_button.Text = "确认入库";
            this.confim_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.confim_button.UseAccentColor = false;
            this.confim_button.UseVisualStyleBackColor = true;
            this.confim_button.Click += new System.EventHandler(this.confim_button_Click);
            // 
            // AddBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 468);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddBookForm";
            this.Padding = new System.Windows.Forms.Padding(2, 19, 2, 2);
            this.Sizable = false;
            this.Text = "AddBookForm";
            this.Load += new System.EventHandler(this.AddBookForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label lab7;
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialButton confim_button;
        private MaterialSkin.Controls.MaterialTextBox2 ISBN_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 shelfId_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 price_tbx;
        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialButton add_button;
        private MaterialSkin.Controls.MaterialTextBox2 inventory_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 author_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 bookName_tbx;
    }
}