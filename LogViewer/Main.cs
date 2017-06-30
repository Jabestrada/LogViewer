using LogViewer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public delegate bool LineEvaluator(string line, int lineNumber);

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFile(LineContainsTokens);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string startupFolder = ConfigurationManager.AppSettings["startupFolder"];
            if (!string.IsNullOrEmpty(startupFolder)) {
                SourceDirTextbox.Text = startupFolder;
            }
            string defaultOpenProgram = ConfigurationManager.AppSettings["defaultOpenFileProgram"];
            if (string.IsNullOrEmpty(defaultOpenProgram))
            {
                OpenFileProgram.Text = "notepad";
            }
            else {
                OpenFileProgram.Text = defaultOpenProgram;
            }
            string fileNameFilter = ConfigurationManager.AppSettings["filenameFilter"];
            if (!string.IsNullOrEmpty(fileNameFilter)){
                FileTypeFilterTextbox.Text = fileNameFilter;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            LogViewerDisplay.WordWrap = checkBox1.Checked;
        }

        private void GetFilesButton_Click(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private string GetSelectedFile() {
            if (FileList.SelectedItem == null) {
                return string.Empty;
            }
            return FileList.SelectedItem.ToString().Split()[0].Trim();
        }

        private bool LineContainsTokens(string line, int lineNumber)
        {
            string[] searchTokens = textBox2.Text.Split("|".ToCharArray());
            bool allTokensFound = false;
            foreach (var token in searchTokens)
            {
                if (line.ToUpperInvariant().IndexOf(token.ToUpperInvariant()) > -1)
                {
                    allTokensFound = true;
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return allTokensFound;
        }

        private void OpenFile(LineEvaluator mustIncludeLineInOutput)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                StringBuilder output = new StringBuilder();
                string fileName = GetSelectedFile();
                try
                {
                    fs = new FileStream(fileName, FileMode.Open,
                        FileAccess.Read, FileShare.ReadWrite);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    return;
                }
                int lineNumber = 0;

                sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    lineNumber++;
                    string line = sr.ReadLine();
                    if (mustIncludeLineInOutput(line, lineNumber))
                    {
                        output.AppendLine("Line " + lineNumber.ToString() + "    " + line);
                    }
                }
                string contents = output.ToString();
                if (string.IsNullOrEmpty(contents))
                {
                    contents = "File " + fileName + " opened but no contents matched filter";
                }

                LogViewerDisplay.Text = contents;
                string lastChar = contents.Substring(contents.Length - 2, 1);
                LogViewerDisplay.Select(contents.Length - 3, contents.Length - 2);
                LogViewerDisplay.ScrollToCaret();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }

            }
        }

        

        private void LoadFiles() {
            try
            {

                FileList.Items.Clear();

                DirectoryInfo dirInfo = new DirectoryInfo(SourceDirTextbox.Text.Trim());
                string fileFilter = @FileTypeFilterTextbox.Text;
                IEnumerable<FileInfo> files = dirInfo.GetFiles().Where(f => f.FullName.Contains(fileFilter)).OrderBy(f => f.LastWriteTime);
                ArrayList sortedFiles = new ArrayList(files.Count());
                foreach (var file in files)
                {
                    sortedFiles.Add(string.Format("{0}{1}", file.FullName, file.LastWriteTime.ToString().PadLeft(150 - file.FullName.Length, ' ')));
                }

                for (int k = sortedFiles.Count - 1; k >= 0; k--)
                {
                    FileList.Items.Add(sortedFiles[k]);
                }

                if (FileList.Items.Count > 0)
                {
                    FileList.SetSelected(0, true);
                }
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }
        }

        private void FileList_DoubleClick(object sender, EventArgs e)
        {
            OpenFile(LineContainsTokens);
        }

        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            string fileName = GetSelectedFile();
            if (!string.IsNullOrEmpty(fileName))
            {
                //Process.Start("notepad", fileName);
                Process.Start(OpenFileProgram.Text, fileName);
            }
        }

        //private int _currentPos = 0;

        //private void FindButton_Click(object sender, EventArgs e)
        //{
        //    string searchTerm = FindText.Text.Trim();
        //    if (string.IsNullOrEmpty(searchTerm)) return;

        //    if (LogViewerDisplay.SelectedText.Length == 0) {
        //        _currentPos = 0;
        //    }

        //    int startSelPos = LogViewerDisplay.Find(searchTerm, _currentPos, RichTextBoxFinds.None);
        //    if (startSelPos > -1)
        //    {
        //        LogViewerDisplay.Select(startSelPos, searchTerm.Length);
        //        LogViewerDisplay.ScrollToCaret();
        //        _currentPos = startSelPos + searchTerm.Length;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Not found");
        //    }
            
        //}

        private void OpenFolderButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", SourceDirTextbox.Text);
        }


        private bool LineNumberIsInRange(string line, int lineNumber)
        {
            long startLineFilter = Math.Max(Convert.ToInt64(LineNumberStart.Value), 1);
            long endLineFilter = Math.Min(Convert.ToInt64(LineNumberEnd.Value), long.MaxValue);
            return lineNumber >= startLineFilter && lineNumber <= endLineFilter;
        }

        private void ApplyLineFilterButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile(LineNumberIsInRange);
            }
            catch (Exception exc) {
                MessageBox.Show(exc.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogViewer.LogFileDownloader fileDownloader = new LogViewer.LogFileDownloader();
            fileDownloader.Show();
        }

        private string GetFilteredFileContents(LineEvaluator mustIncludeLineInOutput, string fileName)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                StringBuilder output = new StringBuilder();
                try
                {
                    fs = new FileStream(fileName, FileMode.Open,
                        FileAccess.Read, FileShare.ReadWrite);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    return string.Empty;
                }
                int lineNumber = 0;
                sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    lineNumber++;
                    string line = sr.ReadLine();
                    if (mustIncludeLineInOutput(line, lineNumber))
                    {
                        output.AppendLine("Line " + lineNumber.ToString() + "    " + line);
                    }
                }
                return output.ToString();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return string.Empty;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
                if (fs != null)
                {
                    fs.Close();
                    fs.Dispose();
                }

            }
        }

        //private void ApplyFilterAllFiles_Click(object sender, EventArgs e)
        //{
        //    if (FileList.Items.Count == 0)
        //    {
        //        MessageBox.Show("There are no files in the list");
        //        return;
        //    }

        //    LogViewerDisplay.Clear();
        //    foreach (var fileItem in FileList.Items)
        //    {
        //        var fileName = fileItem.ToString().Split()[0].Trim();
        //        string filteredContent = GetFilteredFileContents(LineContainsTokens, fileName);
        //        if (!string.IsNullOrEmpty(filteredContent))
        //        {
        //            LogViewerDisplay.AppendText("".PadLeft(100, '='));
        //            LogViewerDisplay.AppendText(Environment.NewLine);
        //            LogViewerDisplay.AppendText("[START] " + fileName);
        //            LogViewerDisplay.AppendText(Environment.NewLine);
        //            LogViewerDisplay.AppendText("".PadLeft(100, '='));
        //            LogViewerDisplay.AppendText(Environment.NewLine);
        //            LogViewerDisplay.AppendText(filteredContent);
        //            LogViewerDisplay.AppendText("".PadLeft(100, '='));
        //            LogViewerDisplay.AppendText(Environment.NewLine);
        //            LogViewerDisplay.AppendText("[END] " + fileName);
        //            LogViewerDisplay.AppendText(Environment.NewLine);
        //            LogViewerDisplay.AppendText("".PadLeft(100, '='));
        //            LogViewerDisplay.AppendText(Environment.NewLine);
        //        }
        //    }
        //}

        private void btnApplyFilterAllFiles_Click(object sender, EventArgs e)
        {
            if (FileList.Items.Count == 0)
            {
                MessageBox.Show("There are no files in the list");
                return;
            }

            LogViewerDisplay.Clear();
            btnApplyFilterAllFiles.Text = "Applying filter to all files ...";
            btnApplyFilterAllFiles.Enabled = false;

            List<string> files = new List<string>();
            foreach (var fileItem in FileList.Items)
            {
                var fileName = fileItem.ToString().Split()[0].Trim();
                files.Add(fileName);
            }

            Thread logViewerTask = new Thread(new ParameterizedThreadStart(EnforceFilter));
            logViewerTask.Priority = ThreadPriority.AboveNormal;
            logViewerTask.Start(files);
        }

        private void EnforceFilter(object files) {

            bool foundSomething = false;
            List<string> fileNames = files as List<string>;
            if (fileNames != null)
            {
                foreach (var fileName in fileNames)
                {
                    string filteredContent = GetFilteredFileContents(LineContainsTokens, fileName);
                    if (!string.IsNullOrEmpty(filteredContent))
                    {
                        foundSomething = true;
                        this.Invoke((Action)delegate() { 
                            LogViewerDisplay.AppendText("".PadLeft(100, '='));
                            LogViewerDisplay.AppendText(Environment.NewLine);
                            LogViewerDisplay.AppendText("[START] " + fileName);
                            LogViewerDisplay.AppendText(Environment.NewLine);
                            LogViewerDisplay.AppendText("".PadLeft(100, '='));
                            LogViewerDisplay.AppendText(Environment.NewLine);
                            LogViewerDisplay.AppendText(filteredContent);
                            LogViewerDisplay.AppendText("".PadLeft(100, '='));
                            LogViewerDisplay.AppendText(Environment.NewLine);
                            LogViewerDisplay.AppendText("[END] " + fileName);
                            LogViewerDisplay.AppendText(Environment.NewLine);
                            LogViewerDisplay.AppendText("".PadLeft(100, '='));
                            LogViewerDisplay.AppendText(Environment.NewLine);
                        });
                    }
                }
                if (!foundSomething) {
                    this.Invoke((Action)delegate() {
                        LogViewerDisplay.AppendText("No matches were found in all files.");
                    });
                }
                this.Invoke((Action)delegate() {
                    btnApplyFilterAllFiles.Text = "Apply filter to all files";
                    btnApplyFilterAllFiles.Enabled = true;
                });
            }
        
        }

        private void SetupListenerButton_Click(object sender, EventArgs e)
        {
            LogListenerForm listener = new LogListenerForm();
            listener.LogsFolder = SourceDirTextbox.Text;
            listener.Show();
        }
    }

}
