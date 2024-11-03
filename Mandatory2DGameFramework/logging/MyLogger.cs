using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.logging
{
    // TODO: Create the MyLogger class and make it static
    public class MyLogger
    {
        private TraceSource _traceSource;

        private MyLogger()
        {
            _traceSource = new TraceSource("AppLogs");
            _traceSource.Switch = new SourceSwitch("sourceSwitch", "All");

            _traceSource.Listeners.Add(new TextWriterTraceListener("AppLogs.txt"));
        }

        private static MyLogger _instance;
        public static MyLogger Instance { 
            get 
            { 
                if (_instance == null)
                {
                    _instance = new MyLogger();
                }
                return _instance;
            } 
        }

        public void AddListener(TraceListener listener)
        {
            _traceSource.Listeners.Add(listener);
        }

        public void RemoveListener(TraceListener listener)
        {
            _traceSource.Listeners.Remove(listener);
        }

        public void LogInformation(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Information, 0, message);
        }

        public void LogWarning(string message) 
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 0, message);
        }

        public void LogError(string message) 
        {
            _traceSource.TraceEvent(TraceEventType.Error, 0, message);
        }


    }
}
