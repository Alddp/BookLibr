namespace BookLiber.OperForm {
    partial class ReturnForm {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userName_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.cardNum_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BorrowView = new System.Windows.Forms.DataGridView();
            this.return_button = new MaterialSkin.Controls.MaterialButton();
            this.query_button = new MaterialSkin.Controls.MaterialButton();
            this.search_tbx = new MaterialSkin.Controls.MaterialTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.BorrowView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.return_button, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.query_button, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.search_tbx, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.materialButton1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1060, 558);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userName_tbx);
            this.groupBox1.Controls.Add(this.cardNum_tbx);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 48);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(310, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // userName_tbx
            // 
            this.userName_tbx.AnimateReadOnly = false;
            this.userName_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userName_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.userName_tbx.Depth = 0;
            this.userName_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.userName_tbx.HideSelection = true;
            this.userName_tbx.Hint = "姓名";
            this.userName_tbx.LeadingIcon = null;
            this.userName_tbx.Location = new System.Drawing.Point(11, 317);
            this.userName_tbx.MaxLength = 32767;
            this.userName_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.userName_tbx.Name = "userName_tbx";
            this.userName_tbx.PasswordChar = '\0';
            this.userName_tbx.PrefixSuffixText = null;
            this.userName_tbx.ReadOnly = false;
            this.userName_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.userName_tbx.SelectedText = "";
            this.userName_tbx.SelectionLength = 0;
            this.userName_tbx.SelectionStart = 0;
            this.userName_tbx.ShortcutsEnabled = true;
            this.userName_tbx.Size = new System.Drawing.Size(289, 48);
            this.userName_tbx.TabIndex = 7;
            this.userName_tbx.TabStop = false;
            this.userName_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.userName_tbx.TrailingIcon = null;
            this.userName_tbx.UseSystemPasswordChar = false;
            // 
            // cardNum_tbx
            // 
            this.cardNum_tbx.AnimateReadOnly = false;
            this.cardNum_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cardNum_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.cardNum_tbx.Depth = 0;
            this.cardNum_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cardNum_tbx.HideSelection = true;
            this.cardNum_tbx.Hint = "卡号";
            this.cardNum_tbx.LeadingIcon = null;
            this.cardNum_tbx.Location = new System.Drawing.Point(11, 240);
            this.cardNum_tbx.MaxLength = 32767;
            this.cardNum_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.cardNum_tbx.Name = "cardNum_tbx";
            this.cardNum_tbx.PasswordChar = '\0';
            this.cardNum_tbx.PrefixSuffixText = null;
            this.cardNum_tbx.ReadOnly = false;
            this.cardNum_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cardNum_tbx.SelectedText = "";
            this.cardNum_tbx.SelectionLength = 0;
            this.cardNum_tbx.SelectionStart = 0;
            this.cardNum_tbx.ShortcutsEnabled = true;
            this.cardNum_tbx.Size = new System.Drawing.Size(289, 48);
            this.cardNum_tbx.TabIndex = 6;
            this.cardNum_tbx.TabStop = false;
            this.cardNum_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.cardNum_tbx.TrailingIcon = null;
            this.cardNum_tbx.UseSystemPasswordChar = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(62, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 172);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "用户照片";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 21);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BorrowView
            // 
            this.BorrowView.AllowUserToAddRows = false;
            this.BorrowView.AllowUserToDeleteRows = false;
            this.BorrowView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BorrowView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BorrowView.Location = new System.Drawing.Point(322, 48);
            this.BorrowView.Margin = new System.Windows.Forms.Padding(4);
            this.BorrowView.Name = "BorrowView";
            this.BorrowView.RowHeadersWidth = 51;
            this.BorrowView.RowTemplate.Height = 23;
            this.BorrowView.Size = new System.Drawing.Size(734, 403);
            this.BorrowView.TabIndex = 1;
            // 
            // return_button
            // 
            this.return_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.return_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.return_button.Depth = 0;
            this.return_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.return_button.HighEmphasis = true;
            this.return_button.Icon = null;
            this.return_button.Location = new System.Drawing.Point(323, 514);
            this.return_button.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.return_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.return_button.Name = "return_button";
            this.return_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.return_button.Size = new System.Drawing.Size(732, 36);
            this.return_button.TabIndex = 2;
            this.return_button.Text = "还书";
            this.return_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.return_button.UseAccentColor = false;
            this.return_button.UseVisualStyleBackColor = true;
            this.return_button.Click += new System.EventHandler(this.return_button_Click);
            // 
            // query_button
            // 
            this.query_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.query_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.query_button.Depth = 0;
            this.query_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.query_button.HighEmphasis = true;
            this.query_button.Icon = null;
            this.query_button.Location = new System.Drawing.Point(323, 463);
            this.query_button.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.query_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.query_button.Name = "query_button";
            this.query_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.query_button.Size = new System.Drawing.Size(732, 35);
            this.query_button.TabIndex = 3;
            this.query_button.Text = "刷新查询";
            this.query_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.query_button.UseAccentColor = false;
            this.query_button.UseVisualStyleBackColor = true;
            this.query_button.Click += new System.EventHandler(this.query_button_Click);
            // 
            // search_tbx
            // 
            this.search_tbx.AnimateReadOnly = false;
            this.search_tbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.search_tbx.Depth = 0;
            this.search_tbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.search_tbx.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.search_tbx.Hint = "输入关键字";
            this.search_tbx.LeadingIcon = null;
            this.search_tbx.Location = new System.Drawing.Point(4, 459);
            this.search_tbx.Margin = new System.Windows.Forms.Padding(4);
            this.search_tbx.MaxLength = 50;
            this.search_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.search_tbx.Multiline = false;
            this.search_tbx.Name = "search_tbx";
            this.search_tbx.Size = new System.Drawing.Size(310, 50);
            this.search_tbx.TabIndex = 4;
            this.search_tbx.Text = "";
            this.search_tbx.TrailingIcon = null;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(5, 514);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(308, 36);
            this.materialButton1.TabIndex = 5;
            this.materialButton1.Text = "筛选";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReturnForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 4, 4);
            this.Text = "还书";
            this.Load += new System.EventHandler(this.ReturnForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView BorrowView;
        private MaterialSkin.Controls.MaterialButton return_button;
        private MaterialSkin.Controls.MaterialButton query_button;
        private MaterialSkin.Controls.MaterialTextBox search_tbx;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialTextBox2 userName_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 cardNum_tbx;
    }
}