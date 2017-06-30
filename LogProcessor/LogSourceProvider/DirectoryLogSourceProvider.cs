using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LogSourceProvider
{
    public class DirectoryLogSourceProvider : ILogSourceProvider
    {
        string _sourceDirectory = string.Empty;

        public DirectoryLogSourceProvider(string sourceDirectory) {
            _sourceDirectory = sourceDirectory;
        }

        public string[] GetLogSources()
        {
            return Directory.GetFiles(_sourceDirectory);
        }
    }
}
