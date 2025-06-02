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

            // 创建新窗体前关闭其他窗体
            CloseOtherMdiChildren(null);

            CardForm cardForm = new CardForm();
            cardForm.MdiParent = this;
            cardForm.Show();
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
            addBookForm.MdiParent = this;
            addBookForm.Show();
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
            returnForm.MdiParent = this;
            returnForm.Show();
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
            borrowForm.MdiParent = this;
            borrowForm.Show();
        }
    }
}