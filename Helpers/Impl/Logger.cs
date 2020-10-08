using Heloc.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace Heloc.Helpers
{
    public class Logger : ILogger
    {
        private const string FileEXT = ".log";
        private readonly string DatetimeFormat;
        private string LogFilename;
        private readonly object ObjLock;
        private readonly IConfigHelper ConfigHelper;
        private DateTime fileDate = DateTime.Now.Date;
        private int fileCounter = 1;

        /// <summary>
        /// Initiate an instance of SimpleLogger class constructor.
        /// If log file does not exist, it will be created automatically.
        /// </summary>
        public Logger(IConfigHelper configHelper)
        {
            ConfigHelper = configHelper;
            ObjLock = new object();
            DatetimeFormat = "yyyy-MM-dd HH:mm:ss.fff";
            CreateNewLogFile();
        }

        /// <summary>
        /// Log a DEBUG message
        /// </summary>
        /// <param name="text">Message</param>
        public void Debug(string text)
        {
            WriteFormattedLog(Enums.LogLevels.DEBUG, text);
        }

        /// <summary>
        /// Log an ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Error(Exception ex, string methodName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("================================ ERROR STARTED ===============================" + Environment.NewLine);
            sb.Append("METHOD NAME: " + methodName + Environment.NewLine);
            sb.Append("EXCEPTION: " + (ex.Message.Length <= 1000 ? ex.Message : ex.Message.Substring(0, 1000) + "...") + Environment.NewLine);
            sb.Append("INNER EXCEPTION: " + (ex.InnerException != null ? ex.InnerException.Message : string.Empty) + Environment.NewLine);
            sb.Append("STACKTRACE: " + ex.StackTrace + Environment.NewLine);
            sb.Append("================================= ERROR END ========================================");

            WriteFormattedLog(Enums.LogLevels.ERROR, sb.ToString());
        }

        /// <summary>
        /// Log a FATAL ERROR message
        /// </summary>
        /// <param name="text">Message</param>
        public void Fatal(string text)
        {
            WriteFormattedLog(Enums.LogLevels.FATAL, text);
        }

        /// <summary>
        /// Log an INFO message
        /// </summary>
        /// <param name="text">Message</param>
        public void Info(string text)
        {
            WriteFormattedLog(Enums.LogLevels.INFO, text);
        }

        /// <summary>
        /// Log a TRACE message
        /// </summary>
        /// <param name="text">Message</param>
        public void Trace(string text)
        {
            WriteFormattedLog(Enums.LogLevels.TRACE, text);
        }

        /// <summary>
        /// Log a WARNING message
        /// </summary>
        /// <param name="text">Message</param>
        public void Warning(string text)
        {
            WriteFormattedLog(Enums.LogLevels.WARNING, text);
        }

        public bool WriteLine(string text, bool append = true)
        {
            try
            {
                if (ConfigHelper.Model.IsLoggingEnabled)
                {
                    FileInfo file_info = new FileInfo(LogFilename);
                    if (file_info.Exists)
                    {
                        bool IsNewFileRequired = false;
                        if (DateTime.Now.Date > fileDate)
                        {
                            fileDate = DateTime.Now.Date;
                            fileCounter = 1;
                            IsNewFileRequired = true;
                        }
                        else if (file_info.Length > (ConfigHelper.Model.LoggingFileMaxSizeInMB * (1024 * 1024)))
                        {
                            fileCounter += 1;
                            IsNewFileRequired = true;
                        }
                        if (IsNewFileRequired) { CreateNewLogFile(); }
                    }
                    ExecuteWriteFileOperation(LogFilename, text, append);
                }
            }
            catch { return false; }
            return true;
        }
        public bool WriteInFile(string fullFilenameWithPath, string text, bool append = true)
        {
            try
            {
                ExecuteWriteFileOperation(fullFilenameWithPath, text, append);
            }
            catch { return false; }
            return true;
        }

        public void ExecuteWriteFileOperation(string fullFilenameWithPath, string text, bool append)
        {
            LogFileModel fm = new LogFileModel(fullFilenameWithPath, append, Encoding.UTF8, text);
            PrintJob(fm);
        }

        public void PrintJob(object data)
        {
            if (data != null)
            {
                lock (ObjLock)
                {
                    LogFileModel fm = (LogFileModel)data;
                    using (StreamWriter writer = new StreamWriter(path: fm.FilePath, append: fm.IsAppend, encoding: fm.EncodingType))
                    {
                        if (!string.IsNullOrEmpty(Convert.ToString(fm.TextString)))
                        {
                            writer.WriteLine(fm.TextString);
#if DEBUG
                            Console.WriteLine(fm.TextString);
#endif
                        }
                    }
                }
            }
        }
        public void WriteFormattedLog(Enums.LogLevels level, string text)
        {
            string pretext;
            switch (level)
            {
                case Enums.LogLevels.TRACE:
                    pretext = System.DateTime.Now.ToString(DatetimeFormat) + " [TRACE]   ";
                    break;
                case Enums.LogLevels.INFO:
                    pretext = System.DateTime.Now.ToString(DatetimeFormat) + " [INFO]    ";
                    break;
                case Enums.LogLevels.DEBUG:
                    pretext = System.DateTime.Now.ToString(DatetimeFormat) + " [DEBUG]   ";
                    break;
                case Enums.LogLevels.WARNING:
                    pretext = System.DateTime.Now.ToString(DatetimeFormat) + " [WARNING] ";
                    break;
                case Enums.LogLevels.ERROR:
                    pretext = System.DateTime.Now.ToString(DatetimeFormat) + " [ERROR]   ";
                    break;
                case Enums.LogLevels.FATAL:
                    pretext = System.DateTime.Now.ToString(DatetimeFormat) + " [FATAL]   ";
                    break;
                default:
                    pretext = "";
                    break;
            }
            WriteLine(pretext + text);
        }

        public void CreateNewLogFile()
        {
            LogFilename = ConfigHelper.Model.LoggingPath + Path.DirectorySeparatorChar +
                 //System.Reflection.Assembly.GetExecutingAssembly().GetName().Name +
                 "Conversion_" +
                "_" + fileDate.ToString("ddMMMyyyy") + "_" + fileCounter + FileEXT;

            // Log file header line
            if (!System.IO.File.Exists(LogFilename))
            {
                string logHeader = LogFilename + " is created.";
                WriteLine(System.DateTime.Now.ToString(DatetimeFormat) + " " + logHeader, false);
            }
        }
        public void CreateNewLogFile1()
        {
            string logPath;
            //DbService dbService = new DbService();
            //ConfigHelper.Model.DatabaseSetting = dbService.GetDataBaseSettings();
            if (!string.IsNullOrEmpty(ConfigHelper.Model.LoggingPath))
            {
                logPath = ConfigHelper.Model.LoggingPath.Trim();
            }
            else
            {
                string assemblyLocation = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Logs");
                if (!Directory.Exists(assemblyLocation))
                { Directory.CreateDirectory(assemblyLocation); }
                logPath = assemblyLocation;
            }



            LogFilename = logPath + Path.DirectorySeparatorChar +
                "Conversion_" + fileDate.ToString("ddMMMyyyy")  + FileEXT;



            // Log file header line
            if (!System.IO.File.Exists(LogFilename))
            {
                string logHeader = LogFilename + " is created.";
                WriteLine(System.DateTime.Now.ToString(DatetimeFormat) + " " + logHeader, false);
            }
        }
    }
}