using DustInTheWind.ConsoleTools.Controls.Menus;
using DustInTheWind.ConsoleTools.Controls.Menus.MenuItems;
using System;

namespace FIFA_Helper {
    internal class ProgramInfo : ICommand {
        public bool IsActive => true;

        public void Execute() {
            Console.Clear();
            Console.WriteLine("                                                  \r\n                       //                         \r\n                   ///// ..                       \r\n                 ////.&&&&&&&.                    \r\n              //////.&&&&%%&&&&/(//               \r\n            /////////.&%&&&&%%&&./////            \r\n           ////////////&&&%&&&&*&&,/////          \r\n         ///////////////.&&.@@#@@@@./////         \r\n         ///////(////     .@@@@@@#@@..////        \r\n        ///////////        ..@@#@@@@#.%////       \r\n        ///////////          ..@@@@@.&&&.//       \r\n        ///////////            &&&&&&&&%&&/       \r\n         ////////////         //.&&&&%&%&&&.      \r\n         *////////////////////////(&&&&&%&&.      \r\n           ////////////////////////.&&&&&.        \r\n             //////////////////////////           \r\n                (///////(///////(////             \r\n                       ///////////                \r\n                           /////                  \r\n                          //                      ");


            ScrollMenu sc = new ScrollMenu {
                EraseAfterClose = false,
                HorizontalAlignment = DustInTheWind.ConsoleTools.Controls.HorizontalAlignment.Left

            };

            sc.AddItems(new IMenuItem[] {

                new LabelMenuItem {
                    Text = "FIFA-Helper by dasl3on          ",
                    Command = new BrowseURL("https://github.com/dasl3on/FIFA-Helper", this.GetType())
                },

                new LabelMenuItem {
                    Text = "--- Verwendete Bibliotheken --- ",
                },

                new LabelMenuItem{
                    Text = "ConsoleTools                    ",
                    Command = new BrowseURL("https://github.com/lastunicorn/ConsoleTools", this.GetType())
                },

                new LabelMenuItem{
                    Text = "                                ",
                },

                new LabelMenuItem{
                    Text = "<--- zurück                     ",
                    Command = new Program()
                }

            });
            sc.Display();
        }
    }
}
