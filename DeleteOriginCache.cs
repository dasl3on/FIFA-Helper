using DustInTheWind.ConsoleTools.Controls.Menus;
using FIFA_Helper.Utils;
using System;
using System.IO;

namespace FIFA_Helper {
    internal class DeleteOriginCache : ICommand {
        public bool IsActive => true;

        static readonly string orign_appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Origin";
        static readonly string program_data = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);


        public void Execute() {
            OriginUtil.KillOrigin();
            DeleteOriginProgramData();
            DeleteOriginAppdata();
            OriginUtil.StartOrigin();
            Program.RunMainMenu();
        }


        // Deletes all directories and files in %ProgramData%\Origin except LocalContent
        private void DeleteOriginProgramData() {
            foreach (var dir in Directory.EnumerateDirectories(program_data + @"\Origin")) {
                if (!dir.Contains("LocalContent")) {
                    Directory.Delete(dir, true);
                }
            }

            foreach (var file in Directory.EnumerateFiles(program_data + @"\Origin")) {
                File.Delete(file);
            }
        }

        // Deletes all directories from %appdata%/Origin. Settings (like notification settings, game installation folders, etc.) should be kept.
        private void DeleteOriginAppdata() {
            foreach (var dir in Directory.EnumerateDirectories(orign_appdata)) {
                Directory.Delete(dir, true);
            }

            string local_file = orign_appdata + @"\local.xml";
            if (File.Exists(local_file)) { File.Delete(local_file); }
        }
    }
}
