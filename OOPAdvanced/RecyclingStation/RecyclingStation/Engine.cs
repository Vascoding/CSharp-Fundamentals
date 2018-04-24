using System;
using System.Linq;
using RecyclingStation.Commands;
using RecyclingStation.WasteDisposal;

namespace RecyclingStation
{
    public class Engine
    {
        private readonly string nameSpace = "RecyclingStation.Commands.";
        private readonly string cmdPrefix = "Command";

        private GarbageProcessor garbageProcessor;

        public Engine()
        {
            this.garbageProcessor = new GarbageProcessor();
        }
        public void Run()
        {
            while (true)
            {
                var commandArgs = Console.ReadLine().Split(new []{'|', ' '}, StringSplitOptions.RemoveEmptyEntries);
                var commandType = commandArgs[0];

                Type cmdType = Type.GetType(nameSpace + commandType + cmdPrefix);
                Command cmd = (Command)Activator.CreateInstance(cmdType);

                cmd.Execute(commandArgs.Skip(1).ToArray(), garbageProcessor);
            }
        }
    }
}
