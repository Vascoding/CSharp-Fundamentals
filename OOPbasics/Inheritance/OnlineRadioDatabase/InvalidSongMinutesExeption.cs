namespace OnlineRadioDatabase
{
    class InvalidSongMinutesExeption : InvalidSongExeption
    {
        protected override string ExeptionMessage => "Song minutes should be between 0 and 14.";
    }
}
