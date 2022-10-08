using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Menus;
using FIFA_Helper.Exceptions;
using FIFA_Helper.Utils;
using System;

namespace FIFA_Helper {
    internal class StartOrigin : ICommand {
        public bool IsActive => true;

        public void Execute() {
            // Close Origin client for safety
            OriginUtil.KillOrigin();

            try {
                OriginUtil.StartOrigin();
            }
            catch (OriginNotFoundException e) {
                Console.Clear();
                Pause p = new Pause {
                    Text = "Pfad zu Origin wurde nicht hinterlegt. Bitte in den Programmeinstellungen ändern. \n Beliebige Taste drücken um dorthin zu gelangen."
                };
                p.Display();
                new SettingsView().Execute();
            }
        }
    }
}
