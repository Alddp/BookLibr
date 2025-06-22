namespace BookLiber.AdminForm {
    partial class DataToolsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generate = new System.Windows.Forms.TabPage();
            this.generate_btn = new System.Windows.Forms.Button();
            this.generateOverwrite_cbx = new System.Windows.Forms.CheckBox();
            this.generateToDb_cbx = new System.Windows.Forms.CheckBox();
            this.generateBrowse_btn = new System.Windows.Forms.Button();
            this.generateOutputFile_tbx = new System.Windows.Forms.TextBox();
            this.generateCount_num = new System.Windows.Forms.NumericUpDown();
            this.materialLabel2 = new System.Windows.Forms.Label();
            this.generateTable_cbx = new System.Windows.Forms.ComboBox();
            this.materialLabel1 = new System.Windows.Forms.Label();
            this.import = new System.Windows.Forms.TabPage();
            this.import_btn = new System.Windows.Forms.Button();
            this.importToDb_cbx = new System.Windows.Forms.CheckBox();
            this.importBrowse_btn = new System.Windows.Forms.Button();
            this.importExcelFile_tbx = new System.Windows.Forms.TextBox();
            this.importTable_cbx = new System.Windows.Forms.ComboBox();
            this.materialLabel3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.generate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generateCount_num)).BeginInit();
            this.import.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generate);
            this.tabControl1.Controls.Add(this.import);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // generate
            // 
            this.generate.Controls.Add(this.generate_btn);
            this.generate.Controls.Add(this.generateOverwrite_cbx);
            this.generate.Controls.Add(this.generateToDb_cbx);
            this.generate.Controls.Add(this.generateBrowse_btn);
            this.generate.Controls.Add(this.generateOutputFile_tbx);
            this.generate.Controls.Add(this.generateCount_num);
            this.generate.Controls.Add(this.materialLabel2);
            this.generate.Controls.Add(this.generateTable_cbx);
            this.generate.Controls.Add(this.materialLabel1);
            this.generate.Location = new System.Drawing.Point(4, 25);
            this.generate.Name = "generate";
            this.generate.Padding = new System.Windows.Forms.Padding(3);
            this.generate.Size = new System.Drawing.Size(792, 421);
            this.generate.TabIndex = 0;
            this.generate.Text = "生成数据";
            this.generate.UseVisualStyleBackColor = true;
            // 
            // generate_btn
            // 
            this.generate_btn.Location = new System.Drawing.Point(341, 290);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(98, 36);
            this.generate_btn.TabIndex = 8;
            this.generate_btn.Text = "生成";
            this.generate_btn.UseVisualStyleBackColor = true;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // generateOverwrite_cbx
            // 
            this.generateOverwrite_cbx.AutoSize = true;
            this.generateOverwrite_cbx.Location = new System.Drawing.Point(40, 219);
            this.generateOverwrite_cbx.Name = "generateOverwrite_cbx";
            this.generateOverwrite_cbx.Size = new System.Drawing.Size(119, 19);
            this.generateOverwrite_cbx.TabIndex = 7;
            this.generateOverwrite_cbx.Text = "覆盖已有文件";
            this.generateOverwrite_cbx.UseVisualStyleBackColor = true;
            // 
            // generateToDb_cbx
            // 
            this.generateToDb_cbx.AutoSize = true;
            this.generateToDb_cbx.Location = new System.Drawing.Point(40, 182);
            this.generateToDb_cbx.Name = "generateToDb_cbx";
            this.generateToDb_cbx.Size = new System.Drawing.Size(104, 19);
            this.generateToDb_cbx.TabIndex = 6;
            this.generateToDb_cbx.Text = "写入数据库";
            this.generateToDb_cbx.UseVisualStyleBackColor = true;
            // 
            // generateBrowse_btn
            // 
            this.generateBrowse_btn.Location = new System.Drawing.Point(623, 110);
            this.generateBrowse_btn.Name = "generateBrowse_btn";
            this.generateBrowse_btn.Size = new System.Drawing.Size(100, 28);
            this.generateBrowse_btn.TabIndex = 5;
            this.generateBrowse_btn.Text = "保存为...";
            this.generateBrowse_btn.UseVisualStyleBackColor = true;
            this.generateBrowse_btn.Click += new System.EventHandler(this.generateBrowse_btn_Click);
            // 
            // generateOutputFile_tbx
            // 
            this.generateOutputFile_tbx.Location = new System.Drawing.Point(40, 112);
            this.generateOutputFile_tbx.Name = "generateOutputFile_tbx";
            this.generateOutputFile_tbx.Size = new System.Drawing.Size(564, 25);
            this.generateOutputFile_tbx.TabIndex = 4;
            this.generateOutputFile_tbx.Text = "library_data.xlsx";
            // 
            // generateCount_num
            // 
            this.generateCount_num.Location = new System.Drawing.Point(484, 48);
            this.generateCount_num.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.generateCount_num.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.generateCount_num.Name = "generateCount_num";
            this.generateCount_num.Size = new System.Drawing.Size(120, 25);
            this.generateCount_num.TabIndex = 3;
            this.generateCount_num.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Location = new System.Drawing.Point(481, 26);
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(147, 15);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "生成数量 (1-10000)";
            // 
            // generateTable_cbx
            // 
            this.generateTable_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.generateTable_cbx.FormattingEnabled = true;
            this.generateTable_cbx.Location = new System.Drawing.Point(40, 48);
            this.generateTable_cbx.Name = "generateTable_cbx";
            this.generateTable_cbx.Size = new System.Drawing.Size(359, 23);
            this.generateTable_cbx.TabIndex = 0;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Location = new System.Drawing.Point(37, 26);
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(67, 15);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "表名选择";
            // 
            // import
            // 
            this.import.Controls.Add(this.import_btn);
            this.import.Controls.Add(this.importToDb_cbx);
            this.import.Controls.Add(this.importBrowse_btn);
            this.import.Controls.Add(this.importExcelFile_tbx);
            this.import.Controls.Add(this.importTable_cbx);
            this.import.Controls.Add(this.materialLabel3);
            this.import.Location = new System.Drawing.Point(4, 25);
            this.import.Name = "import";
            this.import.Padding = new System.Windows.Forms.Padding(3);
            this.import.Size = new System.Drawing.Size(792, 421);
            this.import.TabIndex = 1;
            this.import.Text = "导入数据";
            this.import.UseVisualStyleBackColor = true;
            // 
            // import_btn
            // 
            this.import_btn.Location = new System.Drawing.Point(351, 290);
            this.import_btn.Name = "import_btn";
            this.import_btn.Size = new System.Drawing.Size(98, 36);
            this.import_btn.TabIndex = 5;
            this.import_btn.Text = "导入";
            this.import_btn.UseVisualStyleBackColor = true;
            this.import_btn.Click += new System.EventHandler(this.import_btn_Click);
            // 
            // importToDb_cbx
            // 
            this.importToDb_cbx.AutoSize = true;
            this.importToDb_cbx.Location = new System.Drawing.Point(40, 182);
            this.importToDb_cbx.Name = "importToDb_cbx";
            this.importToDb_cbx.Size = new System.Drawing.Size(104, 19);
            this.importToDb_cbx.TabIndex = 4;
            this.importToDb_cbx.Text = "写入数据库";
            this.importToDb_cbx.UseVisualStyleBackColor = true;
            // 
            // importBrowse_btn
            // 
            this.importBrowse_btn.Location = new System.Drawing.Point(623, 24);
            this.importBrowse_btn.Name = "importBrowse_btn";
            this.importBrowse_btn.Size = new System.Drawing.Size(100, 28);
            this.importBrowse_btn.TabIndex = 3;
            this.importBrowse_btn.Text = "浏览...";
            this.importBrowse_btn.UseVisualStyleBackColor = true;
            this.importBrowse_btn.Click += new System.EventHandler(this.importBrowse_btn_Click);
            // 
            // importExcelFile_tbx
            // 
            this.importExcelFile_tbx.Location = new System.Drawing.Point(40, 26);
            this.importExcelFile_tbx.Name = "importExcelFile_tbx";
            this.importExcelFile_tbx.Size = new System.Drawing.Size(564, 25);
            this.importExcelFile_tbx.TabIndex = 2;
            // 
            // importTable_cbx
            // 
            this.importTable_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.importTable_cbx.FormattingEnabled = true;
            this.importTable_cbx.Location = new System.Drawing.Point(40, 112);
            this.importTable_cbx.Name = "importTable_cbx";
            this.importTable_cbx.Size = new System.Drawing.Size(359, 23);
            this.importTable_cbx.TabIndex = 0;
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Location = new System.Drawing.Point(37, 90);
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(67, 15);
            this.materialLabel3.TabIndex = 1;
            this.materialLabel3.Text = "表名选择";
            // 
            // DataToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "DataToolsForm";
            this.Text = "数据工具";
            this.tabControl1.ResumeLayout(false);
            this.generate.ResumeLayout(false);
            this.generate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.generateCount_num)).EndInit();
            this.import.ResumeLayout(false);
            this.import.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generate;
        private System.Windows.Forms.TabPage import;
        private System.Windows.Forms.ComboBox generateTable_cbx;
        private System.Windows.Forms.Label materialLabel1;
        private System.Windows.Forms.Label materialLabel2;
        private System.Windows.Forms.NumericUpDown generateCount_num;
        private System.Windows.Forms.TextBox generateOutputFile_tbx;
        private System.Windows.Forms.Button generateBrowse_btn;
        private System.Windows.Forms.CheckBox generateToDb_cbx;
        private System.Windows.Forms.CheckBox generateOverwrite_cbx;
        private System.Windows.Forms.Button generate_btn;
        private System.Windows.Forms.ComboBox importTable_cbx;
        private System.Windows.Forms.Label materialLabel3;
        private System.Windows.Forms.TextBox importExcelFile_tbx;
        private System.Windows.Forms.Button importBrowse_btn;
        private System.Windows.Forms.CheckBox importToDb_cbx;
        private System.Windows.Forms.Button import_btn;
    }
}