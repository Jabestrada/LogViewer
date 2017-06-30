using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LogSourceRefresher
{
    public interface ILogSourceRefresher
    {
        bool RefreshLogSource();
        
        event EventHandler<LogsProcessorProgressEventArgs> OnProgress;
    }
}
