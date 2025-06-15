namespace BookLiber
{
    partial class RegisterForm
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
            this.materialTextBox21 = new MaterialSkin.Controls.MaterialTextBox2();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AutoSize = false;
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.button1.Depth = 0;
            this.button1.HighEmphasis = true;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(112, 497);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.MouseState = MaterialSkin.MouseState.HOVER;
            this.button1.Name = "button1";
            this.button1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.button1.Size = new System.Drawing.Size(119, 40);
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
            this.Phone_tb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Phone_tb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.Phone_tb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Phone_tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Phone_tb.Depth = 0;
            this.Phone_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Phone_tb.HideSelection = true;
            this.Phone_tb.Hint = "电话";
            this.Phone_tb.LeadingIcon = null;
            this.Phone_tb.Location = new System.Drawing.Point(75, 340);
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
            this.Phone_tb.Size = new System.Drawing.Size(193, 48);
            this.Phone_tb.TabIndex = 3;
            this.Phone_tb.TabStop = false;
            this.Phone_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Phone_tb.TrailingIcon = null;
            this.Phone_tb.UseSystemPasswordChar = false;
            // 
            // Pwd_tb
            // 
            this.Pwd_tb.AnimateReadOnly = false;
            this.Pwd_tb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.Pwd_tb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.Pwd_tb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Pwd_tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.Pwd_tb.Depth = 0;
            this.Pwd_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Pwd_tb.HideSelection = true;
            this.Pwd_tb.Hint = "密码";
            this.Pwd_tb.LeadingIcon = null;
            this.Pwd_tb.Location = new System.Drawing.Point(75, 198);
            this.Pwd_tb.MaxLength = 32767;
            this.Pwd_tb.MouseState = MaterialSkin.MouseState.OUT;
            this.Pwd_tb.Name = "Pwd_tb";
            this.Pwd_tb.PasswordChar = '\0';
            this.Pwd_tb.PrefixSuffixText = null;
            this.Pwd_tb.ReadOnly = false;
            this.Pwd_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Pwd_tb.SelectedText = "";
            this.Pwd_tb.SelectionLength = 0;
            this.Pwd_tb.SelectionStart = 0;
            this.Pwd_tb.ShortcutsEnabled = true;
            this.Pwd_tb.Size = new System.Drawing.Size(193, 48);
            this.Pwd_tb.TabIndex = 1;
            this.Pwd_tb.TabStop = false;
            this.Pwd_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Pwd_tb.TrailingIcon = null;
            this.Pwd_tb.UseSystemPasswordChar = false;
            // 
            // UserName_tb
            // 
            this.UserName_tb.AnimateReadOnly = false;
            this.UserName_tb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.UserName_tb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.UserName_tb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.UserName_tb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.UserName_tb.Depth = 0;
            this.UserName_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.UserName_tb.HideSelection = true;
            this.UserName_tb.Hint = "账号";
            this.UserName_tb.LeadingIcon = null;
            this.UserName_tb.Location = new System.Drawing.Point(75, 133);
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
            this.UserName_tb.Size = new System.Drawing.Size(193, 48);
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
            this.materialComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.materialComboBox1.DropDownHeight = 174;
            this.materialComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.materialComboBox1.DropDownWidth = 121;
            this.materialComboBox1.Font = new System.Drawing.Font("HarmonyOS Sans SC Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialComboBox1.FormattingEnabled = true;
            this.materialComboBox1.Hint = "类型";
            this.materialComboBox1.IntegralHeight = false;
            this.materialComboBox1.ItemHeight = 43;
            this.materialComboBox1.Items.AddRange(new object[] {
            "操作员",
            "管理员"});
            this.materialComboBox1.Location = new System.Drawing.Point(111, 417);
            this.materialComboBox1.MaxDropDownItems = 4;
            this.materialComboBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialComboBox1.Name = "materialComboBox1";
            this.materialComboBox1.Size = new System.Drawing.Size(121, 49);
            this.materialComboBox1.StartIndex = 0;
            this.materialComboBox1.TabIndex = 4;
            // 
            // materialTextBox21
            // 
            this.materialTextBox21.AnimateReadOnly = false;
            this.materialTextBox21.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.materialTextBox21.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.materialTextBox21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialTextBox21.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.materialTextBox21.Depth = 0;
            this.materialTextBox21.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox21.HideSelection = true;
            this.materialTextBox21.Hint = "确认密码";
            this.materialTextBox21.LeadingIcon = null;
            this.materialTextBox21.Location = new System.Drawing.Point(75, 268);
            this.materialTextBox21.MaxLength = 32767;
            this.materialTextBox21.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox21.Name = "materialTextBox21";
            this.materialTextBox21.PasswordChar = '\0';
            this.materialTextBox21.PrefixSuffixText = null;
            this.materialTextBox21.ReadOnly = false;
            this.materialTextBox21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.materialTextBox21.SelectedText = "";
            this.materialTextBox21.SelectionLength = 0;
            this.materialTextBox21.SelectionStart = 0;
            this.materialTextBox21.ShortcutsEnabled = true;
            this.materialTextBox21.Size = new System.Drawing.Size(193, 48);
            this.materialTextBox21.TabIndex = 2;
            this.materialTextBox21.TabStop = false;
            this.materialTextBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.materialTextBox21.TrailingIcon = null;
            this.materialTextBox21.UseSystemPasswordChar = false;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 633);
            this.Controls.Add(this.materialTextBox21);
            this.Controls.Add(this.materialComboBox1);
            this.Controls.Add(this.UserName_tb);
            this.Controls.Add(this.Pwd_tb);
            this.Controls.Add(this.Phone_tb);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RegisterForm";
            this.Sizable = false;
            this.Text = "注册";
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton button1;
        private MaterialSkin.Controls.MaterialTextBox2 Phone_tb;
        private MaterialSkin.Controls.MaterialTextBox2 Pwd_tb;
        private MaterialSkin.Controls.MaterialTextBox2 UserName_tb;
        private MaterialSkin.Controls.MaterialComboBox materialComboBox1;
        private MaterialSkin.Controls.MaterialTextBox2 materialTextBox21;
    }
}