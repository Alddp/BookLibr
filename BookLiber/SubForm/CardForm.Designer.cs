namespace BookLiber.SubForm {
    partial class CardForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.submit_button = new MaterialSkin.Controls.MaterialButton();
            this.picture_button = new MaterialSkin.Controls.MaterialButton();
            this.datePickerRange1 = new AntdUI.DatePickerRange();
            this.flowPanel1 = new AntdUI.FlowPanel();
            this.carNum_txb = new MaterialSkin.Controls.MaterialTextBox2();
            this.userName_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.stuId_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.phone_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.calssName_tbx = new MaterialSkin.Controls.MaterialTextBox2();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.submit_button, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.picture_button, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.datePickerRange1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.materialLabel1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.flowPanel1, 1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // materialLabel1
            // 
            resources.ApplyResources(this.materialLabel1, "materialLabel1");
            this.materialLabel1.Depth = 0;
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            // 
            // submit_button
            // 
            resources.ApplyResources(this.submit_button, "submit_button");
            this.submit_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.submit_button.Depth = 0;
            this.submit_button.HighEmphasis = true;
            this.submit_button.Icon = null;
            this.submit_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.submit_button.Name = "submit_button";
            this.submit_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.submit_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.submit_button.UseAccentColor = false;
            this.submit_button.UseVisualStyleBackColor = true;
            this.submit_button.Click += new System.EventHandler(this.submit_button_Click);
            // 
            // picture_button
            // 
            resources.ApplyResources(this.picture_button, "picture_button");
            this.picture_button.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.picture_button.Depth = 0;
            this.picture_button.HighEmphasis = true;
            this.picture_button.Icon = null;
            this.picture_button.MouseState = MaterialSkin.MouseState.HOVER;
            this.picture_button.Name = "picture_button";
            this.picture_button.NoAccentTextColor = System.Drawing.Color.Empty;
            this.picture_button.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.picture_button.UseAccentColor = false;
            this.picture_button.UseVisualStyleBackColor = true;
            this.picture_button.Click += new System.EventHandler(this.picture_button_Click);
            // 
            // datePickerRange1
            // 
            resources.ApplyResources(this.datePickerRange1, "datePickerRange1");
            this.datePickerRange1.Name = "datePickerRange1";
            // 
            // flowPanel1
            // 
            this.flowPanel1.Controls.Add(this.carNum_txb);
            this.flowPanel1.Controls.Add(this.userName_tbx);
            this.flowPanel1.Controls.Add(this.stuId_tbx);
            this.flowPanel1.Controls.Add(this.phone_tbx);
            this.flowPanel1.Controls.Add(this.calssName_tbx);
            resources.ApplyResources(this.flowPanel1, "flowPanel1");
            this.flowPanel1.Name = "flowPanel1";
            this.tableLayoutPanel1.SetRowSpan(this.flowPanel1, 2);
            // 
            // carNum_txb
            // 
            this.carNum_txb.AnimateReadOnly = false;
            this.carNum_txb.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.carNum_txb.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            resources.ApplyResources(this.carNum_txb, "carNum_txb");
            this.carNum_txb.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.carNum_txb.Depth = 0;
            this.carNum_txb.HideSelection = true;
            this.carNum_txb.LeadingIcon = null;
            this.carNum_txb.MaxLength = 32767;
            this.carNum_txb.MouseState = MaterialSkin.MouseState.OUT;
            this.carNum_txb.Name = "carNum_txb";
            this.carNum_txb.PasswordChar = '\0';
            this.carNum_txb.ReadOnly = true;
            this.carNum_txb.SelectedText = "";
            this.carNum_txb.SelectionLength = 0;
            this.carNum_txb.SelectionStart = 0;
            this.carNum_txb.ShortcutsEnabled = true;
            this.carNum_txb.TabStop = false;
            this.carNum_txb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.carNum_txb.TrailingIcon = null;
            this.carNum_txb.UseSystemPasswordChar = false;
            // 
            // userName_tbx
            // 
            this.userName_tbx.AnimateReadOnly = false;
            this.userName_tbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.userName_tbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            resources.ApplyResources(this.userName_tbx, "userName_tbx");
            this.userName_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.userName_tbx.Depth = 0;
            this.userName_tbx.HideSelection = true;
            this.userName_tbx.LeadingIcon = null;
            this.userName_tbx.MaxLength = 32767;
            this.userName_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.userName_tbx.Name = "userName_tbx";
            this.userName_tbx.PasswordChar = '\0';
            this.userName_tbx.ReadOnly = false;
            this.userName_tbx.SelectedText = "";
            this.userName_tbx.SelectionLength = 0;
            this.userName_tbx.SelectionStart = 0;
            this.userName_tbx.ShortcutsEnabled = true;
            this.userName_tbx.TabStop = false;
            this.userName_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.userName_tbx.TrailingIcon = null;
            this.userName_tbx.UseSystemPasswordChar = false;
            // 
            // stuId_tbx
            // 
            this.stuId_tbx.AnimateReadOnly = false;
            this.stuId_tbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.stuId_tbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            resources.ApplyResources(this.stuId_tbx, "stuId_tbx");
            this.stuId_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.stuId_tbx.Depth = 0;
            this.stuId_tbx.HideSelection = true;
            this.stuId_tbx.LeadingIcon = null;
            this.stuId_tbx.MaxLength = 32767;
            this.stuId_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.stuId_tbx.Name = "stuId_tbx";
            this.stuId_tbx.PasswordChar = '\0';
            this.stuId_tbx.ReadOnly = false;
            this.stuId_tbx.SelectedText = "";
            this.stuId_tbx.SelectionLength = 0;
            this.stuId_tbx.SelectionStart = 0;
            this.stuId_tbx.ShortcutsEnabled = true;
            this.stuId_tbx.TabStop = false;
            this.stuId_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stuId_tbx.TrailingIcon = null;
            this.stuId_tbx.UseSystemPasswordChar = false;
            // 
            // phone_tbx
            // 
            this.phone_tbx.AnimateReadOnly = false;
            this.phone_tbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.phone_tbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            resources.ApplyResources(this.phone_tbx, "phone_tbx");
            this.phone_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.phone_tbx.Depth = 0;
            this.phone_tbx.HideSelection = true;
            this.phone_tbx.LeadingIcon = null;
            this.phone_tbx.MaxLength = 32767;
            this.phone_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.phone_tbx.Name = "phone_tbx";
            this.phone_tbx.PasswordChar = '\0';
            this.phone_tbx.ReadOnly = false;
            this.phone_tbx.SelectedText = "";
            this.phone_tbx.SelectionLength = 0;
            this.phone_tbx.SelectionStart = 0;
            this.phone_tbx.ShortcutsEnabled = true;
            this.phone_tbx.TabStop = false;
            this.phone_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.phone_tbx.TrailingIcon = null;
            this.phone_tbx.UseSystemPasswordChar = false;
            // 
            // calssName_tbx
            // 
            this.calssName_tbx.AnimateReadOnly = false;
            this.calssName_tbx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.calssName_tbx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            resources.ApplyResources(this.calssName_tbx, "calssName_tbx");
            this.calssName_tbx.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.calssName_tbx.Depth = 0;
            this.calssName_tbx.HideSelection = true;
            this.calssName_tbx.LeadingIcon = null;
            this.calssName_tbx.MaxLength = 32767;
            this.calssName_tbx.MouseState = MaterialSkin.MouseState.OUT;
            this.calssName_tbx.Name = "calssName_tbx";
            this.calssName_tbx.PasswordChar = '\0';
            this.calssName_tbx.ReadOnly = false;
            this.calssName_tbx.SelectedText = "";
            this.calssName_tbx.SelectionLength = 0;
            this.calssName_tbx.SelectionStart = 0;
            this.calssName_tbx.ShortcutsEnabled = true;
            this.calssName_tbx.TabStop = false;
            this.calssName_tbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.calssName_tbx.TrailingIcon = null;
            this.calssName_tbx.UseSystemPasswordChar = false;
            // 
            // CardForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CardForm";
            this.Load += new System.EventHandler(this.CardForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialButton submit_button;
        private MaterialSkin.Controls.MaterialButton picture_button;
        private AntdUI.DatePickerRange datePickerRange1;
        private AntdUI.FlowPanel flowPanel1;
        private MaterialSkin.Controls.MaterialTextBox2 carNum_txb;
        private MaterialSkin.Controls.MaterialTextBox2 userName_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 stuId_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 phone_tbx;
        private MaterialSkin.Controls.MaterialTextBox2 calssName_tbx;
    }
}