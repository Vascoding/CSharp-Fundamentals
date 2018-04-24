using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : Manager
{
    public Dictionary<string, AbstractHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, AbstractHero>();
    }
  
    public string AddHero(List<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type clazz = Type.GetType(heroType);
            var constructors = clazz.GetConstructors();
            AbstractHero hero = (AbstractHero) constructors[0].Invoke(new object[] {heroName});
            this.heroes.Add(heroName, hero);
            result = String.Format(Constants.HeroCreateMessage, hero.GetType().Name, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddRecipeItemToHero(List<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        var itemsRequired = arguments.Skip(7).ToList();
        IRecipe recipeItem = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus, itemsRequired);
        var hero = this.heroes.FirstOrDefault(h => h.Key == heroName);
       
        hero.Value.Inventory.AddRecipeItem(recipeItem);

        result = string.Format(Constants.RecipeCreatedMessage, recipeItem.Name, heroName);
        return result;
    }

    public string AddItemToHero(List<string> arguments)
    {
        string result = null;
        
        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        CommonItem newItem = new CommonItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus,
            damageBonus);
        var hero = this.heroes.FirstOrDefault(h => h.Key == heroName);
        
        hero.Value.Inventory.AddCommonItem(newItem);
        result = string.Format(Constants.ItemCreateMessage, newItem.Name, heroName);
        return result;
    }
    
    public string Inspect(List<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }
}