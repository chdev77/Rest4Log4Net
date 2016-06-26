using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using log4net.Appender;

namespace Rest4Log4NetAppender
{
    public class Appender : AppenderSkeleton
    {
        private Queue<LoggingEvent> _loggingEvents = new Queue<LoggingEvent>();
        public string postUrl { get; set; }
        public int messageCountBuffer { get; set; }
        public int messageBufferSeconds { get; set; }
        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                QueueLog(loggingEvent);
            }
            catch (Exception ex)
            {
                //hide any exceptions to prevent logging exceptions/bottlenecks
            }
        }
        private void QueueLog(LoggingEvent loggingEvent)
        {
            _loggingEvents.Enqueue(loggingEvent);
        }

    }
}
