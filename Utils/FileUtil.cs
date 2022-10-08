using System.IO;
using System.Xml.Serialization;

namespace FIFA_Helper {
    public class FileUtil {
        private static readonly string filePath = Program.appdata + @"\settings.xml";

        public static void CreateSettingsFile() {
            if (!File.Exists(filePath)) WriteSettings(new Settings());
        }

        public static void WriteSettings(Settings settings) {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            TextWriter textWriter = new StreamWriter(filePath);
            serializer.Serialize(textWriter, settings);
            textWriter.Close();
        }

        public static Settings ReadSettings() {
            XmlSerializer deserializer = new XmlSerializer(typeof(Settings));
            Settings settings = new Settings();
            try {
                TextReader textReader = new StreamReader(filePath);
                settings = (Settings)deserializer.Deserialize(textReader);
                textReader.Close();

            }
            catch (FileNotFoundException e) {
                WriteSettings(new Settings());
                TextReader textReader = new StreamReader(filePath);
            }

            return settings;
        }


    }
}
