using System.Collections.Generic;

public class InspectCommand : Command
{
    private List<string> args;
    private HeroManager manager;
    public InspectCommand(List<string> args, HeroManager heroManager)
    {
        this.args = args;
        this.manager = heroManager;
    }
    public override string Execute()
    {
        return this.manager.Inspect(args);
    }
}
