using System;
using System.Collections.Generic;

public class HeroCommand : Command
{
    private List<string> args;
    private HeroManager manager;
    public HeroCommand(List<string> args, HeroManager heroManager)
    {
        this.args = args;
        this.manager = heroManager;
    }

    public override string Execute()
    {
        return this.manager.AddHero(this.args);
    }
}
