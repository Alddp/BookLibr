using BookLiber.MainWindow;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BookLiber.Forms {

    public partial class MainForm : Form {

        public MainForm() {
            InitializeComponent();
            this.IsMdiContainer = true; // 必须添加：启用MDI容器
        }

        // 通用方法：关闭所有其他MDI子窗体
        private void CloseOtherMdiChildren(Form currentForm) {
            foreach (Form childForm in this.MdiChildren) {
                if (childForm != currentForm && !childForm.IsDisposed) {
                    childForm.Close(); // 关闭其他窗体
                }
            }
        }

        // 开卡菜单
        private void 开卡ToolStripMenuItem_Click(object sender, EventArgs e) {
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is CardForm);
            if (existingForm != null) {
                existingForm.Activate();
                return;
            }

            CardForm cardForm = new CardForm();
            cardForm.Visible = true;
            // 2. 设置子窗体为非顶级窗体（不独立显示）
            cardForm.TopLevel = false;
            // 4. 设置子窗体填充 Panel
            cardForm.Dock = DockStyle.Fill;
            // 5. 清空 Panel 的现有控件（可选，防止多个子窗体叠加）
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(cardForm);

            // 创建新窗体前关闭其他窗体
            //CloseOtherMdiChildren(null);

            //CardForm cardForm = new CardForm();
            //cardForm.MdiParent = this;
            //cardForm.Show();
        }

        // 书籍入库菜单
        private void 书籍入库ToolStripMenuItem_Click(object sender, EventArgs e) {
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is AddBookForm);
            if (existingForm != null) {
                existingForm.Activate();
                return;
            }

            CloseOtherMdiChildren(null);

            AddBookForm addBookForm = new AddBookForm();
            addBookForm.Visible = true;
            // 2. 设置子窗体为非顶级窗体（不独立显示）
            addBookForm.TopLevel = false;
            // 4. 设置子窗体填充 Panel
            addBookForm.Dock = DockStyle.Fill;
            // 5. 清空 Panel 的现有控件（可选，防止多个子窗体叠加）
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(addBookForm);
        }

        // 还书记录菜单
        private void 还书记录ToolStripMenuItem_Click(object sender, EventArgs e) {
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is ReturnForm);
            if (existingForm != null) {
                existingForm.Activate();
                return;
            }

            CloseOtherMdiChildren(null);

            ReturnForm returnForm = new ReturnForm();
            returnForm.Visible = true;
            // 2. 设置子窗体为非顶级窗体（不独立显示）
            returnForm.TopLevel = false;
            // 4. 设置子窗体填充 Panel
            returnForm.Dock = DockStyle.Fill;
            // 5. 清空 Panel 的现有控件（可选，防止多个子窗体叠加）
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(returnForm);
        }

        // 借书记录菜单
        private void 借书记录ToolStripMenuItem_Click(object sender, EventArgs e) {
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is BorrowForm);
            if (existingForm != null) {
                existingForm.Activate();
                return;
            }

            CloseOtherMdiChildren(null);

            BorrowForm1 borrowForm = new BorrowForm1();
            borrowForm.Visible = true;
            // 2. 设置子窗体为非顶级窗体（不独立显示）
            borrowForm.TopLevel = false;
            // 4. 设置子窗体填充 Panel
            borrowForm.Dock = DockStyle.Fill;
            // 5. 清空 Panel 的现有控件（可选，防止多个子窗体叠加）
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(borrowForm);
        }

        private void button1_Click(object sender, EventArgs e) {
        }

        private void pictureBox1_Click(object sender, EventArgs e) {
        }

        private void read_button_Click(object sender, EventArgs e) {
        }
    }
}