namespace OnlineRadioDatabase
{
    public class Radio
    {
        private string artistName;
        private string songName;
        private int minutes;
        private int seconds;

        public Radio(string artistName, string songName, int minutes, int seconds)
        {
            this.ArtistName = artistName;
            this.SongName = songName;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public string ArtistName
        {
            get { return this.artistName; }
            set
            {
                if (value.Length < 3 || value.Length > 20)
                {
                    throw new InvalidArtistNameExeption();
                }
                this.artistName = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            set
            {
                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidSongNameExeption();
                }
                this.songName = value;
            }
        }

        public int Minutes
        {
            get { return this.minutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesExeption();
                }
                this.minutes = value;
            }
        }

        public int Seconds
        {
            get { return this.seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }
                this.seconds = value;
            }
        }
    }
}
