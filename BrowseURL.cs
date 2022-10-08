using DustInTheWind.ConsoleTools.Controls.Menus;
using System;

namespace FIFA_Helper {
    internal class BrowseURL : ICommand {
        public bool IsActive => true;
        private string url;
        private Type calledBy;

        public BrowseURL(string url, Type calledBy) {
            this.url = url;
            this.calledBy = calledBy;
        }

        public void Execute() {
            System.Diagnostics.Process.Start(url);
            ICommand instance = (ICommand)Activator.CreateInstance(calledBy);
            instance.Execute();
        }

    }
}
