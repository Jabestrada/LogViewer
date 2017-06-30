using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LineReader
{
    public class FileLineReader : ILineReader
    {
        StreamReader _sr;
        FileStream _fs = null;
        long _lineNumber;
        string _source;


        public void Open(string source)
        {
            _source = source;
            _fs = new FileStream(source, FileMode.Open,
                    FileAccess.Read, FileShare.ReadWrite);
            _sr = new StreamReader(_fs);
            _lineNumber = 0;
        }

        public string ReadLine()
        {
            _lineNumber++;
            return _sr.ReadLine();
        }

        public bool HasMoreLines
        {
            get
            {
                return !_sr.EndOfStream;
            }
        }

        public void Dispose()
        {
            CloseStream();
        }


        public long LineNumber
        {
            get
            {
                return _lineNumber;
            }
        }

        public string SourceName
        {
            get
            {
                return _source;
            }
        }

        public void Close()
        {
            CloseStream();
        }

        private void CloseStream() {
            if (_sr != null)
            {
                _sr.Close();
                _sr.Dispose();
            }
            if (_fs != null)
            {
                _fs.Close();
                _fs.Dispose();
            }
        }
    }
}
