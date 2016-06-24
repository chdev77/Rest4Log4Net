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
    public class RestAppender : AppenderSkeleton
    {
        public string PostUrl { get; set; }

        protected override void Append(LoggingEvent loggingEvent)
        {
            throw new NotImplementedException();
        }
    }
}
