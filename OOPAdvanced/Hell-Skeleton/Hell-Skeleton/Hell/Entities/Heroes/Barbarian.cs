using System.Collections.Generic;

public class Barbarian : AbstractHero
{
    private IInventory inventory;
    public Barbarian(string name) : base(name)
    {
        this.inventory = new HeroInventory();
        this.Strength = 90;
        this.Agility = 25;
        this.Intelligence = 10;
        this.HitPoints = 350;
        this.Damage = 150;
    }
    
    public override void AddRecipe(IRecipe recipe)
    {
        this.inventory.AddRecipeItem(recipe);
    }
}
