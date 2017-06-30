using LogProcessor.LineReader;
using LogProcessor.LogConsumer;
using LogProcessor.LogSourceProvider;
using LogProcessor.LogSourceRefresher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor
{
    
    public class LogsProcessor
    {
        public event EventHandler<LogsProcessorProgressEventArgs> LogsProcessingProgress;

        public ILineReader LogReader
        {
            get;
            set;
        }
        public ILogConsumer LogConsumer
        {
            get;
            set;
        }
        public ILogSourceProvider LogSource
        {
            get;
            set;
        }

        public void OnLogsProcessingProgress(string source, string message, LogLevel level) {
            if (LogsProcessingProgress != null) {
                LogsProcessingProgress(this, new LogsProcessorProgressEventArgs(source, message, level));
            }
        }
        
        public bool Initialize(List<string> pages) {
            if (pages.Count == 0)
            {
                throw new InvalidOperationException("There are no pages to process from the input source");
            }
            if (LogConsumer == null) {
                throw new InvalidOperationException("LogConsumer cannot be null during Initialize.");
            }

            LogConsumer.SetInputPages(pages);
            return true;
        }

        public bool ProcessLogs() {
            LogConsumer.OnProgress -= LogConsumer_OnProgress;
            LogConsumer.OnProgress += LogConsumer_OnProgress;

            bool done = false;
            var logs = LogSource.GetLogSources();
            if (logs.Length == 0) {
                OnLogsProcessingProgress(this.GetType().Name, "No logs to process since no LogSources were retrieved.", LogLevel.Verbose);
            }
            for (int k = 0; k < logs.Length; k++)
            {
                LogReader.Open(logs[k]);
                OnLogsProcessingProgress(this.GetType().Name, string.Format("Started processing log source {0} ({1}/{2}).", LogReader.SourceName, k + 1, logs.Length), LogLevel.Verbose);
                while (!done && LogReader.HasMoreLines)
                {
                    string line = LogReader.ReadLine();
                    done = LogConsumer.ConsumeLogEntry(line, LogReader.LineNumber, LogReader.SourceName);
                }
                LogReader.Close();
                if (done)
                {
                    OnLogsProcessingProgress(this.GetType().Name, string.Format("LogConsumer is DONE. Terminated processing in log source {0} ({1}/{2}).", logs[k], k + 1, logs.Length), LogLevel.Verbose);
                    break;
                }
                else {
                    OnLogsProcessingProgress(this.GetType().Name, string.Format("LogConsumer is NOT DONE after processing log source {0} ({1}/{2}).", logs[k], k + 1, logs.Length), LogLevel.Verbose);    
                }
            }
            return done;
        }

        void LogConsumer_OnProgress(object sender, LogsProcessorProgressEventArgs e)
        {
            OnLogsProcessingProgress(e.ProgressSource, e.ProgressMessage, e.ProgressLevel);
        }

        public string GetOutput() {
            return LogConsumer.GetOutput();
        }

    }
}
