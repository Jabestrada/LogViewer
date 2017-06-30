using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogProcessor.LogSourceRefresher
{

    public class HttpLogSourceRefresher : ILogSourceRefresher
    {
        public event EventHandler<LogsProcessorProgressEventArgs> OnProgress;
        public void OnLogSourceRefreshProgress(string message, LogLevel level)
        {
            if (OnProgress != null)
            {
                OnProgress(this, new LogsProcessorProgressEventArgs(this.GetType().Name, message, level));
            }
        }

        private List<string> LogUrls = new List<string>();

        private int _daysCovered;
        private string _dumpFolder;

        public HttpLogSourceRefresher(List<string> logUrls, string dumpFolder, int daysCovered) {
            LogUrls = logUrls;
            _daysCovered = daysCovered;
            _dumpFolder = dumpFolder;
        }

        public bool RefreshLogSource()
        {
            // TODO: Create IDownloader interface that abstracts WebClient...
            using (WebClient client = new WebClient())
            {
                client.UseDefaultCredentials = true;
                foreach (var logUrl in LogUrls)
                {
                    OnLogSourceRefreshProgress("Retrieving log filenames from " + logUrl + " ...", LogLevel.Verbose);
                    try
                    {
                        string logsListRawHtml = client.DownloadString(logUrl);
                        var filenameScraper = new LogFilenameScraper(logUrl, logsListRawHtml, DateTime.Now, _daysCovered);
                        int logFileCount = filenameScraper.LogFilenames.Count();
                        int counter = 0;
                        foreach (var logFilename in filenameScraper.LogFilenames) {
                            counter++;
                            LogFileInfo logFileInfo = new LogFileInfo(logFilename, _dumpFolder, logUrl);
                            if (!File.Exists(logFileInfo.FullPath) || FileIsUpdated(logFileInfo.FullPath, logFileInfo.Url))
                            {
                                OnLogSourceRefreshProgress(string.Format("Downloading log {0} ({1}/{2})...", logFileInfo.Url, counter, logFileCount), LogLevel.Verbose);
                                client.DownloadFile(logFileInfo.Url, logFileInfo.FullPath);
                                OnLogSourceRefreshProgress("Log " + logFileInfo.Url + " was successfully downloaded to " + logFileInfo.FullPath, LogLevel.Verbose);
                            }
                            else {
                                OnLogSourceRefreshProgress("Log " + logFileInfo.Url + " was not downloaded because it already exists and has not changed since the last download.", LogLevel.Verbose);
                            }
                        }

                        OnLogSourceRefreshProgress("Completed refreshing log sources from " + logUrl, LogLevel.Verbose);
                    }
                    catch (Exception exc) {
                        // TODO: Store logUrl for test assertion purposes.
                        OnLogSourceRefreshProgress("Error occurred while retrieving log filenames from " + logUrl + ". Details: " + exc.Message, LogLevel.Error);
                        continue;
                    }

                }
            }
            return true;
        }

        private bool FileIsUpdated(string filename, string fileUri)
        {
            bool isUpdated = false;
            FileInfo file = new FileInfo(filename);
            if (file != null)
            {
                isUpdated = GetWebFileSize(fileUri) > (int)file.Length;
            }
            return isUpdated;
        }

        private  int GetWebFileSize(string fileUri)
        {
            int ContentLength = 0;
            System.Net.WebRequest req = System.Net.HttpWebRequest.Create(fileUri);
            req.Method = "HEAD";
            req.UseDefaultCredentials = true;
            using (System.Net.WebResponse resp = req.GetResponse())
            {
                if (int.TryParse(resp.Headers.Get("Content-Length"), out ContentLength))
                {
                    return ContentLength;
                }
            }
            return ContentLength;
        }

    }
}
