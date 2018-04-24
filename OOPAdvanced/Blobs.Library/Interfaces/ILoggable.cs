namespace Blobs.Library.Interfaces
{
    public interface ILoggable
    {
        void Error(string dateTime, string message);
        void Info(string dateTime, string message);
    }
}