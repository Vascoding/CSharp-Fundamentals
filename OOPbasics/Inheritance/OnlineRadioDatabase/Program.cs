using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineRadioDatabase
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            List<Radio> songs = new List<Radio>();
            for (int i = 0; i < n; i++)
            {
                try
                {
                    var input = Console.ReadLine().Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries);
                    var artistName = input[0];
                    var songName = input[1];
                    var splitTime = input[2].Split(new []{':'}, StringSplitOptions.RemoveEmptyEntries);
                    int digit1;
                    int digit2;
                    if (int.TryParse(splitTime[0], out digit1) && int.TryParse(splitTime[1], out digit2))
                    {
                        songs.Add(new Radio(artistName, songName, digit1, digit2));
                        Console.WriteLine("Song added.");
                    }
                    else
                    {
                        throw new InvalidSongLengthExeption();
                    }
                }
                catch (InvalidSongExeption e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine($"Songs added: {songs.Count}");
            var sumOfSeconds = songs.Sum(a => a.Minutes) * 60 + songs.Sum(s => s.Seconds);
            TimeSpan t = TimeSpan.FromSeconds(sumOfSeconds);

            string answer = string.Format("{0}h {1}m {2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds
                            );

            Console.WriteLine($"Playlist length: {answer}");
        }
    }
}
