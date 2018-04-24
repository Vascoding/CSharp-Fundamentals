using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            List<Pokemon> pokemons = new List<Pokemon>();
            while (true)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (input[0].Equals("Tournament"))
                {
                    break;
                }

                var trainerName = input[0];
                var pokemonName = input[1];
                var pokemonElement = input[2];
                var pokemonHealth = int.Parse(input[3]);
                Pokemon pokemon = new Pokemon
                {
                    Name = pokemonName,
                    Element = pokemonElement,
                    Health = pokemonHealth
                };
                pokemons.Add(pokemon);
                if (trainers.Any(a => a.Name == trainerName))
                {
                    trainers.FirstOrDefault(n => n.Name == trainerName).Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer
                    {
                        Name = trainerName,
                    };
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
            }

            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("End"))
                {
                    break;
                }
                if (input.Equals("Fire"))
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(p => p.Element == "Fire"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.Pokemons.Count; i++)
                            {
                                trainer.Pokemons[i].Health -= 10;
                                if (trainer.Pokemons[i].Health <= 0)
                                {
                                    trainer.Pokemons.Remove(trainer.Pokemons[i]);
                                    i--;
                                }
                            }
                        }
                    }
                }

                if (input.Equals("Water"))
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(p => p.Element == "Water"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.Pokemons.Count; i++)
                            {
                                trainer.Pokemons[i].Health -= 10;
                                if (trainer.Pokemons[i].Health <= 0)
                                {
                                    trainer.Pokemons.Remove(trainer.Pokemons[i]);
                                    i--;
                                }
                            }
                        }
                    }
                }

                if (input.Equals("Electricity"))
                {
                    foreach (var trainer in trainers)
                    {
                        if (trainer.Pokemons.Any(p => p.Element == "Electricity"))
                        {
                            trainer.Badges++;
                        }
                        else
                        {
                            for (int i = 0; i < trainer.Pokemons.Count; i++)
                            {
                                trainer.Pokemons[i].Health -= 10;
                                if (trainer.Pokemons[i].Health <= 0)
                                {
                                    trainer.Pokemons.Remove(trainer.Pokemons[i]);
                                    i--;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(a => a.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
