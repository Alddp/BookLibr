using MaterialSkin;
using MaterialSkin.Controls;
using System.Collections.Generic;

namespace BookLiber {

    public static class ThemeManager {
        private static MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        private static List<MaterialForm> managedForms = new List<MaterialForm>();
        private static int colorSchemeIndex = 0;

        public static void Initialize(MaterialForm form) {
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(form);
            managedForms.Add(form);
        }

        public static void ToggleTheme() {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK
                ? MaterialSkinManager.Themes.LIGHT
                : MaterialSkinManager.Themes.DARK;
            UpdateTheme();
        }

        private static void UpdateTheme() {
            switch (colorSchemeIndex) {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal500 : Primary.Indigo500,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal700 : Primary.Indigo700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal200 : Primary.Indigo100,
                        Accent.Pink200,
                        TextShade.WHITE);
                    break;

                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Green600,
                        Primary.Green700,
                        Primary.Green200,
                        Accent.Red100,
                        TextShade.WHITE);
                    break;

                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    break;
            }

            foreach (var form in managedForms) {
                form.Invalidate();
                form.Refresh();
            }
        }
    }
}