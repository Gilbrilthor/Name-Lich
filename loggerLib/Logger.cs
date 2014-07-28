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
        private StreamWriter _logFile;

        public Logger()
            : this("Log")
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Logger" /> class.
        /// </summary>
        /// <param name="logName">Name of the log.</param>
        /// <param name="logExtension">The log extension.</param>
        /// <param name="logDirectory">The log directory.</param>
        /// <param name="appendDate">if set to <c>true</c> [append date].</param>
        /// <param name="logTime">if set to <c>true</c> [log time].</param>
        /// <param name="shouldLog">if set to <c>true</c> [should log].</param>
        public Logger(string logName, string logExtension = ".txt", string logDirectory = "Logs/",
                    bool appendDate = true, bool logTime = true, bool shouldLog = true)
        {
            LogFileName = logName;
            LogFileExtension = logExtension;
            ShouldAppendDate = appendDate;
            ShouldLogTime = logTime;
            LogDirectoryName = logDirectory;
            ShouldLog = shouldLog;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the logger [should log].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [should log]; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldLog
        {
            get { return _shouldLog; }
            set
            {
                _shouldLog = value;
                if (_shouldLog)
                {
                    CreateLogFile();
                }
                else
                {
                    _logFile.Close();
                }
            }
        }

        private bool _shouldLog;

        /// <summary>
        /// Gets or sets the name of the log directory.
        /// </summary>
        /// <value>
        /// The name of the log directory.
        /// </value>
        public string LogDirectoryName { get; set; }

        /// <summary>
        /// Gets or sets the log file extension.
        /// </summary>
        /// <value>
        /// The log file extension.
        /// </value>
        public string LogFileExtension { get; set; }

        /// <summary>
        /// Gets or sets the name of the log file.
        /// </summary>
        /// <value>
        /// The name of the log file.
        /// </value>
        public string LogFileName { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [the date should be added to the line].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [date should be added]; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldAppendDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [time should be logged].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [time should be logged]; otherwise, <c>false</c>.
        /// </value>
        public bool ShouldLogTime { get; set; }

        /// <summary>
        /// Gets the log file.
        /// </summary>
        /// <value>
        /// The log file.
        /// </value>
        private StreamWriter LogFile
        {
            get
            {
                // Make sure the user actually wants to log
                if (ShouldLog && _logFile == null)
                {
                    CreateLogFile();
                }

                return _logFile;
            }
        }
        /// <summary>
        /// Logs the text as debug.
        /// </summary>
        /// <param name="text">The text to log.</param>
        public void Debug(string text)
        {
            Log("debug", text);
        }

        /// <summary>
        /// Logs the specified text as debug using the format string.
        /// </summary>
        /// <param name="textFormat">The text format.</param>
        /// <param name="args">The arguments.</param>
        public void Debug(string textFormat, params object[] args)
        {
            Debug(String.Format(textFormat, args));
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            LogFile.Close();
        }

        /// <summary>
        /// Errors the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Error(string text)
        {
            Log("error", text);
        }

        /// <summary>
        /// Logs the text as info.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Info(string text)
        {
            Log("info", text);
        }

        /// <summary>
        /// Logs the specified text as info using the format string.
        /// </summary>
        /// <param name="textFormat">The text format.</param>
        /// <param name="args">The arguments.</param>
        public void Info(string textFormat, params object[] args)
        {
            Info(String.Format(textFormat, args));
        }

        /// <summary>
        /// Logs the text at the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="text">The text.</param>
        /// <param name="levelPadding">The number of characters to pad the type with. Defaults to 5 characters.</param>
        public void Log(string level, string text, int levelPadding = 5)
        {
            // If the user doesn't want logs created, then don't log anything.
            if (!ShouldLog)
            {
                return;
            }

            var line = new StringBuilder();

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

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="printStackTrace">if set to <c>true</c> [print stack trace].</param>
        public void LogException(Exception ex, bool printStackTrace = false)
        {
            // If the user doesn't want logs created, then don't log anything.
            if (!ShouldLog)
            {
                return;
            }

            // Write the string representation
            Error(ex.ToString());

            // Write the stack trace
            if (printStackTrace)
            {
                LogFile.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Logs the specified text as a warning.
        /// </summary>
        /// <param name="text">The text.</param>
        public void Warn(string text)
        {
            Log("warn", text);
        }

        /// <summary>
        /// Builds the full name of the log file.
        /// </summary>
        /// <returns>The full path to the log file to use.</returns>
        private string BuildFullName()
        {
            // Start with the log file Directory
            var logFileFullName = new StringBuilder(LogDirectoryName);
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

        /// <summary>
        /// Creates the log directory if it doesn't exist.
        /// </summary>
        private void CreateLogDirectory()
        {
            if (!Directory.Exists(LogDirectoryName))
            {
                Directory.CreateDirectory(LogDirectoryName);
            }
        }

        /// <summary>
        /// Creates the log file.
        /// </summary>
        private void CreateLogFile()
        {

            // Make sure user wants to log
            if (!ShouldLog)
            {
                return;
            }

            CreateLogDirectory();
            _logFile = File.AppendText(BuildFullName());
            _logFile.WriteLine("===={0}====", DateTime.Now);
        }
    }
}