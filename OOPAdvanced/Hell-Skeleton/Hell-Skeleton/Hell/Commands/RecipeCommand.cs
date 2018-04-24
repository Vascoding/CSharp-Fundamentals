using System.Collections.Generic;

public class RecipeCommand : Command
{
    private List<string> args;
    private HeroManager manager;
    public RecipeCommand(List<string> args, HeroManager heroManager)
    {
        this.args = args;
        this.manager = heroManager;
    }
    public override string Execute()
    {
        return this.manager.AddRecipeItemToHero(args);
    }
}
