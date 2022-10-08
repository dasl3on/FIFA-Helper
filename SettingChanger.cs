using DustInTheWind.ConsoleTools.Controls.Menus;
using System;
using System.IO;
using System.Text;

namespace FIFA_Helper {
    internal class SettingChanger : ICommand {
        public bool IsActive => true;
        int selectedIndex;

        public SettingChanger(int selectedIndex) {
            this.selectedIndex = selectedIndex;
        }

        public void Execute() {
            Console.Clear();
            Settings settings = FileUtil.ReadSettings();
            StringBuilder sb = new StringBuilder("Ändere ");
            switch (selectedIndex) {
                case 0:
                    Console.WriteLine(sb.Append("Origin-Pfad: ").ToString());
                    string newPath = Console.ReadLine();
                    if (!File.Exists(newPath) && !String.IsNullOrEmpty(newPath)) {
                        Console.WriteLine("Datei existiert nicht. Bitte Pfad zu Origin.exe angeben.");
                        System.Threading.Thread.Sleep(5000);
                        Execute();
                    }
                    settings.OriginPath = newPath;
                    FileUtil.WriteSettings(settings);
                    break;
            }

            new SettingsView().Execute();
        }
    }
}
