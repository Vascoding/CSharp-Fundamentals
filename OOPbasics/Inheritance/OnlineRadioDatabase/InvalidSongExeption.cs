using System;

namespace OnlineRadioDatabase
{
    public class InvalidSongExeption : ArgumentException
    {
        private string exeptionMessage = "Invalid song.";

        protected virtual string ExeptionMessage
        {
            get { return this.exeptionMessage; }
            set { this.exeptionMessage = value; }
        }
        public override string Message => ExeptionMessage;
    }
}
