using LogProcessor.LineReader;
using LogProcessor.LogConsumer;
using LogProcessor.LogSourceProvider;
using LogProcessor.LogSourceRefresher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LogProcessor
{

    public class LogsListener
    {

        public event EventHandler ListeningStopped;
        public event EventHandler ListeningEnded;
        public event EventHandler<LogsProcessorProgressEventArgs> ListenerProgress;

        public int SLEEP_DURATION = 5000;

        private LogsProcessor processor;

        public LogsListener() {
            processor = new LogsProcessor();
            // TODO: Activate ILogConsumer from config.
            processor.LogConsumer = new CloningLogConsumer();
            processor.LogReader = new FileLineReader();
            processor.LogsProcessingProgress += processor_LogsProcessingProgress;
           
        }

        private void OnListeningEnded() {
            if (ListeningEnded != null) {
                ListeningEnded(this, EventArgs.Empty);
            }
        }

        private void OnListeningStopped()
        {
            if (ListeningStopped != null)
            {
                ListeningStopped(this, EventArgs.Empty);
            }
        }

        private void OnListenerProgress(string message, LogLevel level)
        {
            if (ListenerProgress != null)
            {
                ListenerProgress(this, new LogsProcessorProgressEventArgs(this.GetType().Name, message, level));
            }
        }

        private ILogSourceRefresher _logSourceRefresher;

        public ILogSourceRefresher LogSourceRefresher {
            get { return _logSourceRefresher; } 
            set {
                if (_logSourceRefresher != null)
                {
                    _logSourceRefresher.OnProgress -= processor_LogsProcessingProgress;
                }
                _logSourceRefresher = value;
                if (_logSourceRefresher != null)
                {
                    _logSourceRefresher.OnProgress += processor_LogsProcessingProgress;
                }
            } 
        
        }

        private bool _stopListening = false;

        public void StopListening() {
            _stopListening = true;
            _resetEvent.Set();
        }

        private AutoResetEvent _resetEvent = new AutoResetEvent(false);

        public void StartListening(List<string> inputPages) {
            _resetEvent.Reset();
            _stopListening = false;
            ParameterizedThreadStart pts = new ParameterizedThreadStart(LaunchProcessLoop);
            Thread workerThread = new Thread(pts);
            workerThread.Start(inputPages);
        }

        public string LogsFolder { get; set; }

        private void LaunchProcessLoop(object args) {
            List<string> inputPages = args as List<string>;
            if (args == null) { throw new InvalidOperationException("No input pages to process"); }

            processor.LogSource = new DirectoryLogSourceProvider(LogsFolder);
            processor.Initialize(inputPages);

            int cycleCounter = 0;
            bool done = false;
            while (!done && !_stopListening)
            {
                cycleCounter++;
                OnListenerProgress(string.Format("Starting processing cycle #{0}...", cycleCounter), LogLevel.Verbose);
                if (LogSourceRefresher != null)
                {
                    LogSourceRefresher.RefreshLogSource();
                }
                if (_stopListening) { break; }
                done = processor.ProcessLogs();
                if (done || _stopListening) { break; }
                OnListenerProgress(string.Format("Completed processing cycle #{0}. Sleeping for {1} milliseconds...", cycleCounter, SLEEP_DURATION), LogLevel.Verbose);
                _resetEvent.WaitOne(SLEEP_DURATION);
            }
            if (done) {
                OnListeningEnded();
            }
            else if (_stopListening)
            {
                OnListeningStopped();
            }
        }

        void processor_LogsProcessingProgress(object sender, LogsProcessorProgressEventArgs e)
        {
            OnListenerProgress(e.ProgressMessage, e.ProgressLevel);
        }
        
        public string GetOutput() {
            return processor.GetOutput();        
        }
    }
}
