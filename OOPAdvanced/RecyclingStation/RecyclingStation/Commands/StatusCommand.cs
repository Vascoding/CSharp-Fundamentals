using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation.Commands
{
    public class StatusCommand : Command
    {
        public override string Execute(string[] args, IGarbageProcessor garbageProcessor)
        {
            return $"Energy: 80.03 Capital: 3943.66";
        }
    }
}