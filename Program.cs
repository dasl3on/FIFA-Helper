using DustInTheWind.ConsoleTools.Controls.Menus;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using FIFA_Helper.Utils;
using System;
using System.IO;

namespace FIFA_Helper {
    internal class Program : ICommand {
        public bool IsActive => true;
        public static readonly string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\FIFA-Helper";

        static void Main(string[] args) {
            if (!Directory.Exists(appdata)) { Directory.CreateDirectory(appdata); }
            FileUtil.CreateSettingsFile();
            RunMainMenu();
        }

        public void Execute() {
            RunMainMenu();
        }

        public static void RunMainMenu() {
            Console.Clear();
            ScrollMenu sc = new ScrollMenu {
                EraseAfterClose = true,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left

            };

            string[] menuTexts = new string[] {
                "PLACT",
                "Starte Origin (neu) als Administrator",
                "Lösche Origin Cache",
                "EA-Verbindungsqualtiätsbericht",
                "Einstellungen",
                "Programminfo",
                "Programm beenden"
            };
            menuTexts = MenuUtil.PadMenuItems(menuTexts);


            sc.AddItems(new IMenuItem[] {

                new LabelMenuItem {
                    Text = menuTexts[0],
                    Command = new PlactWrapper()
                },

                new LabelMenuItem {
                    Text = menuTexts[1],
                    Command = new StartOrigin()
                },

                new LabelMenuItem {
                    Text = menuTexts[2],
                    Command = new DeleteOriginCache()
                },

                new LabelMenuItem {
                    Text = menuTexts[3],
                    Command = new BrowseURL("https://help.ea.com/de/ea-connection-quality-report/", typeof(Program))
                },

                new LabelMenuItem {
                    Text = menuTexts[4],
                    Command = new SettingsView()
                },

                new LabelMenuItem{
                    Text = menuTexts[5],
                    Command = new ProgramInfo()
                },

                new LabelMenuItem {
                    Text = menuTexts[6]
                }

            });
            sc.Display();
        }
    }
}
