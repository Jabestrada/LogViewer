using LogProcessor;
using LogProcessor.LogSourceRefresher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace LogViewer
{
    public partial class LogListenerForm : Form
    {
        Stopwatch stopWatch = new Stopwatch();

        private LogsListener _listener = new LogsListener();
        private bool _isListening = false;

        public string LogsFolder { get; set; }

        public LogListenerForm()
        {
            InitializeComponent();

        }

        private void LogListener_Load(object sender, EventArgs e)
        {
            LogsFolderTextbox.Text = LogsFolder;

            _listener.ListenerProgress += _listener_ListenerProgress;
            _listener.ListeningStopped += _listener_ListeningStopped;
            _listener.ListeningEnded += _listener_ListeningEnded;
                    
        }

        void _listener_ListeningEnded(object sender, EventArgs e)
        {
            SafeAppendText(TraceMessagesTextbox, "LogsListener is DONE.");
            WriteOutput();    
            OnListeningEnded();
        }


        private void WriteOutput() {
            //string rawOutput = _listener.GetOutput();
//            string rawOutput = @"<results>
//	                            <page fullPath='/core/HomeDev/A15'>
//		                            <start resultText='11:13:34' source='D:\Web\ACN21338\Data\logs\log.20141222.111144.txt' lineNumber='1879' />
//		                            <end resultText='11:16:09' source='D:\Web\ACN21338\Data\logs\log.20141222.111144.txt' lineNumber='9351' />
//	                            </page>
//	                            <page fullPath='/core/HomeDev/A16'>
//		                            <start resultText='16:27:13' source='D:\Web\ACN21338\Data\logs\log.20141222.111144.txt' lineNumber='135993' />
//		                            <end resultText='16:31:25' source='D:\Web\ACN21338\Data\logs\log.20141222.111144.txt' lineNumber='144772' />
//	                            </page>
//                            </results>";

            


//            XslCompiledTransform xslt = new XslCompiledTransform();
//            StringReader xsr = new StringReader(");

//            StringReader sr = new StringReader(rawOutput);
//            XmlReader reader = XmlReader.Create(sr);
//            StringBuilder output = new StringBuilder();
//            StringWriter sw = new StringWriter(output);

//            xslt.Transform(reader, null, sw);
            OutputTextbox.Invoke((Action)delegate() {
                OutputTextbox.Clear();
                OutputTextbox.Text = _listener.GetOutput()
                                        .Replace("<page", Environment.NewLine + '\t' + "<page")
                                        .Replace("<start", Environment.NewLine + '\t' + '\t' + "<start")
                                        .Replace("<end", Environment.NewLine + '\t' + '\t' + "<end")
                                        .Replace("</page>", Environment.NewLine + '\t' + "</page>")
                                        .Replace("</results>", Environment.NewLine + "</results>");
                                        
            });
        }

        void _listener_ListeningStopped(object sender, EventArgs e)
        {
            SafeAppendText(TraceMessagesTextbox, "LogsListener was STOPPED by user.");
            OnListeningEnded();
        }

        void _listener_ListenerProgress(object sender, LogsProcessorProgressEventArgs e)
        {
            SafeAppendText(TraceMessagesTextbox, e.ProgressSource + ": " + e.ProgressMessage);
            if (e.ProgressLevel != LogLevel.Verbose)
            {
                SafeAppendText(OutputTextbox, e.ProgressSource + ": " + e.ProgressMessage);
            }
        }

        void SafeAppendText(TextBox tb, string text) { 
            this.Invoke((Action)delegate(){
                tb.AppendText(DateTime.Now.ToString() + '\t' + text);
                tb.AppendText(Environment.NewLine);
            });
        }

        private void ListenButton_Click(object sender, EventArgs e)
        {
            if (!TransitionValid())
            {
                return;
            }

            if (_isListening)
            {
                OnStopListeningCommand();
            }
            else
            {
                OnStartListeningCommand();
                _isListening = true;
            }
        }

        private bool TransitionValid() {
            if (!_isListening) {
                if (string.IsNullOrEmpty(InputPagesTextbox.Text))
                {

                    MessageBox.Show("Please enter pages to monitor.");
                    return false;
                }
            }
            return true;
        }

        public void OnStopListeningCommand()
        {
            _listener.StopListening();
        }

        public void OnListeningEnded() {

            ListenButton.Invoke((Action)delegate() { 
                ListenButton.Text = "Start listening";
                stopWatch.Stop();
                TraceMessagesTextbox.AppendText(Environment.NewLine);
                TraceMessagesTextbox.AppendText(string.Format("Elapsed time (hh:mm:ss): {0}:{1}:{2}", 
                                                                stopWatch.Elapsed.Hours.ToString().PadLeft(2,'0'),
                                                                stopWatch.Elapsed.Minutes.ToString().PadLeft(2, '0'),
                                                                stopWatch.Elapsed.Seconds.ToString().PadLeft(2, '0')));
                
            });
            _isListening = false;
        }

        public void OnStartListeningCommand()
        {
            ListenButton.Text = "Stop listening";
            OutputTextbox.Clear();
            TraceMessagesTextbox.Clear();

            List<string> logUrls = LogUrlsTextbox.Text.Split(Environment.NewLine.ToCharArray()).Where(s => !string.IsNullOrEmpty(s)).ToList<string>();
            if (logUrls != null && logUrls.Count > 0)
            {
                var logRefresher = new HttpLogSourceRefresher(logUrls.Where(s => !string.IsNullOrEmpty(s)).ToList<string>(), LogsFolderTextbox.Text, 2);
                _listener.LogSourceRefresher = logRefresher;
            }
            else {
                _listener.LogSourceRefresher = null;
            }

            string[] inputPages = InputPagesTextbox.Text.Split(Environment.NewLine.ToCharArray());
            _listener.LogsFolder = LogsFolderTextbox.Text;
            _listener.StartListening(inputPages.Where(s => !string.IsNullOrEmpty(s)).ToList<string>());
            stopWatch.Reset();
            stopWatch.Start();
        }

    }
}
