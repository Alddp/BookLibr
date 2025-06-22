namespace BookLiber.AdminForm {
    partial class OutputDialog {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.RichTextBox outputTextBox;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            this.outputTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // outputTextBox
            // 
            this.outputTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputTextBox.Location = new System.Drawing.Point(0, 0);
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.Size = new System.Drawing.Size(600, 400);
            this.outputTextBox.TabIndex = 0;
            this.outputTextBox.Text = "";
            this.outputTextBox.WordWrap = false;
            this.outputTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            // 
            // OutputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.outputTextBox);
            this.Name = "OutputDialog";
            this.Text = "脚本输出";
            this.ResumeLayout(false);
        }
    }
}