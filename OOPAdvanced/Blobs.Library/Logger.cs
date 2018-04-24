using Blobs.Library.Interfaces;

namespace Blobs.Library
{
    public class Logger : ILoggable
    {
        private IAppendable appender;

        public Logger(IAppendable consoleAppender)
        {
            this.appender = consoleAppender;
        }
        
        public void Error(string dateTime, string message)
        {
            this.appender.Append(dateTime, "Error", message);
        }

        public void Info(string dateTime, string message)
        {
            this.appender.Append(dateTime, "Info" , message);
        }
    }
}