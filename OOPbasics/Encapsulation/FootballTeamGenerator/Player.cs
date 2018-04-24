using System;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stats stats;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }

        public Stats Stats
        {
            get { return this.stats; }
            set { this.stats = value; }
        }
        public int AverageStats()
        {
            return (int)Math.Round((this.stats.Dribble + this.stats.Endurance + this.stats.Passing + this.stats.Shooting + this.stats.Sprint) / (double)5);
        }
    }
}
