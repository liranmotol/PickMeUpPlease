using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Utils
{
    public enum LogLevel { warning, error, info };
    public class Logger
    {
        public static void WriteToLog(LogLevel level, string msg, Exception e = null)
        {
            string tempMsg = (e != null) ? tempMsg = "\n" + e.Message + "\n" + e.StackTrace : "";
            switch (level)
            {
                case LogLevel.error:
                    System.Diagnostics.Trace.TraceError(msg + tempMsg);
                    break;
                case LogLevel.warning:
                    System.Diagnostics.Trace.TraceWarning(msg + tempMsg);
                    break;
                case LogLevel.info:
                    System.Diagnostics.Trace.TraceInformation(msg + tempMsg);
                    break;
            }
        }
    }
}