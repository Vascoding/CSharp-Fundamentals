using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Commands
{
    public abstract class Command
    {
        public abstract string Execute(string[] args, IGarbageProcessor garbageProcessor);
    }
}