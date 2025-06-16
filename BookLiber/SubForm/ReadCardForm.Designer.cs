namespace BookLiber.SubForm {
    partial class ReadCardForm {
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.cardNum_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.readerName_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.stuID_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.phone_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.class_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.startTime_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.endTime_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.read_button = new MaterialSkin.Controls.MaterialButton();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.347435F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.47358F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.20591F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.57867F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.4F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.read_button, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.497623F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.53249F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.96989F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(746, 558);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(46, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(190, 183);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户照片";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(2, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 165);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.cardNum_tbx);
            this.flowLayoutPanel2.Controls.Add(this.readerName_tbx);
            this.flowLayoutPanel2.Controls.Add(this.stuID_tbx);
            this.flowLayoutPanel2.Controls.Add(this.phone_tbx);
            this.flowLayoutPanel2.Controls.Add(this.class_tbx);
            this.flowLayoutPanel2.Controls.Add(this.startTime_tbx);
            this.flowLayoutPanel2.Controls.Add(this.endTime_tbx);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(464, 29);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.tableLayoutPanel2.SetRowSpan(this.flowLayoutPanel2, 3);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(239, 527);
            this.flowLayoutPanel2.TabIndex = 2;
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
            this.cardNum_tbx.Location = new System.Drawing.Point(5, 6);
            this.cardNum_tbx.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cardNum_tbx.MaxLength = 32767;
            this.cardNum_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.cardNum_tbx.Name = "cardNum_tbx";
            this.cardNum_tbx.PasswordChar = '\0';
            this.cardNum_tbx.PrefixSuffixText = null;
            this.cardNum_tbx.ReadOnly = true;
            this.cardNum_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cardNum_tbx.SelectedText = "";
            this.cardNum_tbx.SelectionLength = 0;
            this.cardNum_tbx.SelectionStart = 0;
            this.cardNum_tbx.ShortcutsEnabled = true;
            this.cardNum_tbx.Size = new System.Drawing.Size(188, 48);
            this.cardNum_tbx.TabIndex = 7;
            this.cardNum_tbx.TabStop = false;
            this.cardNum_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.cardNum_tbx.TrailingIcon = null;
            this.cardNum_tbx.UseSystemPasswordChar = false;
            // 
            // readerName_tbx
            // 
            this.readerName_tbx.AnimateReadOnly = false;
    
            this.readerName_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.readerName_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.readerName_tbx.Depth = 0;
            this.readerName_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.readerName_tbx.HideSelection = true;
            this.readerName_tbx.Hint = "姓名";
            this.readerName_tbx.LeadingIcon = null;
            this.readerName_tbx.Location = new System.Drawing.Point(5, 66);
            this.readerName_tbx.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.readerName_tbx.MaxLength = 32767;
            this.readerName_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.readerName_tbx.Name = "readerName_tbx";
            this.readerName_tbx.PasswordChar = '\0';
            this.readerName_tbx.PrefixSuffixText = null;
            this.readerName_tbx.ReadOnly = true;
            this.readerName_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.readerName_tbx.SelectedText = "";
            this.readerName_tbx.SelectionLength = 0;
            this.readerName_tbx.SelectionStart = 0;
            this.readerName_tbx.ShortcutsEnabled = true;
            this.readerName_tbx.Size = new System.Drawing.Size(188, 48);
            this.readerName_tbx.TabIndex = 9;
            this.readerName_tbx.TabStop = false;
            this.readerName_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.readerName_tbx.TrailingIcon = null;
            this.readerName_tbx.UseSystemPasswordChar = false;
            // 
            // stuID_tbx
            // 
            this.stuID_tbx.AnimateReadOnly = false;
         
            this.stuID_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.stuID_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.stuID_tbx.Depth = 0;
            this.stuID_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.stuID_tbx.HideSelection = true;
            this.stuID_tbx.Hint = "学号";
            this.stuID_tbx.LeadingIcon = null;
            this.stuID_tbx.Location = new System.Drawing.Point(5, 126);
            this.stuID_tbx.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.stuID_tbx.MaxLength = 32767;
            this.stuID_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.stuID_tbx.Name = "stuID_tbx";
            this.stuID_tbx.PasswordChar = '\0';
            this.stuID_tbx.PrefixSuffixText = null;
            this.stuID_tbx.ReadOnly = true;
            this.stuID_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stuID_tbx.SelectedText = "";
            this.stuID_tbx.SelectionLength = 0;
            this.stuID_tbx.SelectionStart = 0;
            this.stuID_tbx.ShortcutsEnabled = true;
            this.stuID_tbx.Size = new System.Drawing.Size(188, 48);
            this.stuID_tbx.TabIndex = 10;
            this.stuID_tbx.TabStop = false;
            this.stuID_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stuID_tbx.TrailingIcon = null;
            this.stuID_tbx.UseSystemPasswordChar = false;
            // 
            // phone_tbx
            // 
            this.phone_tbx.AnimateReadOnly = false;
     
            this.phone_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.phone_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.phone_tbx.Depth = 0;
            this.phone_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.phone_tbx.HideSelection = true;
            this.phone_tbx.Hint = "电话";
            this.phone_tbx.LeadingIcon = null;
            this.phone_tbx.Location = new System.Drawing.Point(5, 186);
            this.phone_tbx.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.phone_tbx.MaxLength = 32767;
            this.phone_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.phone_tbx.Name = "phone_tbx";
            this.phone_tbx.PasswordChar = '\0';
            this.phone_tbx.PrefixSuffixText = null;
            this.phone_tbx.ReadOnly = true;
            this.phone_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.phone_tbx.SelectedText = "";
            this.phone_tbx.SelectionLength = 0;
            this.phone_tbx.SelectionStart = 0;
            this.phone_tbx.ShortcutsEnabled = true;
            this.phone_tbx.Size = new System.Drawing.Size(188, 48);
            this.phone_tbx.TabIndex = 8;
            this.phone_tbx.TabStop = false;
            this.phone_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.phone_tbx.TrailingIcon = null;
            this.phone_tbx.UseSystemPasswordChar = false;
            // 
            // class_tbx
            // 
            this.class_tbx.AnimateReadOnly = false;
        
            this.class_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.class_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.class_tbx.Depth = 0;
            this.class_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.class_tbx.HideSelection = true;
            this.class_tbx.Hint = "班级";
            this.class_tbx.LeadingIcon = null;
            this.class_tbx.Location = new System.Drawing.Point(5, 246);
            this.class_tbx.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.class_tbx.MaxLength = 32767;
            this.class_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.class_tbx.Name = "class_tbx";
            this.class_tbx.PasswordChar = '\0';
            this.class_tbx.PrefixSuffixText = null;
            this.class_tbx.ReadOnly = true;
            this.class_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.class_tbx.SelectedText = "";
            this.class_tbx.SelectionLength = 0;
            this.class_tbx.SelectionStart = 0;
            this.class_tbx.ShortcutsEnabled = true;
            this.class_tbx.Size = new System.Drawing.Size(188, 48);
            this.class_tbx.TabIndex = 11;
            this.class_tbx.TabStop = false;
            this.class_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.class_tbx.TrailingIcon = null;
            this.class_tbx.UseSystemPasswordChar = false;
            // 
            // startTime_tbx
            // 
            this.startTime_tbx.AnimateReadOnly = false;
           
            this.startTime_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.startTime_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.startTime_tbx.Depth = 0;
            this.startTime_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.startTime_tbx.HideSelection = true;
            this.startTime_tbx.Hint = "开卡时间";
            this.startTime_tbx.LeadingIcon = null;
            this.startTime_tbx.Location = new System.Drawing.Point(5, 306);
            this.startTime_tbx.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.startTime_tbx.MaxLength = 32767;
            this.startTime_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.startTime_tbx.Name = "startTime_tbx";
            this.startTime_tbx.PasswordChar = '\0';
            this.startTime_tbx.PrefixSuffixText = null;
            this.startTime_tbx.ReadOnly = true;
            this.startTime_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startTime_tbx.SelectedText = "";
            this.startTime_tbx.SelectionLength = 0;
            this.startTime_tbx.SelectionStart = 0;
            this.startTime_tbx.ShortcutsEnabled = true;
            this.startTime_tbx.Size = new System.Drawing.Size(188, 48);
            this.startTime_tbx.TabIndex = 12;
            this.startTime_tbx.TabStop = false;
            this.startTime_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.startTime_tbx.TrailingIcon = null;
            this.startTime_tbx.UseSystemPasswordChar = false;
            // 
            // endTime_tbx
            // 
            this.endTime_tbx.AnimateReadOnly = false;
    
            this.endTime_tbx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.endTime_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.endTime_tbx.Depth = 0;
            this.endTime_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.endTime_tbx.HideSelection = true;
            this.endTime_tbx.Hint = "到期时间";
            this.endTime_tbx.LeadingIcon = null;
            this.endTime_tbx.Location = new System.Drawing.Point(5, 366);
            this.endTime_tbx.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.endTime_tbx.MaxLength = 32767;
            this.endTime_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.endTime_tbx.Name = "endTime_tbx";
            this.endTime_tbx.PasswordChar = '\0';
            this.endTime_tbx.PrefixSuffixText = null;
            this.endTime_tbx.ReadOnly = true;
            this.endTime_tbx.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.endTime_tbx.SelectedText = "";
            this.endTime_tbx.SelectionLength = 0;
            this.endTime_tbx.SelectionStart = 0;
            this.endTime_tbx.ShortcutsEnabled = true;
            this.endTime_tbx.Size = new System.Drawing.Size(188, 48);
            this.endTime_tbx.TabIndex = 13;
            this.endTime_tbx.TabStop = false;
            this.endTime_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.endTime_tbx.TrailingIcon = null;
            this.endTime_tbx.UseSystemPasswordChar = false;
            // 
            // read_button
            // 
            this.read_button.AutoSize = false;
            this.read_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.read_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.read_button.Depth = 0;
            this.read_button.HighEmphasis = true;
            this.read_button.Icon = null;
            this.read_button.Location = new System.Drawing.Point(47, 425);
            this.read_button.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.read_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.read_button.Name = "read_button";
            this.read_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.read_button.Size = new System.Drawing.Size(87, 36);
            this.read_button.TabIndex = 5;
            this.read_button.Text = "读卡";
            this.read_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.read_button.UseAccentColor = false;
            this.read_button.UseVisualStyleBackColor = true;
            this.read_button.Click += new System.EventHandler(this.read_button_Click);
            // 
            // ReadCardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 560);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReadCardForm";
            this.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.Sizable = false;
            this.Text = "ReadCardForm";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private MaterialSkin.Controls.MaterialTextBox2 cardNum_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 readerName_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 stuID_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 phone_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 class_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 startTime_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 endTime_tbx;
        private MaterialSkin.Controls.MaterialButton read_button;
    }
}