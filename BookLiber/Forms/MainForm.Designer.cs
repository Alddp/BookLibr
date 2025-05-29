namespace BookLiber.Forms
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.借书记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还书记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.书籍入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借书记录ToolStripMenuItem,
            this.还书记录ToolStripMenuItem,
            this.开卡ToolStripMenuItem,
            this.书籍入库ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 借书记录ToolStripMenuItem
            // 
            this.借书记录ToolStripMenuItem.Name = "借书记录ToolStripMenuItem";
            this.借书记录ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.借书记录ToolStripMenuItem.Text = "借书记录";
            // 
            // 还书记录ToolStripMenuItem
            // 
            this.还书记录ToolStripMenuItem.Name = "还书记录ToolStripMenuItem";
            this.还书记录ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.还书记录ToolStripMenuItem.Text = "还书记录";
            // 
            // 开卡ToolStripMenuItem
            // 
            this.开卡ToolStripMenuItem.Name = "开卡ToolStripMenuItem";
            this.开卡ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开卡ToolStripMenuItem.Text = "开卡";
            // 
            // 书籍入库ToolStripMenuItem
            // 
            this.书籍入库ToolStripMenuItem.Name = "书籍入库ToolStripMenuItem";
            this.书籍入库ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.书籍入库ToolStripMenuItem.Text = "书籍入库";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 借书记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还书记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 书籍入库ToolStripMenuItem;
    }
}