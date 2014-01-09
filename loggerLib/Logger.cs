using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerLib
{
    public class Logger : IDisposable
    {
        public string LogFileName { get; set; }

        public string LogFileExtension { get; set; }

        public bool ShouldAppendDate { get; set; }

        public bool ShouldLogTime { get; set; }

        private StreamWriter logFile;

        private StreamWriter LogFile
        {
            get
            {
                if (logFile == null)
                {
                    createLogFile();
                }

                return logFile;
            }
        }

        public Logger()
            : this("Log")
        { }

        public Logger(string logName, string logExtension = ".txt", string logDirectory = "Logs/",
            bool appendDate = true, bool logTime = true)
        {
            LogFileName = logName;
            LogFileExtension = logExtension;
            ShouldAppendDate = appendDate;
            ShouldLogTime = logTime;
            LogDirectoryName = logDirectory;
        }

        private void createLogFile()
        {
            createLogDirectory();
            logFile = File.AppendText(buildFullName());
            logFile.WriteLine("===={0}====", DateTime.Now);
        }

        public string LogDirectoryName { get; set; }

        private void createLogDirectory()
        {
            if (!Directory.Exists(LogDirectoryName))
            {
                Directory.CreateDirectory(LogDirectoryName);
            }
        }

        private string buildFullName()
        {
            // Start with the log file Directory
            StringBuilder logFileFullName = new StringBuilder(LogDirectoryName);
            // Append the Log file name
            logFileFullName.Append(LogFileName);
            // Append the date if wanted
            if (ShouldAppendDate)
            {
                // Remove any '/' to keep file system from complaining, Replacing it with '_'
                logFileFullName.Append(DateTime.Today.ToShortDateString().Replace('/', '_'));
            }
            // Add the extension to the end
            logFileFullName.Append(LogFileExtension);
            return logFileFullName.ToString();
        }

        public void Log(string level, string text, int levelPadding = 5)
        {
            StringBuilder line = new StringBuilder();

            // Start by appending the time
            line.Append(DateTime.Now.ToString().PadRight(19));
            // Add the level to the line
            line.AppendFormat("[{0}]", level.PadRight(levelPadding));
            // Add the text to the end
            line.Append(text);
            // Write it to the log file
            LogFile.WriteLine(line.ToString());
            LogFile.Flush();
        }

        public void Info(string text)
        {
            Log("info", text);
        }

        public void Info(string textFormat, params object[] args)
        {
            Info(String.Format(textFormat, args));
        }

        public void Warn(string text)
        {
            Log("warn", text);
        }

        public void Debug(string text)
        {
            Log("debug", text);
        }

        public void Debug(string textFormat, params object[] args)
        {
            Debug(String.Format(textFormat, args));
        }

        public void Error(string text)
        {
            Log("error", text);
        }

        public void LogException(Exception ex, bool printStackTrace = false)
        {
            // Write the string representation
            Error(ex.ToString());

            // Write the stack trace
            if (printStackTrace)
            {
                LogFile.WriteLine(ex.StackTrace);
            }
        }

        public void Dispose()
        {
            LogFile.Close();
        }
    }
}