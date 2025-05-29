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
            this.借书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还书SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.书籍入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借书ToolStripMenuItem,
            this.还书SToolStripMenuItem,
            this.开卡ToolStripMenuItem,
            this.书籍入库ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1600, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 借书ToolStripMenuItem
            // 
            this.借书ToolStripMenuItem.Name = "借书ToolStripMenuItem";
            this.借书ToolStripMenuItem.Size = new System.Drawing.Size(82, 35);
            this.借书ToolStripMenuItem.Text = "借书";
            this.借书ToolStripMenuItem.Click += new System.EventHandler(this.借书记录ToolStripMenuItem_Click);
            // 
            // 还书SToolStripMenuItem
            // 
            this.还书SToolStripMenuItem.Name = "还书SToolStripMenuItem";
            this.还书SToolStripMenuItem.Size = new System.Drawing.Size(82, 35);
            this.还书SToolStripMenuItem.Text = "还书";
            this.还书SToolStripMenuItem.Click += new System.EventHandler(this.还书记录ToolStripMenuItem_Click);
            // 
            // 开卡ToolStripMenuItem
            // 
            this.开卡ToolStripMenuItem.Name = "开卡ToolStripMenuItem";
            this.开卡ToolStripMenuItem.Size = new System.Drawing.Size(82, 35);
            this.开卡ToolStripMenuItem.Text = "开卡";
            this.开卡ToolStripMenuItem.Click += new System.EventHandler(this.开卡ToolStripMenuItem_Click);
            // 
            // 书籍入库ToolStripMenuItem
            // 
            this.书籍入库ToolStripMenuItem.Name = "书籍入库ToolStripMenuItem";
            this.书籍入库ToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.书籍入库ToolStripMenuItem.Text = "书籍入库";
            this.书籍入库ToolStripMenuItem.Click += new System.EventHandler(this.书籍入库ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 借书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还书SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 书籍入库ToolStripMenuItem;
    }
}