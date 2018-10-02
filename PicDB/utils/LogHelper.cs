using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PicDB.utils
{
    /// <summary>
    /// A Helper class for logging (log4net)
    /// </summary>
    public static  class LogHelper
    {
        /// <summary>
        /// Returns a logger instance
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
