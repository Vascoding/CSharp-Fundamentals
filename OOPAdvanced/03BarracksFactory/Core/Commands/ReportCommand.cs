using _03BarracksFactory.Attributes;
using _03BarracksFactory.Contracts;

namespace _03BarracksFactory.Core.Commands
{
    public class ReportCommand : Command
    {
        [Inject]
        private IRepository repository;
        public ReportCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}