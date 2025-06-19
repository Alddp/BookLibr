using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace BookLiber.SubForm {

    public partial class SettingForm : MaterialForm {
        private readonly MaterialSkinManager materialSkinManager;

        public SettingForm() {
            InitializeComponent();
            ThemeManager.Initialize(this);

            // 初始化 MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);

            // 设置RadioButton的文本
            materialRadioButton1.Text = "浅色主题";
            materialRadioButton2.Text = "深色主题";
            materialRadioButton3.Text = "跟随系统";

            // 根据当前主题设置默认选中状态
            materialRadioButton1.Checked = materialSkinManager.Theme == MaterialSkinManager.Themes.LIGHT;
            materialRadioButton2.Checked = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK;
            materialRadioButton3.Checked = false;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e) {
            if (sender is MaterialRadioButton radioButton && radioButton.Checked) {
                switch (radioButton.Name) {
                    case "materialRadioButton1": // 浅色主题
                        materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                        break;

                    case "materialRadioButton2": // 深色主题
                        materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                        break;

                    case "materialRadioButton3": // 跟随系统
                        // 获取系统主题
                        bool isDarkMode = SystemInformation.HighContrast ||
                            (DateTime.Now.Hour >= 18 || DateTime.Now.Hour < 6);
                        materialSkinManager.Theme = isDarkMode ?
                            MaterialSkinManager.Themes.DARK :
                            MaterialSkinManager.Themes.LIGHT;
                        break;
                }
            }
        }
    }
}