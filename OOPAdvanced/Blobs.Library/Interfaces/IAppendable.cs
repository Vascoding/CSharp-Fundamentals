namespace Blobs.Library.Interfaces
{
    public interface IAppendable
    {
        void Append(string dateTime, string reportLevel , string message);
    }
}