using System;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Commands
{
    public class TimeToRecycleCommand : Command
    {
        public override string Execute(string[] args, IGarbageProcessor garbageProcessor)
        {
            Environment.Exit(0);
            return "";
        }
    }
}