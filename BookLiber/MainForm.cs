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

        private void MainForm_Load(object sender, EventArgs e) {
            读卡ToolStripMenuItem_Click(sender, e);
        }

        private void 读卡ToolStripMenuItem_Click(object sender, EventArgs e) {
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is BorrowForm);
            if (existingForm != null) {
                existingForm.Activate();
                return;
            }

            CloseOtherMdiChildren(null);

            ReadCardForm readCardForm = new ReadCardForm();
            readCardForm.Visible = true;
            // 2. 设置子窗体为非顶级窗体（不独立显示）
            readCardForm.TopLevel = false;
            // 4. 设置子窗体填充 Panel
            readCardForm.Dock = DockStyle.Fill;
            // 5. 清空 Panel 的现有控件（可选，防止多个子窗体叠加）
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(readCardForm);
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

            BorrowForm borrowForm = new BorrowForm();
            borrowForm.Visible = true;
            // 2. 设置子窗体为非顶级窗体（不独立显示）
            borrowForm.TopLevel = false;
            // 4. 设置子窗体填充 Panel
            borrowForm.Dock = DockStyle.Fill;
            // 5. 清空 Panel 的现有控件（可选，防止多个子窗体叠加）
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.Controls.Add(borrowForm);
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
    }
}