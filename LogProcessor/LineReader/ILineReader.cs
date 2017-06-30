using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LineReader
{
    public interface ILineReader : IDisposable
    {
        string SourceName { get; }
        long LineNumber { get; }
        bool HasMoreLines { get; }
        string ReadLine();
        void Open(string source);
        void Close();
    }
}
