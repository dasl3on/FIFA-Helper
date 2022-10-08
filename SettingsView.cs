using DustInTheWind.ConsoleTools.Controls.Menus;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using FIFA_Helper.Utils;
using System;

namespace FIFA_Helper {
    internal class SettingsView : ICommand {
        public bool IsActive => true;

        public void Execute() {
            Console.Clear();
            ScrollMenu sc = new ScrollMenu {
                EraseAfterClose = false,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left
            };

            Settings settings = FileUtil.ReadSettings();
            String[] menuItems = new string[2];
            menuItems[0] = "Origin-Pfad: " + settings.OriginPath;
            menuItems[1] = "<--- zurück";
            menuItems = MenuUtil.PadMenuItems(menuItems);


            sc.AddItems(new IMenuItem[] {

                new LabelMenuItem {
                    Text = menuItems[0],
                    Command = new SettingChanger(0)
                },

                new LabelMenuItem{
                    Text = menuItems[1],
                    Command = new Program()
                }

            });
            sc.Display();

        }
    }
}
