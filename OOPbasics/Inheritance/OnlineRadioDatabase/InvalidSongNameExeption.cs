namespace OnlineRadioDatabase
{
    class InvalidSongNameExeption : InvalidSongExeption
    {
        protected override string ExeptionMessage => "Song name should be between 3 and 30 symbols.";
    }
}
