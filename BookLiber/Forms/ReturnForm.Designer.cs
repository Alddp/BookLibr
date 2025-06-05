namespace BookLiber
{
    partial class ReturnForm
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
            this.借书记录 = new System.Windows.Forms.ListBox();
            this.还书记录 = new System.Windows.Forms.ListBox();
            this.return_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 借书记录
            // 
            this.借书记录.FormattingEnabled = true;
            this.借书记录.ItemHeight = 15;
            this.借书记录.Location = new System.Drawing.Point(51, 98);
            this.借书记录.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.借书记录.Name = "借书记录";
            this.借书记录.Size = new System.Drawing.Size(321, 424);
            this.借书记录.TabIndex = 0;
            // 
            // 还书记录
            // 
            this.还书记录.FormattingEnabled = true;
            this.还书记录.ItemHeight = 15;
            this.还书记录.Location = new System.Drawing.Point(469, 98);
            this.还书记录.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.还书记录.Name = "还书记录";
            this.还书记录.Size = new System.Drawing.Size(321, 424);
            this.还书记录.TabIndex = 1;
            // 
            // return_button
            // 
            this.return_button.Location = new System.Drawing.Point(562, 559);
            this.return_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.return_button.Name = "return_button";
            this.return_button.Size = new System.Drawing.Size(135, 32);
            this.return_button.TabIndex = 2;
            this.return_button.Text = "确认归还";
            this.return_button.UseVisualStyleBackColor = true;
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 691);
            this.Controls.Add(this.return_button);
            this.Controls.Add(this.还书记录);
            this.Controls.Add(this.借书记录);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReturnForm";
            this.Text = "ReturnForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox 借书记录;
        private System.Windows.Forms.ListBox 还书记录;
        private System.Windows.Forms.Button return_button;
    }
}