using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AboutBimstarter
{
    public enum TlsVersion { Default, Tls1, Tls11, Tls12 };

    [Serializable]
    public class Settings
    {
        private static string configPath;


        public TlsVersion tlsVersion = TlsVersion.Default;

        public Settings()
        {
        }


        public static Settings Load()
        {
            string appdataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string rbspath = Path.Combine(appdataPath, "bim-starter");
            if (!Directory.Exists(rbspath)) Directory.CreateDirectory(rbspath);
            string solutionName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            string localFolder = Path.Combine(rbspath, solutionName);
            if (!Directory.Exists(localFolder)) Directory.CreateDirectory(localFolder);
            configPath = Path.Combine(localFolder, "config.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            Settings cfg = null;
            bool checkCfgFile = File.Exists(configPath);
            if (checkCfgFile)
            {
                using (StreamReader reader = new StreamReader(configPath))
                {
                    try
                    {
                        cfg = (Settings)serializer.Deserialize(reader);
                    }
                    catch
                    {
                        cfg = new Settings();
                    }
                    if (cfg == null)
                    {
                        throw new Exception("Failed to serialize: " + configPath);
                    }
                }
            }
            else
            {
                cfg = new Settings();
            }

            return cfg;
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            if (File.Exists(configPath)) File.Delete(configPath);
            using (FileStream writer = new FileStream(configPath, FileMode.OpenOrCreate))
            {
                serializer.Serialize(writer, this);
            }
        }
    }
}
