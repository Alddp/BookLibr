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
            this.ReturnView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.BorrowView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnView)).BeginInit();
            this.SuspendLayout();
            // 
            // return_button
            // 
            this.return_button.Location = new System.Drawing.Point(843, 894);
            this.return_button.Name = "return_button";
            this.return_button.Size = new System.Drawing.Size(202, 51);
            this.return_button.TabIndex = 2;
            this.return_button.Text = "确认归还";
            this.return_button.UseVisualStyleBackColor = true;
            this.return_button.Click += new System.EventHandler(this.return_button_Click);
            // 
            // BorrowView
            // 
            this.BorrowView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BorrowView.Location = new System.Drawing.Point(116, 168);
            this.BorrowView.Name = "BorrowView";
            this.BorrowView.RowHeadersWidth = 82;
            this.BorrowView.RowTemplate.Height = 37;
            this.BorrowView.Size = new System.Drawing.Size(446, 667);
            this.BorrowView.TabIndex = 3;
            // 
            // ReturnView
            // 
            this.ReturnView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReturnView.Location = new System.Drawing.Point(732, 168);
            this.ReturnView.Name = "ReturnView";
            this.ReturnView.RowHeadersWidth = 82;
            this.ReturnView.RowTemplate.Height = 37;
            this.ReturnView.Size = new System.Drawing.Size(441, 667);
            this.ReturnView.TabIndex = 4;
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 1106);
            this.Controls.Add(this.ReturnView);
            this.Controls.Add(this.BorrowView);
            this.Controls.Add(this.return_button);
            this.Name = "ReturnForm";
            this.Text = "ReturnForm";
            ((System.ComponentModel.ISupportInitialize)(this.BorrowView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReturnView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button return_button;
        private System.Windows.Forms.DataGridView BorrowView;
        private System.Windows.Forms.DataGridView ReturnView;
    }
}