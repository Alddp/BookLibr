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
            this.userName_lb = new MaterialSkin.Controls.MaterialLabel();
            this.cardNum_lb = new MaterialSkin.Controls.MaterialLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BorrowView = new System.Windows.Forms.DataGridView();
            this.return_button = new MaterialSkin.Controls.MaterialButton();
            this.query_button = new MaterialSkin.Controls.MaterialButton();
            this.search_tbx = new MaterialSkin.Controls.MaterialTextBox();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1060, 558);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.userName_lb);
            this.groupBox1.Controls.Add(this.cardNum_lb);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(310, 392);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // userName_lb
            // 
            this.userName_lb.AutoSize = true;
            this.userName_lb.Depth = 0;
            this.userName_lb.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.userName_lb.Location = new System.Drawing.Point(7, 281);
            this.userName_lb.MouseState = MaterialSkin.MouseState.HOVER;
            this.userName_lb.Name = "userName_lb";
            this.userName_lb.Size = new System.Drawing.Size(49, 19);
            this.userName_lb.TabIndex = 4;
            this.userName_lb.Text = "姓名：";
            // 
            // cardNum_lb
            // 
            this.cardNum_lb.AutoSize = true;
            this.cardNum_lb.Depth = 0;
            this.cardNum_lb.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cardNum_lb.Location = new System.Drawing.Point(7, 242);
            this.cardNum_lb.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardNum_lb.Name = "cardNum_lb";
            this.cardNum_lb.Size = new System.Drawing.Size(49, 19);
            this.cardNum_lb.TabIndex = 3;
            this.cardNum_lb.Text = "卡号：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(8, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(175, 163);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BorrowView
            // 
            this.BorrowView.AllowUserToAddRows = false;
            this.BorrowView.AllowUserToDeleteRows = false;
            this.BorrowView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BorrowView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BorrowView.Location = new System.Drawing.Point(322, 62);
            this.BorrowView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BorrowView.Name = "BorrowView";
            this.BorrowView.RowHeadersWidth = 51;
            this.BorrowView.RowTemplate.Height = 23;
            this.BorrowView.Size = new System.Drawing.Size(734, 392);
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
            this.return_button.Location = new System.Drawing.Point(323, 516);
            this.return_button.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.return_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.return_button.Name = "return_button";
            this.return_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.return_button.Size = new System.Drawing.Size(732, 34);
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
            this.query_button.Location = new System.Drawing.Point(323, 466);
            this.query_button.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.query_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.query_button.Name = "query_button";
            this.query_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.query_button.Size = new System.Drawing.Size(732, 34);
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
            this.search_tbx.Location = new System.Drawing.Point(4, 462);
            this.search_tbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.materialButton1.Location = new System.Drawing.Point(5, 516);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(308, 34);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ReturnForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 4, 4);
            this.Text = "还书";
            this.Load += new System.EventHandler(this.ReturnForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private MaterialSkin.Controls.MaterialLabel userName_lb;
        private MaterialSkin.Controls.MaterialLabel cardNum_lb;
    }
}