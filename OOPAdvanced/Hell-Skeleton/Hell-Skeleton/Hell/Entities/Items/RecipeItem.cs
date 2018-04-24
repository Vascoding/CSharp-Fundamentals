using System.Collections.Generic;

public class RecipeItem : IRecipe
{
    private List<string> commonItems;
    public RecipeItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus, List<string> requiredItems)
    {
        Name = name;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntelligenceBonus = intelligenceBonus;
        HitPointsBonus = hitPointsBonus;
        DamageBonus = damageBonus;
        this.RequiredItems = requiredItems;
    }
    public string Name { get; }
    public int StrengthBonus { get; }
    public int AgilityBonus { get; }
    public int IntelligenceBonus { get; }
    public int HitPointsBonus { get; }
    public int DamageBonus { get; }

    public List<string> RequiredItems
    {
        get { return this.commonItems; }
        private set { this.commonItems = value; }
    }
}
