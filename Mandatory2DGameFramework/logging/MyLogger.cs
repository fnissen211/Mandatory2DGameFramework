using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandatory2DGameFramework.logging
{
    /// <summary>
    /// This class is a singleton class that is used for logging information, warnings and errors
    /// </summary>
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
        /// <summary>
        /// A property that returns the instance of the MyLogger class
        /// </summary>
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

        /// <summary>
        /// This method removes a listener from the TraceSource
        /// </summary>
        /// <param name="listener">The listener that needs to be added</param>
        public void RemoveListener(TraceListener listener)
        {
            _traceSource.Listeners.Remove(listener);
            _traceSource.Flush();
        }

        /// <summary>
        /// This method logs information
        /// </summary>
        /// <param name="message">The message that needs to be logged</param>
        public void LogInformation(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Information, 0, message);
            _traceSource.Flush();
        }

        /// <summary>
        /// This method logs a warning
        /// </summary>
        /// <param name="message">The message that needs to be logged</param>
        public void LogWarning(string message) 
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 100, message);
            _traceSource.Flush();
        }

        /// <summary>
        /// This method logs an error
        /// </summary>
        /// <param name="message">The message that needs to be logged</param>
        public void LogError(string message) 
        {
            _traceSource.TraceEvent(TraceEventType.Error, 400, message);
            _traceSource.Flush();
        }

        /// <summary>
        /// This method closes the TraceSource
        /// </summary>
        public void Close()
        {
            _traceSource.Close();
        }
    }
}
