using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace LogProcessor.LogConsumer
{
    public class CloningLogConsumer : ILogConsumer
    {
        #region Privates
        private bool _isDone;
        private List<string> completedPages = new List<string>();

        private static void RenderOutputFile(string inputFileName, List<LogOutputInfo> fileInfo)
        {
            string outputFile = Path.GetFileName(inputFileName);
            string directoryPath = Path.GetDirectoryName(inputFileName);
            outputFile = string.Concat("Processed.", outputFile);
            string fileFullPath = Path.Combine(directoryPath, outputFile);
            fileFullPath = Path.ChangeExtension(fileFullPath, "xml");

            XmlDocument outputDoc = GenerateXmlDocument(fileInfo);
            outputDoc.Save(fileFullPath);
        }
        private static XmlDocument GenerateXmlDocument(List<LogOutputInfo> fileInfo)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Pages");

            foreach (LogOutputInfo info in fileInfo)
            {
                XmlElement page = xmlDocument.CreateElement("Page");
                page.SetAttribute("Name", info.Page.FullPath);

                // create start time info
                XmlNode startLineInfo = xmlDocument.CreateNode(XmlNodeType.Element, "Data", null);
                startLineInfo.Attributes.Append(CreateAttribute(xmlDocument, "StartTime", info.StartLineText));
                startLineInfo.Attributes.Append(CreateAttribute(xmlDocument, "LineNumber", info.StartLineNumber.ToString()));
                startLineInfo.Attributes.Append(CreateAttribute(xmlDocument, "LogFile", info.StartLineLogFile));
                page.AppendChild(startLineInfo);

                // create end time info
                XmlNode endLineInfo = xmlDocument.CreateNode(XmlNodeType.Element, "Data", null);
                endLineInfo.Attributes.Append(CreateAttribute(xmlDocument, "EndTime", info.EndLineText));
                endLineInfo.Attributes.Append(CreateAttribute(xmlDocument, "LineNumber", info.EndLineNumber.ToString()));
                endLineInfo.Attributes.Append(CreateAttribute(xmlDocument, "LogFile", info.EndLineLogFile));
                page.AppendChild(endLineInfo);

                root.AppendChild(page);
            }
            xmlDocument.AppendChild(root);

            return xmlDocument;
        }
        private static XmlAttribute CreateAttribute(XmlDocument xmlDocument, string name, string value)
        {
            XmlAttribute _xmlAttribute = xmlDocument.CreateAttribute(name);
            _xmlAttribute.Value = value;

            return _xmlAttribute;
        }
        private bool UpdatePageInfo(string pageName, string lineText, long lineNumber, string fileName)
        {
            bool pageProcessingComplete = false;
            var pageOutput = Results.Where(p => p.Page.PageName == pageName).FirstOrDefault<LogOutputInfo>();
            if (pageOutput != null)
            {
                //string startLine = string.Format(Settings.GetStartLineFilter(), pageName);
                //string endLine = string.Format(Settings.GetEndLineFilter(), pageName);
                if (string.IsNullOrEmpty(pageOutput.StartLineText))
                {
                    string startLine = string.Format("EnforceRules START: Name: {0}; Lang={1};Version={2}", pageName, pageOutput.Page.Language, pageOutput.Page.Version);
                    if (lineText.IndexOf(startLine, StringComparison.InvariantCultureIgnoreCase) > 0)
                    {
                        ReportProgress(string.Format("Found START filter match for {0} in line {1} of {2}", pageName, lineNumber, fileName), LogLevel.Information);
                        pageOutput.StartLineText = GetTimeValue(lineText);
                        pageOutput.StartLineNumber = lineNumber;
                        pageOutput.StartLineLogFile = fileName;
                    }
                }
                if (string.IsNullOrEmpty(pageOutput.EndLineText))
                {
                    string endLine = string.Format("EnforceRules END: Name: {0}; Lang={1};Version={2}", pageName, pageOutput.Page.Language, pageOutput.Page.Version);
                    if (lineText.IndexOf(endLine, StringComparison.InvariantCultureIgnoreCase) > 0)
                    {
                        ReportProgress(string.Format("Found END filter match for {0} in line {1} of {2}", pageName, lineNumber, fileName), LogLevel.Information);
                        pageOutput.EndLineText = GetTimeValue(lineText);
                        pageOutput.EndLineNumber = lineNumber;
                        pageOutput.EndLineLogFile = fileName;
                        pageProcessingComplete = true;
                    }
                }
            }
            return pageProcessingComplete;
        }
        private string GetTimeValue(string lineText)
        {
            string _strTimeValue = string.Empty;
            Regex pattern = new Regex(@"(\d{2}:\d{2}:\d{2})");
            if (pattern.IsMatch(lineText))
            {
                _strTimeValue = pattern.Match(lineText).Groups[1].Value;
            }

            return _strTimeValue;
        }
        #endregion

        public List<LogOutputInfo> Results = new List<LogOutputInfo>();

        public void ReportProgress(string progressMessage, LogLevel level) {
            if (OnProgress != null)
            {
                OnProgress(this, new LogsProcessorProgressEventArgs(this.GetType().ToString(), progressMessage, level));
            }
        }

        #region ILogConsumer
        public bool ConsumeLogEntry(string lineText, long lineNumber, string logSource)
        {
            if (_isDone) {
                return false;
            }
            var allPages = Results.Select( r => r.Page);
            foreach (var page in allPages)
            {
                if (UpdatePageInfo(page.PageName, lineText, lineNumber, logSource)) {
                    completedPages.Add(page.PageName);
                }
            }
            return _isDone = allPages.All(p => completedPages.Contains(p.PageName));
        }

        public bool IsDone
        {
            get
            {
                return _isDone;
            }

        }
        public void SetInputPages(List<string> pages)
        {
            completedPages.Clear();
            _isDone = false;
            Results = new List<LogOutputInfo>();
            foreach (var page in pages)
            {
                Results.Add(new LogOutputInfo(new PageInfo(page)));
            }
        }

        public string GetOutput()
        {
            string[] output = Results.Select(o => string.Format("<page fullPath='{0}'>" +
                                                                 "<start timestamp='{1}' source='{2}' lineNumber='{3}' />" +
                                                                 "<end timestamp='{4}' source='{5}' lineNumber='{6}' />" +
                                                                 "</page>",
                                                        o.Page.FullPath,
                                                        o.StartLineText,
                                                        o.StartLineLogFile,
                                                        o.StartLineNumber,
                                                        o.EndLineText,
                                                        o.EndLineLogFile,
                                                        o.EndLineNumber)).ToArray();
            return "<results>" + string.Join("", output) + "</results>";
        }
        #endregion

        public event EventHandler<LogsProcessorProgressEventArgs> OnProgress;
    }

    public class LogOutputInfo
    {
        public readonly PageInfo Page;
        public LogOutputInfo(PageInfo page) {
            Page = page;        
        }

        public string StartLineText { get; set; }
        public long StartLineNumber { get; set; }
        public string StartLineLogFile { get; set; }
        public string EndLineText { get; set; }
        public long EndLineNumber { get; set; }
        public string EndLineLogFile { get; set; }
    }
}
