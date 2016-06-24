using log4net;
using System;

namespace Log4NetAppender
{
    public static class Logger
    {
        private static ILog _activity = LogManager.GetLogger("Activity");
        private static ILog _exception = LogManager.GetLogger("Exception");
        public static void Activity(string message)
        {
            _activity.Info(message);
        }
        public static void Exception(string message, Exception ex)
        {
            _exception.Error(message, ex);
        }
    }
}
