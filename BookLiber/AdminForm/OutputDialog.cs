using System;
using System.Windows.Forms;

namespace BookLiber.AdminForm {
    public partial class OutputDialog : Form {
        public OutputDialog(string title, string content) {
            InitializeComponent();
            this.Text = title;
            this.outputTextBox.Text = content;
        }
    }
}