using Blobs.Library.Interfaces;

namespace Blobs.Library
{
    public class LogFile : ILoggable
    {
        public void Error(string dateTime, string message)
        {
            throw new System.NotImplementedException();
        }

        public void Info(string dateTime, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}