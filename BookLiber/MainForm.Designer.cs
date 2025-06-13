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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.借书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还书SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.书籍入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.读卡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // 借书ToolStripMenuItem
            // 
            this.借书ToolStripMenuItem.Name = "借书ToolStripMenuItem";
            this.借书ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.借书ToolStripMenuItem.Text = "借书";
            this.借书ToolStripMenuItem.Click += new System.EventHandler(this.借书记录ToolStripMenuItem_Click);
            // 
            // 还书SToolStripMenuItem
            // 
            this.还书SToolStripMenuItem.Name = "还书SToolStripMenuItem";
            this.还书SToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.还书SToolStripMenuItem.Text = "还书";
            this.还书SToolStripMenuItem.Click += new System.EventHandler(this.还书记录ToolStripMenuItem_Click);
            // 
            // 开卡ToolStripMenuItem
            // 
            this.开卡ToolStripMenuItem.Name = "开卡ToolStripMenuItem";
            this.开卡ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.开卡ToolStripMenuItem.Text = "开卡";
            this.开卡ToolStripMenuItem.Click += new System.EventHandler(this.开卡ToolStripMenuItem_Click);
            // 
            // 书籍入库ToolStripMenuItem
            // 
            this.书籍入库ToolStripMenuItem.Name = "书籍入库ToolStripMenuItem";
            this.书籍入库ToolStripMenuItem.Size = new System.Drawing.Size(83, 28);
            this.书籍入库ToolStripMenuItem.Text = "书籍入库";
            this.书籍入库ToolStripMenuItem.Click += new System.EventHandler(this.书籍入库ToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读卡ToolStripMenuItem,
            this.借书ToolStripMenuItem,
            this.还书SToolStripMenuItem,
            this.开卡ToolStripMenuItem,
            this.书籍入库ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1057, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 读卡ToolStripMenuItem
            // 
            this.读卡ToolStripMenuItem.Name = "读卡ToolStripMenuItem";
            this.读卡ToolStripMenuItem.Size = new System.Drawing.Size(53, 28);
            this.读卡ToolStripMenuItem.Text = "读卡";
            this.读卡ToolStripMenuItem.Click += new System.EventHandler(this.读卡ToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 96.69604F));
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.88701F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1057, 704);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1057, 734);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1075, 781);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 借书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还书SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开卡ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 书籍入库ToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem 读卡ToolStripMenuItem;
    }
}