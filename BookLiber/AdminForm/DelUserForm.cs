using BookBLL;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BookLiber.AdminForm {

    public partial class DelUserForm : MaterialForm {

        public DelUserForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);
            this.Load += new EventHandler(DelUserForm_Load);
            InitializeDataGridView();
        }

        private void InitializeDataGridView() {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void DelUserForm_Load(object sender, EventArgs e) {
            comboBoxUserType.Items.Add("读者");
            comboBoxUserType.Items.Add("管理员");
            comboBoxUserType.SelectedIndex = 0;
        }

        private void comboBoxUserType_SelectedIndexChanged(object sender, EventArgs e) {
            LoadData();
        }

        private void LoadData() {
            string selectedType = comboBoxUserType.SelectedItem.ToString();
            if (selectedType == "读者") {
                LoadReaders();
            } else if (selectedType == "管理员") {
                LoadAdmins();
            }
        }

        private void LoadReaders() {
            var result = ReaderManager.GetAllReaders();
            if (result.Success) {
                dataGridView1.DataSource = result.Data;
                SetupReaderDataGridView();
            } else {
                MessageBox.Show("加载读者列表失败: " + result.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAdmins() {
            var result = AdminManager.GetAllAdmins();
            if (result.Success) {
                dataGridView1.DataSource = result.Data;
                SetupAdminDataGridView();
            } else {
                MessageBox.Show("加载管理员列表失败: " + result.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupReaderDataGridView() {
            dataGridView1.Columns["UserId"].HeaderText = "用户ID";
            dataGridView1.Columns["CardNum"].HeaderText = "卡号";
            dataGridView1.Columns["UserName"].HeaderText = "姓名";
            dataGridView1.Columns["StudentId"].HeaderText = "学号";
            dataGridView1.Columns["Phone"].HeaderText = "电话";
            dataGridView1.Columns["ClassName"].HeaderText = "班级";
            dataGridView1.Columns["Photo"].Visible = false;
            dataGridView1.Columns["StartTime"].HeaderText = "开卡时间";
            dataGridView1.Columns["EndTime"].HeaderText = "到期时间";
            dataGridView1.Columns["IsValid"].HeaderText = "是否有效";
        }

        private void SetupAdminDataGridView() {
            dataGridView1.DataSource = null; // Clear previous data
            var result = AdminManager.GetAllAdmins();
            if (result.Success) {
                dataGridView1.DataSource = result.Data;
                // Manually set column headers if needed, and hide unnecessary ones
                dataGridView1.Columns["AdminId"].HeaderText = "管理员ID";
                dataGridView1.Columns["UserName"].HeaderText = "用户名";
                dataGridView1.Columns["Phone"].HeaderText = "电话";
                dataGridView1.Columns["Type"].HeaderText = "类型";
                dataGridView1.Columns["Pwd"].Visible = false; // Always hide password
                // dataGridView1.Columns["Instance"].Visible = false;
            }
        }

        private void materialButton1_Click(object sender, EventArgs e) {
            if (dataGridView1.SelectedRows.Count == 0) {
                MessageBox.Show("请选择要删除的项。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string selectedType = comboBoxUserType.SelectedItem.ToString();
            if (selectedType == "读者") {
                DeleteReader();
            } else if (selectedType == "管理员") {
                DeleteAdmin();
            }
        }

        private void DeleteReader() {
            var cardNum = dataGridView1.SelectedRows[0].Cells["CardNum"].Value.ToString();
            var userName = dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString();

            var confirmResult = MessageBox.Show($"确定要删除读者 “{userName}”（卡号: {cardNum}）吗？\n此操作将注销该卡，但保留用户信息。", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes) {
                var deleteResult = ReaderManager.DestroyCard(cardNum);
                if (deleteResult.Success) {
                    MessageBox.Show("读者删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReaders();
                } else {
                    MessageBox.Show("删除失败: " + deleteResult.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteAdmin() {
            var adminId = dataGridView1.SelectedRows[0].Cells["AdminId"].Value.ToString();
            var userName = dataGridView1.SelectedRows[0].Cells["UserName"].Value.ToString();

            var confirmResult = MessageBox.Show($"确定要永久删除管理员 “{userName}” 吗？\n此操作不可恢复。", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes) {
                var deleteResult = AdminManager.DeleteAdminById(adminId);
                if (deleteResult.Success) {
                    MessageBox.Show("管理员删除成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAdmins();
                } else {
                    MessageBox.Show("删除失败: " + deleteResult.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void materialRefreshButton2_Click(object sender, EventArgs e) {
            // 刷新表格
            string selectedType = comboBoxUserType.SelectedItem?.ToString();
            if (selectedType == "读者") {
                LoadReaders();
            } else if (selectedType == "管理员") {
                LoadAdmins();
            }
        }
    }
}