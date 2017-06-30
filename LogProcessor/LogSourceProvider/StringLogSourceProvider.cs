using LogProcessor.LogSourceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LogSourceProvider
{
    public class StringLogSourceProvider : ILogSourceProvider
    {
        string _logSources = string.Empty;
        char _logSourceDelimiter;

        public StringLogSourceProvider(string logSources, char logSourceDelimiter) {
            if (string.IsNullOrEmpty(logSources)) {
                throw new InvalidOperationException("logSources cannot be empty");
            }
            _logSources = logSources;
            _logSourceDelimiter = logSourceDelimiter;
        }

        public string[] GetLogSources()
        {
            return _logSources.Split(_logSourceDelimiter);
        }
    }
}
