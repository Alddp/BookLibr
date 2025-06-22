using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using BookLiber.AdminForm;

namespace BookLiber.AdminForm {

    public partial class DataToolsForm : Form {

        private readonly Dictionary<string, string> _availableTables = new Dictionary<string, string>
        {
            {"bookshelfslot", "书架格子表"},
            {"book", "图书表"},
            {"user", "用户表"},
            {"admin", "管理员表"},
            {"borrow", "借阅记录表"},
            {"all", "所有表"}
        };

        public DataToolsForm() {
            InitializeComponent();
            LoadComboBoxes();
        }

        private void LoadComboBoxes() {
            var dataSource = _availableTables.Select(kv => new { Key = kv.Key, Value = $"{kv.Key} ({kv.Value})" }).ToList();

            // Configure generate tab
            generateTable_cbx.DataSource = new BindingSource(dataSource, null);
            generateTable_cbx.DisplayMember = "Value";
            generateTable_cbx.ValueMember = "Key";
            generateTable_cbx.SelectedIndex = _availableTables.Keys.ToList().IndexOf("all");

            // Configure import tab
            importTable_cbx.DataSource = new BindingSource(dataSource, null);
            importTable_cbx.DisplayMember = "Value";
            importTable_cbx.ValueMember = "Key";
            importTable_cbx.SelectedIndex = _availableTables.Keys.ToList().IndexOf("all");
        }

        private string GetExePath() {
            // 假设 exe 在主程序目录下
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tools", "library_tool.exe");
        }

        private void generateBrowse_btn_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Filter = "Excel文件|*.xlsx";
                sfd.FileName = generateOutputFile_tbx.Text;
                if (sfd.ShowDialog() == DialogResult.OK) {
                    generateOutputFile_tbx.Text = sfd.FileName;
                }
            }
        }

        private void importBrowse_btn_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Filter = "Excel文件|*.xlsx";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    importExcelFile_tbx.Text = ofd.FileName;
                }
            }
        }

        private void generate_btn_Click(object sender, EventArgs e) {
            string exePath = GetExePath();
            if (!File.Exists(exePath)) {
                MessageBox.Show("未找到 library_tool.exe，请确保其在程序目录下。");
                return;
            }

            string table = generateTable_cbx.SelectedValue?.ToString() ?? "all";
            int count = (int)generateCount_num.Value;
            string output = generateOutputFile_tbx.Text.Trim();
            bool toDb = generateToDb_cbx.Checked;
            bool overwrite = generateOverwrite_cbx.Checked;

            // 构建命令行参数
            var args = $"generate --table {table} --count {count} --output \"{output}\"";
            if (toDb) args += " --db";
            if (overwrite) args += " --new";

            RunProcess(exePath, args);
        }

        private void import_btn_Click(object sender, EventArgs e) {
            string exePath = GetExePath();
            if (!File.Exists(exePath)) {
                MessageBox.Show("未找到 library_tool.exe，请确保其在程序目录下。");
                return;
            }

            string table = importTable_cbx.SelectedValue?.ToString() ?? "all";
            string excel = importExcelFile_tbx.Text.Trim();
            bool toDb = importToDb_cbx.Checked;

            if (string.IsNullOrWhiteSpace(excel) || !File.Exists(excel)) {
                MessageBox.Show("请选择有效的Excel文件。");
                return;
            }

            // 构建命令行参数
            var args = $"import --table {table} --excel \"{excel}\"";
            if (toDb) args += " --db";

            RunProcess(exePath, args);
        }

        private void RunProcess(string exePath, string arguments) {
            try {
                var psi = new ProcessStartInfo {
                    FileName = exePath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    WorkingDirectory = Path.GetDirectoryName(exePath)
                };

                using (var process = Process.Start(psi)) {
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrWhiteSpace(output))
                        new OutputDialog("脚本输出", output).ShowDialog();

                    if (!string.IsNullOrWhiteSpace(error))
                        new OutputDialog("脚本错误", error).ShowDialog();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("运行脚本时出错：" + ex.Message);
            }
        }
    }
}