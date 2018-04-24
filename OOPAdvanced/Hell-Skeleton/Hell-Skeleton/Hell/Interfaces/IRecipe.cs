using System.Collections.Generic;

public interface IRecipe
{
    string Name { get; }
    int StrengthBonus { get; }
    int AgilityBonus { get; }
    int IntelligenceBonus { get; }
    int HitPointsBonus { get; }
    int DamageBonus { get; }
    List<string> RequiredItems { get; }
}
