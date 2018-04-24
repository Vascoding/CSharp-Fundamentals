using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        public static void Main()
        {

            List<Team> teams = new List<Team>();
            while (true)
            {
                try
                {
                    var input = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if (input[0].Equals("END"))
                    {
                        break;
                    }

                    switch (input[0])
                    {
                        case "Team":
                            Team team = new Team(input[1]);
                            teams.Add(team);
                            break;
                        case "Add":
                            var t = teams.FirstOrDefault(n => n.Name == input[1]);
                            if (t.Equals(null))
                            {
                                Console.WriteLine($"Team {input[1]} does not exist.");
                            }
                            else
                            {
                                t.AddPlayer(new Player(input[2], new Stats(int.Parse(input[3]), int.Parse(input[4]), int.Parse(input[5]), int.Parse(input[6]), int.Parse(input[7]))));
                            }
                            break;
                        case "Remove":
                            var playerToRemove = teams.First(n => n.Name == input[1]);
                            playerToRemove.RemovePlayer(input[2]);
                            break;
                        case "Rating":
                            var teamRating = teams.FirstOrDefault(n => n.Name == input[1]);
                            if (!teams.Any(a => a.Name == input[1]))
                            {
                                throw new ArgumentException($"Team {input[1]} does not exist.");
                            }
                            Console.WriteLine($"{teamRating.Name} - {teamRating.Rating()}");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}

