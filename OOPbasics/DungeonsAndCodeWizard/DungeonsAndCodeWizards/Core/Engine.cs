using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private IWriter writer;
    private IReader reader;
    private DungeonMaster dungeonMaster;
    public Engine()
    {
        this.writer = new Writer();
        this.reader = new Reader();
        this.dungeonMaster = new DungeonMaster();
    }

    public void Run()
    {
        while (!this.dungeonMaster.IsGameOver())
        {
            var inputString = this.reader.ReadLine();

            if (string.IsNullOrEmpty(inputString))
            {
                break;
            }
            var input = inputString.Split();

            var command = input[0];
            try
            {
                switch (command)
                {
                    case "JoinParty":
                        this.writer.WriteLine(this.dungeonMaster.JoinParty(input.Skip(1).ToArray()));
                        break;
                    case "AddItemToPool":
                        this.writer.WriteLine(this.dungeonMaster.AddItemToPool(input.Skip(1).ToArray()));
                        break;
                    case "UseItemOn":
                        this.writer.WriteLine(this.dungeonMaster.UseItemOn(input.Skip(1).ToArray()));
                        break;
                    case "UseItem":
                        this.writer.WriteLine(this.dungeonMaster.UseItem(input.Skip(1).ToArray()));
                        break;
                    case "GiveCharacterItem":
                        this.writer.WriteLine(this.dungeonMaster.GiveCharacterItem(input.Skip(1).ToArray()));
                        break;
                    case "PickUpItem":
                        this.writer.WriteLine(this.dungeonMaster.PickUpItem(input.Skip(1).ToArray()));
                        break;
                    case "GetStats":
                        this.writer.WriteLine(this.dungeonMaster.GetStats());
                        break;
                    case "Attack":
                        this.writer.WriteLine(this.dungeonMaster.Attack(input.Skip(1).ToArray()));
                        break;
                    case "Heal":
                        this.writer.WriteLine(this.dungeonMaster.Heal(input.Skip(1).ToArray()));
                        break;
                    case "EndTurn":
                        this.writer.WriteLine(this.dungeonMaster.EndTurn(input));
                        break;
                    case "IsGameOver":
                        this.writer.WriteLine(this.dungeonMaster.IsGameOver() ? "true" : "false");
                        break;
                    default:
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                this.writer.WriteLine("Parameter Error: " + ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                this.writer.WriteLine("Invalid Operation: " + ex.Message);
            }
           
        }
        this.writer.WriteLine("Final stats:" + Environment.NewLine + this.dungeonMaster.GetStats());
    }
}

