namespace BookLiber
{
    partial class LoginForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UserName_tb = new System.Windows.Forms.TextBox();
            this.Pwd_tb = new System.Windows.Forms.TextBox();
            this.Register_bt = new System.Windows.Forms.Button();
            this.Login_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码";
            // 
            // userName_tb
            // 
            this.UserName_tb.Location = new System.Drawing.Point(177, 96);
            this.UserName_tb.Name = "userName_tb";
            this.UserName_tb.Size = new System.Drawing.Size(100, 21);
            this.UserName_tb.TabIndex = 3;
            // 
            // pwd_tb
            // 
            this.Pwd_tb.BackColor = System.Drawing.SystemColors.Window;
            this.Pwd_tb.Location = new System.Drawing.Point(177, 155);
            this.Pwd_tb.Name = "pwd_tb";
            this.Pwd_tb.Size = new System.Drawing.Size(100, 21);
            this.Pwd_tb.TabIndex = 4;
            // 
            // Register_bt
            // 
            this.Register_bt.Location = new System.Drawing.Point(155, 246);
            this.Register_bt.Name = "Register_bt";
            this.Register_bt.Size = new System.Drawing.Size(75, 23);
            this.Register_bt.TabIndex = 5;
            this.Register_bt.Text = "注册";
            this.Register_bt.UseVisualStyleBackColor = true;
            this.Register_bt.Click += new System.EventHandler(this.Register_bt_Click);
            // 
            // Login_bt
            // 
            this.Login_bt.Location = new System.Drawing.Point(155, 304);
            this.Login_bt.Name = "Login_bt";
            this.Login_bt.Size = new System.Drawing.Size(75, 23);
            this.Login_bt.TabIndex = 6;
            this.Login_bt.Text = "登录";
            this.Login_bt.UseVisualStyleBackColor = true;
            this.Login_bt.Click += new System.EventHandler(this.Login_bt_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 417);
            this.Controls.Add(this.Login_bt);
            this.Controls.Add(this.Register_bt);
            this.Controls.Add(this.Pwd_tb);
            this.Controls.Add(this.UserName_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginForm";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UserName_tb;
        private System.Windows.Forms.TextBox Pwd_tb;
        private System.Windows.Forms.Button Register_bt;
        private System.Windows.Forms.Button Login_bt;
    }
}