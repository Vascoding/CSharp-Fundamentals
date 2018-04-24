using System;
using Blobs.Library.Interfaces;

namespace Blobs.Library
{
    public class ConsoleAppender : IAppendable
    {
        private ILayout layout;

        public ConsoleAppender(ILayout layout)
        {
            this.layout = layout;
        }
        
        public void Append(string dateTime, string reportLevel, string message)
        {
            Console.WriteLine(this.layout.Format(dateTime, reportLevel, message));
        }
    }
}