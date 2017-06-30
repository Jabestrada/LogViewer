using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor
{
    public enum LogLevel { 
        Verbose,
        Information,
        Warning,
        Error
    }

    public class LogsProcessorProgressEventArgs : System.EventArgs
    {
        public readonly string ProgressSource;
        public readonly string ProgressMessage;
        public readonly LogLevel ProgressLevel;

        public LogsProcessorProgressEventArgs(string source, string message) {
            ProgressSource = source;
            ProgressMessage = message;
            ProgressLevel = LogLevel.Verbose;
        }

        public LogsProcessorProgressEventArgs(string source, string message, LogLevel level)
        {
            ProgressSource = source;
            ProgressMessage = message;
            ProgressLevel = level;
        }
    }
}
