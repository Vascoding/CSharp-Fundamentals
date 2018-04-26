public class ArmorRepairKit : Item
{
    public ArmorRepairKit()
        : base(weight: 10)
    {
    }

    public override void AffectCharacter(Character character)
    {
        base.AffectCharacter(character);
        character.Armor = character.BaseArmor;
    }
}