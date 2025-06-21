namespace BookLiber.OperForm {
    partial class SettingForm {
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialRadioButton3 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton2 = new MaterialSkin.Controls.MaterialRadioButton();
            this.materialRadioButton1 = new MaterialSkin.Controls.MaterialRadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.materialRadioButton3);
            this.panel1.Controls.Add(this.materialRadioButton2);
            this.panel1.Controls.Add(this.materialRadioButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 447);
            this.panel1.TabIndex = 0;
            // 
            // materialRadioButton3
            // 
            this.materialRadioButton3.AutoSize = true;
            this.materialRadioButton3.Depth = 0;
            this.materialRadioButton3.Location = new System.Drawing.Point(35, 101);
            this.materialRadioButton3.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton3.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton3.Name = "materialRadioButton3";
            this.materialRadioButton3.Ripple = true;
            this.materialRadioButton3.Size = new System.Drawing.Size(190, 37);
            this.materialRadioButton3.TabIndex = 5;
            this.materialRadioButton3.TabStop = true;
            this.materialRadioButton3.Text = "materialRadioButton3";
            this.materialRadioButton3.UseVisualStyleBackColor = true;
            this.materialRadioButton3.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // materialRadioButton2
            // 
            this.materialRadioButton2.AutoSize = true;
            this.materialRadioButton2.Depth = 0;
            this.materialRadioButton2.Location = new System.Drawing.Point(35, 55);
            this.materialRadioButton2.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton2.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton2.Name = "materialRadioButton2";
            this.materialRadioButton2.Ripple = true;
            this.materialRadioButton2.Size = new System.Drawing.Size(190, 37);
            this.materialRadioButton2.TabIndex = 4;
            this.materialRadioButton2.TabStop = true;
            this.materialRadioButton2.Text = "materialRadioButton2";
            this.materialRadioButton2.UseVisualStyleBackColor = true;
            this.materialRadioButton2.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // materialRadioButton1
            // 
            this.materialRadioButton1.AutoSize = true;
            this.materialRadioButton1.Depth = 0;
            this.materialRadioButton1.Location = new System.Drawing.Point(35, 18);
            this.materialRadioButton1.Margin = new System.Windows.Forms.Padding(0);
            this.materialRadioButton1.MouseLocation = new System.Drawing.Point(-1, -1);
            this.materialRadioButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRadioButton1.Name = "materialRadioButton1";
            this.materialRadioButton1.Ripple = true;
            this.materialRadioButton1.Size = new System.Drawing.Size(190, 37);
            this.materialRadioButton1.TabIndex = 3;
            this.materialRadioButton1.TabStop = true;
            this.materialRadioButton1.Text = "materialRadioButton1";
            this.materialRadioButton1.UseVisualStyleBackColor = true;
            this.materialRadioButton1.CheckedChanged += new System.EventHandler(this.RadioButton_CheckedChanged);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.StatusAndActionBar_None;
            this.Name = "SettingForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.Text = "SettingForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton3;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton2;
        private MaterialSkin.Controls.MaterialRadioButton materialRadioButton1;
    }
}