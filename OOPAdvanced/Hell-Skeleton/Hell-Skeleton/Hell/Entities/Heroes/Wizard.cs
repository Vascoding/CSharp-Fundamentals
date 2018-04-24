using System.Collections.Generic;

public class Wizard : AbstractHero
{
    private IInventory inventory;
    public Wizard(string name) : base(name)
    {
        this.inventory = new HeroInventory();
        this.Strength = 25;
        this.Agility = 25;
        this.Intelligence = 100;
        this.HitPoints = 100;
        this.Damage = 250;
    }
    
    public override void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }
}
