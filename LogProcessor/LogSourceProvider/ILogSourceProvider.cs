using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LogSourceProvider
{
    public interface ILogSourceProvider
    {
        string[] GetLogSources();
    }

}
