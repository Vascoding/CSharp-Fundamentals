using Blobs.Library.Interfaces;

namespace Blobs.Library
{
    public class SimpleLayout : ILayout
    {
        public string Format(string dateTime, string reportLevel, string message)
        {
            return string.Format("{0} - {1} - {2}", dateTime, reportLevel, message);
        }
    }
}
