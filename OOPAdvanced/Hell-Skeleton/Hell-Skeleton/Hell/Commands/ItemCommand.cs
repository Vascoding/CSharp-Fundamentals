using System.Collections.Generic;


public class ItemCommand : Command
{
    private List<string> args;
    private HeroManager manager;
    public ItemCommand(List<string> args, HeroManager heroManager)
    {
        this.args = args;
        this.manager = heroManager;
    }
    public override string Execute()
    {
        return this.manager.AddItemToHero(args);
    }

}
