﻿namespace BookLiber.AdminForm {
    partial class AddUserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new MaterialSkin.Controls.MaterialButton();
            this.Phone_tb = new MaterialSkin.Controls.MaterialTextBox2();
            this.Pwd_tb = new MaterialSkin.Controls.MaterialTextBox2();
            this.UserName_tb = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialComboBox1 = new MaterialSkin.Controls.MaterialComboBox();
            this.ConfirmPwd_tb = new MaterialSkin.Controls.MaterialTextBox2();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = false;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(4, 353);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(298, 56);
            this.button1.TabIndex = 5;
            this.button1.Text = "注册";
            this.button1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.button1.UseAccentColor = false;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Phone_tb
            // 
            this.Phone_tb.AnimateReadOnly = false;
            this.Phone_tb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Phone_tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Phone_tb.Depth = 0;
            this.Phone_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Phone_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Phone_tb.HideSelection = true;
            this.Phone_tb.Hint = "电话";
            this.Phone_tb.LeadingIcon = null;
            this.Phone_tb.Location = new System.Drawing.Point(3, 167);
            this.Phone_tb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Phone_tb.MaxLength = 32767;
            this.Phone_tb.MouseState = MaterialSkin.MouseState.OUT;
            this.Phone_tb.Name = "Phone_tb";
            this.Phone_tb.PasswordChar = '\0';
            this.Phone_tb.PrefixSuffixText = null;
            this.Phone_tb.ReadOnly = false;
            this.Phone_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Phone_tb.SelectedText = "";
            this.Phone_tb.SelectionLength = 0;
            this.Phone_tb.SelectionStart = 0;
            this.Phone_tb.ShortcutsEnabled = true;
            this.Phone_tb.Size = new System.Drawing.Size(300, 48);
            this.Phone_tb.TabIndex = 3;
            this.Phone_tb.TabStop = false;
            this.Phone_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Phone_tb.TrailingIcon = null;
            this.Phone_tb.UseSystemPasswordChar = false;
            // 
            // Pwd_tb
            // 
            this.Pwd_tb.AnimateReadOnly = false;
            this.Pwd_tb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Pwd_tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Pwd_tb.Depth = 0;
            this.Pwd_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pwd_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Pwd_tb.HideSelection = true;
            this.Pwd_tb.Hint = "密码";
            this.Pwd_tb.LeadingIcon = null;
            this.Pwd_tb.Location = new System.Drawing.Point(3, 112);
            this.Pwd_tb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Pwd_tb.MaxLength = 32767;
            this.Pwd_tb.MouseState = MaterialSkin.MouseState.OUT;
            this.Pwd_tb.Name = "Pwd_tb";
            this.Pwd_tb.PasswordChar = '●';
            this.Pwd_tb.PrefixSuffixText = null;
            this.Pwd_tb.ReadOnly = false;
            this.Pwd_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Pwd_tb.SelectedText = "";
            this.Pwd_tb.SelectionLength = 0;
            this.Pwd_tb.SelectionStart = 0;
            this.Pwd_tb.ShortcutsEnabled = true;
            this.Pwd_tb.Size = new System.Drawing.Size(300, 48);
            this.Pwd_tb.TabIndex = 2;
            this.Pwd_tb.TabStop = false;
            this.Pwd_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Pwd_tb.TrailingIcon = null;
            this.Pwd_tb.UseSystemPasswordChar = false;
            // 
            // UserName_tb
            // 
            this.UserName_tb.AnimateReadOnly = false;
            this.UserName_tb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UserName_tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UserName_tb.Depth = 0;
            this.UserName_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserName_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.UserName_tb.HideSelection = true;
            this.UserName_tb.Hint = "账号";
            this.UserName_tb.LeadingIcon = null;
            this.UserName_tb.Location = new System.Drawing.Point(3, 2);
            this.UserName_tb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UserName_tb.MaxLength = 32767;
            this.UserName_tb.MouseState = MaterialSkin.MouseState.OUT;
            this.UserName_tb.Name = "UserName_tb";
            this.UserName_tb.PasswordChar = '\0';
            this.UserName_tb.PrefixSuffixText = null;
            this.UserName_tb.ReadOnly = false;
            this.UserName_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.UserName_tb.SelectedText = "";
            this.UserName_tb.SelectionLength = 0;
            this.UserName_tb.SelectionStart = 0;
            this.UserName_tb.ShortcutsEnabled = true;
            this.UserName_tb.Size = new System.Drawing.Size(300, 48);
            this.UserName_tb.TabIndex = 0;
            this.UserName_tb.TabStop = false;
            this.UserName_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.UserName_tb.TrailingIcon = null;
            this.UserName_tb.UseSystemPasswordChar = false;
            // 
            // materialComboBox1
            // 
            this.materialComboBox1.AutoResize = true;
            this.materialComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialComboBox1.Depth = 0;
            this.materialComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialComboBox1.DropDownHeight = 174;
            this.materialComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox1.DropDownWidth = 121;
            this.materialComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialComboBox1.FormattingEnabled = true;
            this.materialComboBox1.Hint = "类型";
            this.materialComboBox1.IntegralHeight = false;
            this.materialComboBox1.ItemHeight = 43;
            this.materialComboBox1.Items.AddRange(new object[] {
            "操作员",
            "管理员"});
            this.materialComboBox1.Location = new System.Drawing.Point(3, 258);
            this.materialComboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.materialComboBox1.MaxDropDownItems = 4;
            this.materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialComboBox1.Name = "materialComboBox1";
            this.materialComboBox1.Size = new System.Drawing.Size(121, 49);
            this.materialComboBox1.StartIndex = 0;
            this.materialComboBox1.TabIndex = 4;
            // 
            // ConfirmPwd_tb
            // 
            this.ConfirmPwd_tb.AnimateReadOnly = false;
            this.ConfirmPwd_tb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ConfirmPwd_tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ConfirmPwd_tb.Depth = 0;
            this.ConfirmPwd_tb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfirmPwd_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ConfirmPwd_tb.HideSelection = true;
            this.ConfirmPwd_tb.Hint = "确认密码";
            this.ConfirmPwd_tb.LeadingIcon = null;
            this.ConfirmPwd_tb.Location = new System.Drawing.Point(3, 57);
            this.ConfirmPwd_tb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ConfirmPwd_tb.MaxLength = 32767;
            this.ConfirmPwd_tb.MouseState = MaterialSkin.MouseState.OUT;
            this.ConfirmPwd_tb.Name = "ConfirmPwd_tb";
            this.ConfirmPwd_tb.PasswordChar = '●';
            this.ConfirmPwd_tb.PrefixSuffixText = null;
            this.ConfirmPwd_tb.ReadOnly = false;
            this.ConfirmPwd_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ConfirmPwd_tb.SelectedText = "";
            this.ConfirmPwd_tb.SelectionLength = 0;
            this.ConfirmPwd_tb.SelectionStart = 0;
            this.ConfirmPwd_tb.ShortcutsEnabled = true;
            this.ConfirmPwd_tb.Size = new System.Drawing.Size(300, 48);
            this.ConfirmPwd_tb.TabIndex = 1;
            this.ConfirmPwd_tb.TabStop = false;
            this.ConfirmPwd_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConfirmPwd_tb.TrailingIcon = null;
            this.ConfirmPwd_tb.UseSystemPasswordChar = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1003, 609);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(69, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 415);
            this.panel1.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.Pwd_tb, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.materialComboBox1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.UserName_tb, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ConfirmPwd_tb, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.Phone_tb, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.90722F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.90722F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.97938F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(306, 415);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 611);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AddUserForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.Sizable = false;
            this.Text = "注册";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialTextBox2 Phone_tb;
        private MaterialSkin.Controls.MaterialTextBox2 Pwd_tb;
        private MaterialSkin.Controls.MaterialTextBox2 UserName_tb;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialTextBox2 ConfirmPwd_tb;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}