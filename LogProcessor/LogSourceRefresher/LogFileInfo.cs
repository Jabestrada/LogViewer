using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LogProcessor
{
    public class LogFileInfo
    {
        public readonly string Filename;
        public readonly string FullPath;
        public readonly string Url;

        public LogFileInfo(string fileName, string targetFolder, string sourceUrl)
        {
            Filename = fileName;
            Url = GetFileUri(fileName, sourceUrl);
            string domain = GetDomain(sourceUrl);
            FullPath = GetFileName(fileName, domain, targetFolder);
        }

        private string GetFileName(string filename, string domain, string targetFolder)
        {
            Regex pattern = new Regex(@"(\d{4})");
            string filePrefix = string.Empty;
            if (pattern.IsMatch(domain))
            {
                filePrefix = pattern.Match(domain).Groups[1].Value;
            }
            else {
                filePrefix = domain;
            }



            string filenamePath = string.Empty;
            string _strFileName = string.Empty;
            char _strSeparator = System.IO.Path.DirectorySeparatorChar;
            string[] _strSplitFileName = filename.ToString().Split('.');

            if (targetFolder.IndexOf(_strSeparator, targetFolder.Length - 1) == -1)
            {
                targetFolder = string.Concat(targetFolder, _strSeparator);
            }

            if (_strSplitFileName.Count() > 3)
            {
                _strFileName = string.Format("{1}{0}{2}{0}{3}{0}{4}", ".", filePrefix, _strSplitFileName[0], _strSplitFileName[1], ((string.Equals(_strSplitFileName[3], "txt")) ? _strSplitFileName[2] : _strSplitFileName[3]));
            }
            else
            {
                _strFileName = string.Format("{1}{0}{2}{0}{3}", ".", filePrefix, _strSplitFileName[0], _strSplitFileName[1]);
            }

            filenamePath = string.Concat(targetFolder, _strFileName);
            if (!filenamePath.EndsWith(".txt", StringComparison.InvariantCultureIgnoreCase))
            {
                filenamePath = string.Concat(filenamePath, ".txt");
            }
            return filenamePath;
        }

        private string GetFileUri(string _listItem, string uri)
        {
            string _strUri = string.Empty;
            string _strValidateUri = uri;

            if (!System.Uri.IsWellFormedUriString(_strValidateUri, UriKind.Absolute))
            {
                _strValidateUri = System.Uri.EscapeUriString(_strValidateUri);
            }

            _strUri = string.Concat(_strValidateUri, "/", _listItem);
            return _strUri;
        }

        private string GetDomain(string Uri)
        {
            string _domain = string.Empty;

            if (!string.IsNullOrEmpty(Uri))
            {
                Uri _strUri = new Uri(Uri);
                _domain = _strUri.Host;
            }

            return _domain;
        }
    }
}
