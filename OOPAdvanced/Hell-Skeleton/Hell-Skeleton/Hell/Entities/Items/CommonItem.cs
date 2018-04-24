
public class CommonItem : IItem
{
    public CommonItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus, int hitPointsBonus, int damageBonus)
    {
        Name = name;
        StrengthBonus = strengthBonus;
        AgilityBonus = agilityBonus;
        IntelligenceBonus = intelligenceBonus;
        HitPointsBonus = hitPointsBonus;
        DamageBonus = damageBonus;
    }
    public string Name { get; }
    public int StrengthBonus { get; }
    public int AgilityBonus { get; }
    public int IntelligenceBonus { get; }
    public int HitPointsBonus { get; }
    public int DamageBonus { get; }
}
