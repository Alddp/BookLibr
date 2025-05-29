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
            this.借书记录.ItemHeight = 24;
            this.借书记录.Location = new System.Drawing.Point(76, 157);
            this.借书记录.Name = "借书记录";
            this.借书记录.Size = new System.Drawing.Size(480, 676);
            this.借书记录.TabIndex = 0;
            // 
            // 还书记录
            // 
            this.还书记录.FormattingEnabled = true;
            this.还书记录.ItemHeight = 24;
            this.还书记录.Location = new System.Drawing.Point(704, 157);
            this.还书记录.Name = "还书记录";
            this.还书记录.Size = new System.Drawing.Size(480, 676);
            this.还书记录.TabIndex = 1;
            // 
            // return_button
            // 
            this.return_button.Location = new System.Drawing.Point(843, 895);
            this.return_button.Name = "return_button";
            this.return_button.Size = new System.Drawing.Size(203, 51);
            this.return_button.TabIndex = 2;
            this.return_button.Text = "确认归还";
            this.return_button.UseVisualStyleBackColor = true;
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 1105);
            this.Controls.Add(this.return_button);
            this.Controls.Add(this.还书记录);
            this.Controls.Add(this.借书记录);
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