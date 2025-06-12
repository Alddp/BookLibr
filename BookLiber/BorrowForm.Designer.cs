namespace BookLiber
{
    partial class BorrowForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowForm));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.search_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.borrow_button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nametxt = new System.Windows.Forms.TextBox();
            this.stuIDtxt = new System.Windows.Forms.TextBox();
            this.cardNumtxt = new System.Windows.Forms.TextBox();
            this.phoentxt = new System.Windows.Forms.TextBox();
            this.classtxt = new System.Windows.Forms.TextBox();
            this.card_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(735, 54);
            this.search_button.Margin = new System.Windows.Forms.Padding(2);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(84, 31);
            this.search_button.TabIndex = 6;
            this.search_button.Text = "查询";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(564, 54);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 25);
            this.textBox1.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Location = new System.Drawing.Point(378, 103);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(633, 514);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "书库";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(582, 457);
            this.dataGridView1.TabIndex = 2;
            // 
            // borrow_button
            // 
            this.borrow_button.Location = new System.Drawing.Point(612, 658);
            this.borrow_button.Margin = new System.Windows.Forms.Padding(2);
            this.borrow_button.Name = "borrow_button";
            this.borrow_button.Size = new System.Drawing.Size(155, 29);
            this.borrow_button.TabIndex = 3;
            this.borrow_button.Text = "借出";
            this.borrow_button.UseVisualStyleBackColor = true;
            this.borrow_button.Click += new System.EventHandler(this.borrow_button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 311);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "卡号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 369);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 434);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "学号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 499);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "电话";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 562);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "班级";
            // 
            // nametxt
            // 
            this.nametxt.Location = new System.Drawing.Point(105, 369);
            this.nametxt.Margin = new System.Windows.Forms.Padding(2);
            this.nametxt.Name = "nametxt";
            this.nametxt.Size = new System.Drawing.Size(158, 25);
            this.nametxt.TabIndex = 4;
            // 
            // stuIDtxt
            // 
            this.stuIDtxt.Location = new System.Drawing.Point(105, 432);
            this.stuIDtxt.Margin = new System.Windows.Forms.Padding(2);
            this.stuIDtxt.Name = "stuIDtxt";
            this.stuIDtxt.Size = new System.Drawing.Size(158, 25);
            this.stuIDtxt.TabIndex = 5;
            // 
            // cardNumtxt
            // 
            this.cardNumtxt.Location = new System.Drawing.Point(110, 308);
            this.cardNumtxt.Margin = new System.Windows.Forms.Padding(2);
            this.cardNumtxt.Name = "cardNumtxt";
            this.cardNumtxt.ReadOnly = true;
            this.cardNumtxt.Size = new System.Drawing.Size(153, 25);
            this.cardNumtxt.TabIndex = 4;
            // 
            // phoentxt
            // 
            this.phoentxt.Location = new System.Drawing.Point(105, 499);
            this.phoentxt.Margin = new System.Windows.Forms.Padding(2);
            this.phoentxt.Name = "phoentxt";
            this.phoentxt.Size = new System.Drawing.Size(158, 25);
            this.phoentxt.TabIndex = 6;
            // 
            // classtxt
            // 
            this.classtxt.Location = new System.Drawing.Point(105, 560);
            this.classtxt.Margin = new System.Windows.Forms.Padding(2);
            this.classtxt.Name = "classtxt";
            this.classtxt.Size = new System.Drawing.Size(158, 25);
            this.classtxt.TabIndex = 7;
            // 
            // card_button
            // 
            this.card_button.Location = new System.Drawing.Point(93, 612);
            this.card_button.Margin = new System.Windows.Forms.Padding(2);
            this.card_button.Name = "card_button";
            this.card_button.Size = new System.Drawing.Size(96, 26);
            this.card_button.TabIndex = 8;
            this.card_button.Text = "读卡";
            this.card_button.UseVisualStyleBackColor = true;
            this.card_button.Click += new System.EventHandler(this.card_button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.card_button);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.classtxt);
            this.groupBox1.Controls.Add(this.cardNumtxt);
            this.groupBox1.Controls.Add(this.phoentxt);
            this.groupBox1.Controls.Add(this.stuIDtxt);
            this.groupBox1.Controls.Add(this.nametxt);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(295, 662);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "个人资料";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(42, 71);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "3-241022114Q8.jpg");
            // 
            // BorrowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 743);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.borrow_button);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BorrowForm";
            this.Text = "BorrowForm";
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button borrow_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox nametxt;
        private System.Windows.Forms.TextBox stuIDtxt;
        private System.Windows.Forms.TextBox cardNumtxt;
        private System.Windows.Forms.TextBox phoentxt;
        private System.Windows.Forms.TextBox classtxt;
        private System.Windows.Forms.Button card_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}