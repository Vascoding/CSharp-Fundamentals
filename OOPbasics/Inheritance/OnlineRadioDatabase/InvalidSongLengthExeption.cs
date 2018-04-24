namespace OnlineRadioDatabase
{
    class InvalidSongLengthExeption : InvalidSongExeption
    {
        protected override string ExeptionMessage => "Invalid song length.";
    }
}
