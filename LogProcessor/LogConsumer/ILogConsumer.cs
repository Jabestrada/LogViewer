using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LogConsumer
{
    public interface ILogConsumer
    {
        void SetInputPages(List<string> pages);

        /// <summary>
        /// Consumes a line of log entry that will be evaluated. Return true to signal termination of evaluation.
        /// </summary>
        /// <param name="lineText">Line of log entry to evaluate</param>
        /// <param name="lineNumber">Line number of log entry</param>
        /// <param name="logSource">Source of the log entry</param>
        /// <returns>Return true to signal completion of evaluation; client code should discontinue sending any remaining log entries</returns>
        bool ConsumeLogEntry(string lineText, long lineNumber, string logSource);
        bool IsDone { get; }

        string GetOutput();

        event EventHandler<LogsProcessorProgressEventArgs> OnProgress;

    }
}
