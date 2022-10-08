using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Menus;
using DustInTheWind.ConsoleTools.Controls.Spinners;
using System;
using System.IO;
using System.Net;

namespace FIFA_Helper {
    internal class PlactWrapper : ICommand {
        static readonly string download_url = "https://anticheat.proleague.de/ProLeagueClient.exe";
        static readonly string download_folder = Program.appdata + @"\PlactWrapper\";
        static readonly string application_name = "ProLeagueClient.exe";

        bool ICommand.IsActive => true;

        public async void Execute() {
            Console.Clear();
            Spinner.Run(() => {
                if (!Directory.Exists(download_folder)) {
                    Directory.CreateDirectory(download_folder);
                    try {
                        System.Diagnostics.Process.Start("powershell.exe", "Add-MpPreference -ExclusionPath " + download_folder);
                    }
                    catch {
                        Pause p = new Pause {
                            Text = "Ordner \"" + download_folder + "\" konnte nicht als Ausnahme hinzugefügt werden. Es könnten Probleme mit dem Antivirenprogramm geben. \n Beliebige Taste drücken..."
                        };
                        p.Display();
                    }
                }
                DownloadPlact();
            });

            System.Diagnostics.Process.Start(download_folder + application_name);
        }

        private void DownloadPlact() {
            WebClient wc = new WebClient();
            wc.DownloadFile(new System.Uri(download_url), download_folder + application_name);
        }

    }
}
