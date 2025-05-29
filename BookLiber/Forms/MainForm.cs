using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookLiber.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true; // 必须添加：启用MDI容器
        }

        // 开卡菜单
        private void 开卡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 检查是否已存在CardForm
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is CardForm);
            if (existingForm != null)
            {
                existingForm.Activate(); // 如果存在则激活
                return;
            }

            // 不存在则创建新窗体
            CardForm cardForm = new CardForm();
            cardForm.MdiParent = this;
            cardForm.Show();
        }

        // 书籍入库菜单
        private void 书籍入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is AddBookForm);
            if (existingForm != null)
            {
                existingForm.Activate();
                return;
            }

            AddBookForm addBookForm = new AddBookForm();
            addBookForm.MdiParent = this;
            addBookForm.Show();
        }

        // 还书记录菜单
        private void 还书记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is ReturnForm);
            if (existingForm != null)
            {
                existingForm.Activate();
                return;
            }

            ReturnForm returnForm = new ReturnForm();
            returnForm.MdiParent = this;
            returnForm.Show();
        }

        // 借书记录菜单
        private void 借书记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var existingForm = this.MdiChildren.FirstOrDefault(f => f is BorrowForm);
            if (existingForm != null)
            {
                existingForm.Activate();
                return;
            }

            BorrowForm borrowForm = new BorrowForm();
            borrowForm.MdiParent = this;
            borrowForm.Show();
        }
    }
}
