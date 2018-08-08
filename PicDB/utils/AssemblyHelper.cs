using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PicDB.utils
{
    class AssemblyHelper
    {
        public static string AssemblyFolderPath
        {
            get;
            private set;
        }

        public static string PictureFolderPath
        {
            get;
            private set;
        }
        
        static AssemblyHelper()
        {
            AssemblyFolderPath = GetPathToAssemblyFolder();
            PictureFolderPath = GetPathToPictures();
        }

        private static string GetPathToAssemblyFolder()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string pathToFolder = assemblyPath.Replace("\\PicDB.exe", "");
            return pathToFolder;
        }

        private static string GetPathToPictures()
        {
            return AssemblyFolderPath + "\\Pictures";
        }
    }
}
