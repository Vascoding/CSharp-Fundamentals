using System.Collections.Generic;

public class Assassin : AbstractHero
{
    private IInventory inventory;
    public Assassin(string name) : base(name)
    {
        this.inventory = new HeroInventory();
        this.Strength = 25;
        this.Agility = 100;
        this.Intelligence = 15;
        this.HitPoints = 150;
        this.Damage = 300;
    }
    
    public override void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }
}
