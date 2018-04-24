using Blobs.Library.Interfaces;

namespace Blobs.Library
{
    public class FileAppender : IAppendable
    {
        private ILayout layout;
        
        public FileAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public ILoggable File { get; set; }
       
        public void Append(string dateTime, string reportLevel, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}