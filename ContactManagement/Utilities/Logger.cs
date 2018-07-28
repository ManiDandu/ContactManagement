using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace ContactManagement.Utilities
{

    public static class Logger
    {
        public static void LogInfo(string logMessage)
        {
            try
            {
                bool isInfoLoggingEnabled = Convert.ToBoolean(ConfigurationManager.AppSettings["InfoLoggingEnabled"].ToString());
                if (isInfoLoggingEnabled)
                {
                    string logDirectory = ConfigurationManager.AppSettings["LogDirectory"].ToString();
                    string logFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();
                    string logFilePath = logDirectory + DateTime.Now.ToString("MMddyyyy") + "_" + logFileName;

                    if (!Directory.Exists(logDirectory))
                    {
                        Directory.CreateDirectory(logDirectory);
                    }
                    using (StreamWriter sw = File.AppendText(logFilePath))
                    {
                        sw.WriteLine(logMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
            }
        }

        public static void LogException(Exception ex)
        {
            try
            {
                string logDirectory = ConfigurationManager.AppSettings["LogDirectory"].ToString();
                string logFileName = ConfigurationManager.AppSettings["LogFileName"].ToString();
                string logFilePath = logDirectory + DateTime.Now.ToString("MMddyyyy") + "_" + logFileName;

                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }
                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine(string.Format("Exception Logging :: Time :: {0} :: Exception :: {1} :: StackTrace :: {2} ", DateTime.Now, ex.Message, ex.StackTrace));
                    sw.WriteLine(Environment.NewLine);
                }
            }
            catch (Exception e)
            {

            }

        }
    }
}


