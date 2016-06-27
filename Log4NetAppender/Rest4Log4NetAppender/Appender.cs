using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using log4net.Appender;
using Rest4Log4NetModels;
using RestSharp;

namespace Rest4Log4NetAppender
{
    public class Appender : AppenderSkeleton
    {
        private Queue<LogMessage> _loggingEvents = new Queue<LogMessage>();
        public string postUrl { get; set; }
        public int messageCountBuffer { get; set; }
        public int messageBufferSeconds { get; set; }
        protected override void Append(LoggingEvent loggingEvent)
        {
            try
            {
                QueueLog(new LogMessage()
                {
                    Exception = loggingEvent.GetExceptionString(),
                    Level = loggingEvent.Level.Name,
                    Message = loggingEvent.RenderedMessage,
                    Thread = loggingEvent.ThreadName,
                    Timestamp = loggingEvent.TimeStamp.ToString()
                });
            }
            catch (Exception ex)
            {
                //hide any exceptions to prevent logging exceptions/bottlenecks
            }
        }
        private void QueueLog(LogMessage message)
        {
            _loggingEvents.Enqueue(message);

            var client = new RestClient(postUrl);
            var request = new RestRequest();
            request.Resource = "api/Logger";
            request.AddJsonBody(message);

            client.ExecuteAsPost(request, "POST");

            var temp = 1;
        }

    }
}
