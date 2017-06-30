using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LineReader
{
    public class StringLineReader : ILineReader
    {

        string[] _linesOfText;
        long _lineNumber = 0;
        char _delimiter;
        string _name;

        public StringLineReader(string name, char delimiter)
        {
            _name = name;
            _delimiter = delimiter;
        }

        public void Open(string source)
        {
            _linesOfText = source.Split(_delimiter);
            _lineNumber = 0;
        }

        public string SourceName
        {
            get
            {
                if (string.IsNullOrEmpty(_name))
                {
                    return this.GetType().ToString();
                }
                else {
                    return _name;
                }
            }
        }

        public long LineNumber
        {
            get
            {
                return _lineNumber;
            }
        }

        public string ReadLine()
        {
            
            string currentLine = _linesOfText[_lineNumber];
            _lineNumber++;
            return currentLine;
        }

        public bool HasMoreLines
        {
            get
            {
                return _lineNumber < _linesOfText.Length;
            }
        }

        public void Dispose()
        {
            _linesOfText = null;
        }

        public void Close()
        {
            // Do nothing
        }
    }

}
