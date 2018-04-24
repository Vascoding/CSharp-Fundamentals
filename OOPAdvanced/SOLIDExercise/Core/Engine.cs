using System;
using System.Collections.Generic;
using System.Linq;
using _02.Blobs.Entities;
using _02.Blobs.Entities.Attacks;
using _02.Blobs.Interfaces;

namespace _02.Blobs.Core
{
    public class Engine
    {
        private const string BehaviorNamespace = "_02.Blobs.Entities.Behaviors.";
        private const string AttackNamespace = "_02.Blobs.Entities.Attacks.";
        public void Run()
        {
            List<Blob> blobs = new List<Blob>();
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    
                    switch (commandName)
                    {
                        case "create":
                            var name = data[1];
                            var health = int.Parse(data[2]);
                            var damage = int.Parse(data[3]);
                            var behaviorName = data[4];
                            var attackName = data[5];

                            Type behaviorType = Type.GetType(BehaviorNamespace + behaviorName);
                            IBehavior behavior = (IBehavior)Activator.CreateInstance(behaviorType);
                            Type attackType = Type.GetType(AttackNamespace + attackName);
                            Attack attack = (Attack)Activator.CreateInstance(attackType);

                            blobs.Add(new Blob(name, health, damage, behavior, attack));
                            break;
                        case "attack":
                            var attacker = blobs.FirstOrDefault(n => n.Name == data[1]);
                            var target = blobs.FirstOrDefault(n => n.Name == data[2]);
                            attacker.Attack(target);
                            break;
                        case "status":
                            Console.WriteLine(string.Join(Environment.NewLine, blobs));
                            break;
                        case "drop":
                            return;
                    }
                    foreach (Blob blob in blobs)
                    {
                        blob.MoveToNextTurn();
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