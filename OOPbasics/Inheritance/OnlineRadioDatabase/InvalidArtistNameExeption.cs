namespace OnlineRadioDatabase
{
    class InvalidArtistNameExeption : InvalidSongExeption
    {
        public override string Message => "Artist name should be between 3 and 20 symbols.";
    }
}
