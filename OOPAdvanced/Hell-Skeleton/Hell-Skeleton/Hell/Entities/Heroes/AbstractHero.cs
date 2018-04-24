using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

public abstract class AbstractHero : IHero
{
    private IInventory inventory;
    protected List<IItem> items;
    private string name;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected AbstractHero(string name)
    {
        this.Name = name;
        this.inventory = new HeroInventory();
        this.items = new List<IItem>();
    }

    public IInventory Inventory
    {
        get { return this.inventory; }
        set { this.inventory = value; }
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public long Strength
    {
        get { return this.strength + this.inventory.TotalStrengthBonus; }
        protected set { this.strength = value; }
       
    }

    public long Agility
    {
        get { return this.agility + this.inventory.TotalAgilityBonus; }
        protected set { this.agility = value; }

    }

    public long Intelligence
    {
        get { return this.intelligence + this.inventory.TotalIntelligenceBonus; }
        protected set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.inventory.TotalHitPointsBonus; }
        protected set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.inventory.TotalDamageBonus; }
        protected set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.HitPoints + this.Damage; }
    }

    //REFLECTION
    public ICollection<IItem> Items
    {
        get
        {
            Type type = this.inventory.GetType();
            
            FieldInfo[] fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo commonItemsStorage = fieldInfo.First(f => f.GetCustomAttributes<ItemAttribute>() != null);
            
            
            Dictionary<string, IItem> items = (Dictionary<string, IItem>)commonItemsStorage.GetValue(this.inventory);
           
            return items.Values;
        }
    }

    public abstract void AddRecipe(IRecipe recipe);
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}");
        sb.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        sb.AppendLine($"Strength: {this.Strength}");
        sb.AppendLine($"Agility: {this.Agility}");
        sb.AppendLine($"Intelligence: {this.Intelligence}");
        if (this.Items.Count == 0)
        {
            sb.AppendLine("Items: None");
        }
        else
        {
            sb.AppendLine("Items:");
            foreach (IItem item in this.Items)
            {
                sb.AppendLine($"###Item: {item.Name}");
                sb.AppendLine($"###+{item.StrengthBonus} Strength");
                sb.AppendLine($"###+{item.AgilityBonus} Agility");
                sb.AppendLine($"###+{item.IntelligenceBonus} Intelligence");
                sb.AppendLine($"###+{item.HitPointsBonus} HitPoints");
                sb.AppendLine($"###+{item.DamageBonus} Damage");
            }
        }
        
        return sb.ToString().Trim();
    }
}