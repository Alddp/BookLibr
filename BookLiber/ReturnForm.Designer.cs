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
            this.return_button = new System.Windows.Forms.Button();
            this.BorrowView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowView)).BeginInit();
            this.SuspendLayout();
            // 
            // return_button
            // 
            this.return_button.Location = new System.Drawing.Point(562, 559);
            this.return_button.Margin = new System.Windows.Forms.Padding(2);
            this.return_button.Name = "return_button";
            this.return_button.Size = new System.Drawing.Size(135, 32);
            this.return_button.TabIndex = 2;
            this.return_button.Text = "确认归还";
            this.return_button.UseVisualStyleBackColor = true;
            this.return_button.Click += new System.EventHandler(this.return_button_Click);
            // 
            // BorrowView
            // 
            this.BorrowView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BorrowView.Location = new System.Drawing.Point(77, 105);
            this.BorrowView.Margin = new System.Windows.Forms.Padding(2);
            this.BorrowView.Name = "BorrowView";
            this.BorrowView.RowHeadersWidth = 82;
            this.BorrowView.RowTemplate.Height = 37;
            this.BorrowView.Size = new System.Drawing.Size(736, 431);
            this.BorrowView.TabIndex = 3;
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 691);
            this.Controls.Add(this.BorrowView);
            this.Controls.Add(this.return_button);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ReturnForm";
            this.Text = "ReturnForm";
            this.Load += new System.EventHandler(this.ReturnForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BorrowView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button return_button;
        private System.Windows.Forms.DataGridView BorrowView;
    }
}