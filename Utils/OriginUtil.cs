using FIFA_Helper.Exceptions;
using System;
using System.Diagnostics;

namespace FIFA_Helper.Utils {
    internal class OriginUtil {


        // Kills all Origin client processes foo
        public static void KillOrigin() {
            foreach (var process in Process.GetProcessesByName("Origin")) {
                string origin_path = process.MainModule.FileName;
                Settings settings = FileUtil.ReadSettings();
                if (String.IsNullOrEmpty(settings.OriginPath) && !String.IsNullOrEmpty(origin_path)) {
                    settings.OriginPath = origin_path;
                    FileUtil.WriteSettings(settings);
                }
                process.Kill();
            }

            foreach (var process in Process.GetProcessesByName("OriginWebHelperService")) {
                process.Kill();
            }

            foreach (var process in Process.GetProcessesByName("OriginClientService")) {
                process.Kill();
            }
        }

        // Starts Origin client
        public static void StartOrigin() {
            Settings settings = FileUtil.ReadSettings();
            if (!String.IsNullOrEmpty(settings.OriginPath)) {
                Process.Start(settings.OriginPath);
            } else {
                throw new OriginNotFoundException();
            }
        }
    }
}
