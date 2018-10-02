using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicDB
{
    /// <summary>
    /// This is a helper class, which contains the information of the config file
    /// </summary>
    public static class GlobalInformation
    {
        /// <summary>
        /// The connection string for the database
        /// </summary>
        public static string ConnectionString;
        /// <summary>
        /// Path to the pictures
        /// </summary>
        public static string Path;
        /// <summary>
        /// Path where reports are being stored
        /// </summary>
        public static string ReportPath;
        /// <summary>
        /// Reads the config file.
        /// </summary>
        public static void ReadConfigFile()
        {
            var dict = new Dictionary<string, string>();
            var text = System.IO.File.ReadAllLines("config.txt"); //Standart Pfad zum .exe Verzeichnis vom Programm
            foreach (var s in text)
            {
                var splitted = s.Split(',');
                if (splitted.Length == 2) dict.Add(splitted[0], splitted[1]);
                else throw new ArgumentNullException("Config-File corrupted!");
            }

            ConnectionString = dict["connectionString"];
            Path = dict["path"];
            ReportPath = dict["reportPath"];
        }
    }
}
