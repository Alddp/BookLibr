namespace BookLiber{
    partial class LoginForm {
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
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.txtUsername = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtPassword = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.materialLabel1.Location = new System.Drawing.Point(122, 80);
            this.materialLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(97, 29);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "欢迎登录";
            // 
            // txtUsername
            // 
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUsername.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtUsername.HideSelection = true;
            this.txtUsername.Hint = "用户名";
            this.txtUsername.LeadingIcon = null;
            this.txtUsername.Location = new System.Drawing.Point(48, 166);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PrefixSuffixText = null;
            this.txtUsername.ReadOnly = false;
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.Size = new System.Drawing.Size(281, 48);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TabStop = false;
            this.txtUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUsername.TrailingIcon = null;
            this.txtUsername.UseSystemPasswordChar = false;
            // 
            // txtPassword
            // 
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtPassword.HideSelection = true;
            this.txtPassword.Hint = "密码";
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(48, 250);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PrefixSuffixText = null;
            this.txtPassword.ReadOnly = false;
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(281, 48);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TabStop = false;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.TrailingIcon = null;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(132, 362);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(111, 40);
            this.materialButton1.TabIndex = 3;
            this.materialButton1.Text = "登录";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(375, 500);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.materialLabel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LoginForm";
            this.Padding = new System.Windows.Forms.Padding(2, 64, 2, 2);
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialTextBox2 txtUsername;
        private MaterialSkin.Controls.MaterialTextBox2 txtPassword;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}