using System;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;

    public Engine()
    {
        this.draftManager = new DraftManager();
    }

    public void Run()
    {
        string input;
        while (true)
        {
            input = Console.ReadLine();
            var commandSplit = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Execute(commandSplit);
            if (input == "Shutdown")
            {
                return;
            }
        }


    }

    private void Execute(string[] commandSplit)
    {
        var command = commandSplit[0];

        try
        {
            switch (command)
            {
                case "RegisterHarvester":
                    var argsHarvester = commandSplit.Skip(1).ToList();
                    Console.WriteLine(draftManager.RegisterHarvester(argsHarvester));
                    break;
                case "RegisterProvider":
                    var argsProvider = commandSplit.Skip(1).ToList();
                    Console.WriteLine(draftManager.RegisterProvider(argsProvider));
                    break;
                case "Day":
                    Console.WriteLine(draftManager.Day());
                    break;
                case "Mode":
                    var mode = commandSplit.Skip(1).ToList();
                    Console.WriteLine(draftManager.Mode(mode));
                    break;
                case "Check":
                    var check = commandSplit.Skip(1).ToList();
                    Console.WriteLine(draftManager.Check(check));
                    break;
                case "Shutdown":
                    Console.WriteLine(draftManager.ShutDown());
                    break;
            }
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

    }
}

