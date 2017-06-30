using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Threading;
using System.Configuration;
using System.Diagnostics;

namespace LogViewer
{
    public partial class LogFileDownloader : Form
    {
        bool _downloadCanceled = false;
        WebClient wcClient;
        int fileCount = 0;

        private NetworkCredential _credentials;

        public LogFileDownloader()
        {
            InitializeComponent();

            //var pos = this.PointToScreen(PercentageLabel.Location);
            //pos = dlProgressBar.PointToClient(pos);
            //PercentageLabel.Parent = dlProgressBar;
            //PercentageLabel.Location = pos;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFolder.Text) || !Directory.Exists(txtFolder.Text))
            {
                MessageBox.Show("Please provide target folder location and verify that it exists.");
                txtFolder.Focus();
                return;
            }
            DownloadFiles();
           
        }


        public void DownloadFiles() {
            DownloadStatusTextbox.Clear();
            UpdateStatus(string.Empty);


            List<DownloadArg> downloadArgs = new List<DownloadArg>();

            for (int i = 0; i < FileList.Items.Count; i++)
            {
                string _strListItem = FileList.Items[i].ToString();
                string _strFileUri = string.Empty;
                string _strFilePath = string.Empty;
                if (!string.IsNullOrEmpty(_strListItem))
                {
                    _strFileUri = GetUri(_strListItem);
                    _strFilePath = GetFileName(_strListItem);
                    if (string.IsNullOrEmpty(_strFileUri) || string.IsNullOrEmpty(_strFilePath))
                    {
                        break;
                    }
                }
                downloadArgs.Add(new DownloadArg { SourceLogFilename = _strListItem,
                                                   SourceLogFileUri = _strFileUri, 
                                                   TargetLogFile = _strFilePath });
            }

            if (downloadArgs.Count > 0)
            {
                ParameterizedThreadStart ts = new ParameterizedThreadStart(doDownloadFiles);
                Thread downloadThread = new Thread(ts);
                downloadThread.Start(downloadArgs);
            }

        }

        private AutoResetEvent _resetEvent;

        private void setCredentials(WebClient client) {
            if (_credentials == null)
            {
                client.UseDefaultCredentials = true;
            }
            else {
                client.Credentials = _credentials;
            }
        }

        private void doDownloadFiles(object args)
        {
            List<DownloadArg> downloadArgs = args as List<DownloadArg>;
            int counter = 0;
            int total = downloadArgs.Count;
            //dlProgressBar.Maximum = total;
            this.Invoke((Action) delegate(){
                downloadFile.Enabled = false;
                dlProgressBar.Visible = true;
                CancelDownloadButton.Visible = true;
            });
            _downloadCanceled = false;
            _resetEvent = new AutoResetEvent(false);
            foreach (var downloadArg in downloadArgs){
                counter++;
                try
                {
                    this.Invoke((Action) delegate(){
                        DownloadStatusTextbox.AppendText(string.Format("Downloading {0} to {1} ({2}/{3}) ... ", 
                                                            downloadArg.SourceLogFilename, 
                                                            downloadArg.TargetLogFile, counter, total));
                        dlProgressBar.Value = 0;
                    });

                    wcClient = new WebClient();
                    setCredentials(wcClient);
                    wcClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                    wcClient.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
                    wcClient.DownloadFileAsync(new Uri(downloadArg.SourceLogFileUri), downloadArg.TargetLogFile);
                    
                    _resetEvent.WaitOne();

                    this.Invoke((Action)delegate()
                    {
                        DownloadStatusTextbox.AppendText((!_downloadCanceled ? "[OK]" : "[Canceled]") + Environment.NewLine);
                        // TODO: JABE uncomment
                        //dlProgressBar.Value = counter;
                    });
                    if (_downloadCanceled) {
                        break;
                    }
                }
                catch (WebException exc)
                {
                    this.Invoke((Action)delegate()
                    {
                        DownloadStatusTextbox.AppendText("[FAILED] Details: " + exc.Message + Environment.NewLine);
                    });
                    
                }
            }
            this.Invoke((Action)delegate()
            {
                DownloadStatusTextbox.AppendText(Environment.NewLine + (_downloadCanceled ? "DOWNLOAD CANCELED" : "DOWNLOAD COMPLETED"));

                downloadFile.Enabled = true;
                dlProgressBar.Value = 0;
                dlProgressBar.Visible = false;
                PercentageLabel.Text = string.Empty;
                CancelDownloadButton.Visible = false;
            });
        }

        private string GetUri(string _listItem)
        {
            string _strUri = string.Empty;
            string _strValidateUri = LogUrlList.Text;

            if (!System.Uri.IsWellFormedUriString(_strValidateUri, UriKind.Absolute))
            {
                _strValidateUri = System.Uri.EscapeUriString(_strValidateUri);
            }

            _strUri = string.Concat(_strValidateUri, "/", _listItem);
            return _strUri;
        }

        private string GetFileName(string _listItem)
        {
            string _strFilenamePath = string.Empty;
            string _strFolder = txtFolder.Text;
            string _strPrefix = txtFilenamePrefix.Text;

            if (string.IsNullOrEmpty(_strFolder))
            {
                MessageBox.Show("Please provide File Location Folder.");
                return _strFilenamePath;
            }

            char _strSeparator = Path.DirectorySeparatorChar;
            if (_strFolder.IndexOf(_strSeparator, _strFolder.Length - 1) == -1)
            {
                _strFolder = string.Concat(_strFolder, _strSeparator);
            }


            string[] _strSplitFileName = _listItem.ToString().Split('.');
            // TODO: JABE restore
            //string _strFileName = string.Empty;
            string _strFileName = _listItem.ToString();
            // TODO: JABE restore
            //if (_strSplitFileName.Count() > 3)
            //{
            //    _strFileName = string.Format("{1}{0}{2}{0}{3}", ".", _strSplitFileName[0], _strSplitFileName[1], ((string.Equals(_strSplitFileName[3], "txt")) ? _strSplitFileName[2] : _strSplitFileName[3]));
            //}
            //else
            //{
            //    _strFileName = string.Format("{1}{0}{2}", ".", _strSplitFileName[0], _strSplitFileName[1]);
            //}
            //_strFileName = (string.IsNullOrEmpty(_strPrefix)) ? _strFileName : string.Concat(_strPrefix, ".", _strFileName);
            //_strFilenamePath = string.Concat(_strFolder, _strFileName, ".txt");
            //_strFilenamePath = string.Concat(_strFolder, _strFileName);
            
            _strFilenamePath = string.Concat(_strFolder, _strPrefix, ".", _strFileName);

            if (!chkOverwriteFile.Checked)
            {
                while (System.IO.File.Exists(_strFilenamePath))
                {
                    _strFileName = string.Concat("Copy of ", _strFileName);
                    _strFilenamePath = string.Concat(_strFolder, _strFileName, ".txt");
                }
            }

            return _strFilenamePath;
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = message;
            lblStatus.Refresh();
        }

        private void UpdateDownloadStatus(string message)
        {
            this.Invoke((Action) delegate(){
                    DownloadStatusTextbox.Text = message;    
                });
        }

        private void GetFiles(string inputString)
        {
            try
            {
                FileList.Items.Clear();
                string _strUri = LogUrlList.Text;
                if (!System.Uri.IsWellFormedUriString(_strUri, UriKind.Absolute))
                {
                    _strUri = System.Uri.EscapeUriString(_strUri);
                }

                //string _strSitecoreFolder = string.Concat(_strUri.Split('/')[3], "/LinkTransform.log.");
                // TODO: JABE restore
                string _strSitecoreFolder = string.Concat(_strUri.Split('/')[3], "/log.");

                if (!string.IsNullOrEmpty(inputString))
                {
                    inputString = inputString.Replace("<br>", string.Empty).Replace("<hr>", string.Empty);
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(inputString.ToLower());
                    XmlNodeList nodes = xmlDoc.SelectNodes(@"//a");
                    DateTimePicker dateFrom = new DateTimePicker();
                    dateFrom.Value = datePickerFrom.Value;

                    while (dateFrom.Value.Date <= datePickerTo.Value.Date)
                    {
                        string _strDate = dateFrom.Value.ToString("yyyyMMdd");
                        string _strPattern = string.Concat(_strSitecoreFolder, _strDate);
                        foreach (XmlNode xml in nodes)
                        {
                            if (Regex.IsMatch(xml.OuterXml, _strPattern, RegexOptions.IgnoreCase))
                            {
                                FileList.Items.Add(xml.InnerText);
                            }
                        }
                        dateFrom.Value = dateFrom.Value.AddDays(1);
                    }
                }

                if (FileList.Items.Count > 0)
                {
                    fileCount = FileList.Items.Count;
                    downloadFile.Enabled = true;
                    FileList.SetSelected(0, true);
                }
                else
                {
                    downloadFile.Enabled = false;
                    MessageBox.Show("No files found, or your current account may not have sufficient permissions. You can try another account using the Change Network Account button.", "No logs found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                UpdateDownloadStatus(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string _strUri = LogUrlList.Text;
            if (!string.IsNullOrEmpty(_strUri))
            {
                FileList.Items.Clear();
                getFiles.Enabled = false;
                Thread t = new Thread(new ParameterizedThreadStart(GetFileList));
                t.Start(LogUrlList.Text);
                //string _strHtml = DownloadString(_strUri);
                //GetFiles(_strHtml);
            }
            else
            {
                MessageBox.Show("Please provide URL to log files.");
                LogUrlList.Focus();
            }
        }

        private void GetFileList(object args) {
            string _strHtml = DownloadString(args.ToString());
            this.Invoke((Action)delegate {
                GetFiles(_strHtml);
                getFiles.Enabled = true;
            });
        }


        private string DownloadString(string address)
        {
            string _strOutput = string.Empty;
            using (WebClient client = new WebClient())
            {
                try
                {
                    setCredentials(client);
                    _strOutput = client.DownloadString(address);
                }
                catch (Exception ex)
                {
                    UpdateDownloadStatus(ex.Message);
                }
            }

            return _strOutput;
        }

        private void StartDownload(string address, string filename)
        {
            wcClient = new WebClient();
            setCredentials(wcClient);
            //wcClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
            wcClient.DownloadFileCompleted += new AsyncCompletedEventHandler(wc_DownloadFileCompleted);
            wcClient.DownloadFileAsync(new Uri(address), filename);
        }

       


        void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _resetEvent.Set();
            if (e.Cancelled)
            {
                return;
            }
        }

        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            if (_downloadCanceled)
            {
                wcClient.CancelAsync();
                _resetEvent.Set();
            }
            else
            {
                this.Invoke((Action)delegate()
                {
                    PercentageLabel.Text = e.ProgressPercentage.ToString() + "%";
                    dlProgressBar.Value = e.ProgressPercentage;
                });
            }
            
        }

        private void btnClearFile_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            FileList.Items.Clear();
            downloadFile.Enabled = false;
            lblStatus.Text = string.Empty;
            DownloadStatusTextbox.Clear();
            dlProgressBar.Value = 0;
        }

        private void LogFileDownloader_Load(object sender, EventArgs e)
        {
            datePickerFrom.Value = DateTime.Now.AddDays(-1);
            string downloadFolder = ConfigurationManager.AppSettings["downloadFolder"];
            if (!string.IsNullOrEmpty(downloadFolder) && Directory.Exists(downloadFolder))
            {
                txtFolder.Text = downloadFolder;
            }
            string logUrls = ConfigurationManager.AppSettings["logUrls"];
            if (!string.IsNullOrEmpty(logUrls)) {
                LogUrlList.Items.AddRange(logUrls.Split('|'));
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", txtFolder.Text);
        }


        private void CancelDownloadButton_Click(object sender, EventArgs e)
        {
            _downloadCanceled = true;
        }

        private void LogFileDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dlProgressBar.Visible) {
                MessageBox.Show("Download is in-progress. Cancel the download before closing this window.", 
                                "Window cannot be closed now", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }            
       }

        private void FileList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                for (int k = FileList.Items.Count - 1; k > -1; k--)
                {
                    if (FileList.SelectedItems.Contains(FileList.Items[k]))
                    {
                        FileList.Items.RemoveAt(k);
                    }
                }
            }
        }

        private void AddFileToDownloadButton_Click(object sender, EventArgs e)
        {
            string file = ManualFileAddTextbox.Text;
            if (string.IsNullOrEmpty(file)) {
                MessageBox.Show("Please enter filename to manually add in the download list");
                ManualFileAddTextbox.Focus();
                return;
            }
            if (FileList.Items.Contains(file))
            {
                MessageBox.Show("File " + file + " is already in the list");
            }
            else { 
                FileList.Items.Add(file);
            }
        }

     private void LogUrlList_Leave(object sender, EventArgs e)
     {
            if (LogUrlList.SelectedItem != null)
            {
                string url = LogUrlList.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(url))
                {
                    string filePrefixRegEx= ConfigurationManager.AppSettings["downloadFilePrefixRegEx"];
                    if (string.IsNullOrEmpty(filePrefixRegEx)) {
                        return;
                    }
                    Regex r = new Regex(@filePrefixRegEx);
                    if (r.IsMatch(url))
                    {
                        string filePrefixMatch = r.Match(url).Groups[1].Value;
                        if (!string.IsNullOrEmpty(filePrefixMatch))
                        {
                            txtFilenamePrefix.Text = filePrefixMatch;
                        }
                    }
                }
            }
        }

     private void NetworkCredsButton_Click(object sender, EventArgs e)
     {
         using (NetworkLoginPrompt prompt = new NetworkLoginPrompt())
         {
             prompt.SetCredentials(_credentials);
             if (prompt.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
             {
                 _credentials = new NetworkCredential(prompt.UserName, prompt.Password, prompt.Domain);
             }
         }
     }

     private void SettingsButton_Click(object sender, EventArgs e)
     {
         using (var settings = new SettingsForm())
         {
             if (settings.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
             {
                 if (settings.UserSettings != null) {
                     this.Text = settings.UserSettings.WindowTitle;
                 }
             }
         }

     }

     
    }

    public class DownloadArg
    {
        public string SourceLogFileUri;
        public string SourceLogFilename;
        public string TargetLogFile;
    }
}
