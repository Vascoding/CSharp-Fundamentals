namespace OnlineRadioDatabase
{
    class InvalidSongSecondsException : InvalidSongExeption
    {
        protected override string ExeptionMessage => "Song seconds should be between 0 and 59.";
    }
}
