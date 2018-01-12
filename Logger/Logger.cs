using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logger
{
    public enum ConsoleOutput
    {
        DISABLED = 0,
        ENABLED = 1
    }

    [Flags]
    public enum LogLevel
    {
        Debug = 0x01,
        Info = 0x02,
        Warning = 0x04,
        Error = 0x08,

        AuditTrail = 0x10,
        Mail = 0x20,
        Alarm = 0x40,
    }

    public class Log
    {
        #region Private members
        public static SortedList<Int64, FileInfo> logFilesSortedList = new System.Collections.Generic.SortedList<Int64, FileInfo>();

        private static string conString;

        private static ILog Logging = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string configurationFilePath;
        private const string DataLogFolder = "C:\\MyTerm\\Log";
        private const string dateFormat = "{dd/MM/yyyy HH:mm:ss,fff}";
        private static bool testingMode = false;
        private static bool isLogConfigured = false;

        // Pattern for every log line
        private static string DEBUG_PATTERN_FORMAT = String.Format("%date{0} [%thread] %-5level %location (%file:%line) - %message %exception %newline", dateFormat);
        private static string INFO_PATTERN_FORMAT = String.Format("%date{0} [%thread] %-5level - %message %exception %newline", dateFormat);
        private const string MAX_FILESIZE = "10MB";

        public static long LogFolderSizeLimit = 10240;
        public static string LogDataPath { get; set; }
        public static bool SenseQaMode { get; set; }

        #endregion 

        #region Getters/Setters
        static Log()
        {
            if (!Directory.Exists(DataLogFolder))
            {
                Directory.CreateDirectory(DataLogFolder);
            }

            ConfigureFromCode(DataLogFolder);
        }
     
        public static string SetHeaderFormat()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                return String.Format("Version: {0, 9}\r\nOS: {1, 40}\r\nApplication: {2}\r\nStarted: {3, 23}\r\n \r\n", "", Environment.OSVersion.VersionString, assembly.GetName().Name, DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy"));
            }
            else
            {
                return String.Format("Version: 1.0 - WebClient MVC platform");
            }
        }

        #endregion

        #region Configure log

        /// <summary>
        /// Configure log from code with/without logPath
        /// </summary>
        /// <param name="logPath"></param>
        public static void ConfigureFromCode(string logPath = null)
        {
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

            PatternLayout patternLayout = new PatternLayout();
            patternLayout.Header = SetHeaderFormat();
            patternLayout.ConversionPattern = INFO_PATTERN_FORMAT;

            patternLayout.ActivateOptions();

            RollingFileAppender roller = new RollingFileAppender();
            roller.AppendToFile = true;

            if (logPath != null)
            {
                roller.File = String.Format(@"{0}.log", Path.Combine(logPath, SetLogFilename()));
            }
            else
            {
                string assemblyName = String.Empty;
                Assembly assembly = Assembly.GetEntryAssembly();
                if (assembly != null)
                {
                    assemblyName = assembly.GetName().Name;
                }
                else
                {
                    assemblyName = "WebClientMVC";
                }

                string dataLogPath = logPath;
                roller.File = String.Format(@"{0}.log", Path.Combine(dataLogPath, SetLogFilename()));
            }

            roller.Layout = patternLayout;
            roller.RollingStyle = RollingFileAppender.RollingMode.Composite;
            roller.MaxSizeRollBackups = 5;

            if (LogFolderSizeLimit > 0)
            {
                roller.MaximumFileSize = LogFolderSizeLimit.ToString() + "KB";
            }
            else
            {
                roller.MaximumFileSize = MAX_FILESIZE;
            }

            roller.StaticLogFileName = true;
            roller.ActivateOptions();
            hierarchy.Root.AddAppender(roller);
            hierarchy.Root.Level = Level.Info;
            hierarchy.Configured = true;
        }

        public static string SetLogFilename()
        {
            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
            {
                return String.Format("{0}{1}", assembly.GetName().Name, DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            }
            else
            {
                return String.Format("{0}{1}", "MyTerm", DateTime.Now.ToString("yyyyMMdd_HHmmss"));
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">string</param>
        /// <param name="level">enum LogLevel</param>
        /// <param name="exception">Exception</param>
        /// <param name="consoleOutput">true or false</param>
        /// <param name="softwareDiagnostic">true or false</param>
        /// <param name="sender"></param>
        public static void Write(object message, LogLevel level = LogLevel.Info, Exception exception = null, ConsoleOutput consoleOutput = ConsoleOutput.ENABLED, bool softwareDiagnostic = false, [CallerMemberName]string sender = "")
        {
            try
            {
                string diagnosticStr = String.Empty;
                string messageFormat = "";

                messageFormat = String.Format("{0} - {1} {2}", sender, message, diagnosticStr);

                // ERROR
                if (level.HasFlag(LogLevel.Error))
                {

                    if (exception == null)
                        Logging.Error(message);
                    else
                        Logging.Error(message, exception);
                }
                // WARNING
                else if (level.HasFlag(LogLevel.Warning))
                {
                    if (exception == null)
                        Logging.Warn(message);
                    else
                        Logging.Warn(message, exception);
                }
                // INFO
                else if (level.HasFlag(LogLevel.Info))
                {
                    if (exception == null)
                        Logging.Info(messageFormat);
                    else
                        Logging.Info(messageFormat, exception);
                }
                // DEBUG
                else if (level.HasFlag(LogLevel.Debug))
                {
                    if (exception == null)
                        Logging.Debug(messageFormat);
                    else
                        Logging.Debug(messageFormat, exception);
                }

                // Print out message on console 
                if (consoleOutput == ConsoleOutput.ENABLED)
                {
                    Console.WriteLine(messageFormat);
                    if (exception != null)
                        Console.WriteLine("!exception - " + exception.Message + " -- " + exception.ToString());
                }

                // AUDIT TRAIL
                if (level.HasFlag(LogLevel.AuditTrail))
                {
                    // Insert to Audit trail
                }

                // MAIL
                if (level.HasFlag(LogLevel.Mail))
                {
                    // Send mail
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}