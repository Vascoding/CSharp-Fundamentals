using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class InventoryTests
{

    [Test]
    public void Check_If_HeroInventory_Add_CommonItem_To_Dictionary()
    {
        HeroInventory heroInventory = new HeroInventory();
        var item = new CommonItem("maic", 1, 1, 1, 1, 1);
        var item2 = new CommonItem("mc", 1, 1, 1, 1, 1);
        Type type = heroInventory.GetType();

        FieldInfo[] fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo commonItemsStorage = fieldInfo.First(f => f.GetCustomAttributes<ItemAttribute>() != null);
        Dictionary<string, IItem> items = (Dictionary<string, IItem>)commonItemsStorage.GetValue(heroInventory);
        heroInventory.AddCommonItem(item);
        heroInventory.AddCommonItem(item2);

        Assert.AreEqual(2, items.Values.Count);
    }

    [Test]
    public void Totall_Damage_Bonus_Calculate_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("A", 1, 2, 3, 4, 5);
        var itemB = new CommonItem("B", 6, 7, 8, 9, 1);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);

        Assert.AreEqual(6, inventory.TotalDamageBonus);
    }

    [Test]
    public void Totall_Strenth_Bonus_Calculate_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("A", 1, 2, 3, 4, 5);
        var itemB = new CommonItem("B", 6, 7, 8, 9, 0);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);

        Assert.AreEqual(7, inventory.TotalStrengthBonus);
    }

    [Test]
    public void Chech_If_Item_Name_Is_Set_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("A", 1, 2, 3, 4, 5);
        

        inventory.AddCommonItem(itemA);
        

        Assert.AreEqual("A", itemA.Name);
    }

    [Test]
    public void Chech_If_Recipe_Name_Is_Set_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new RecipeItem("A", 1, 2, 3, 4, 5, new List<string>());


        inventory.AddRecipeItem(itemA);


        Assert.AreEqual("A", itemA.Name);
    }

    [Test]
    public void Check_Reciepe_Item_Crafts_Common_Item_And_Calculate_Damage_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("a", 1, 2, 3, 4, 5);
        var itemB = new CommonItem("b", 6, 7, 8, 9, 0);
        var parameters = new List<string>
        {
            "a",
            "b"
        };
        
        var recItemD = new RecipeItem("c", 20, 30, 40, 50, 60, parameters);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);
        inventory.AddRecipeItem(recItemD);

        Assert.AreEqual(60, inventory.TotalDamageBonus);
    }

    [Test]
    public void Check_Reciepe_Item_Crafts_Common_Item_And_Calculate_HitPoints_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("a", 1, 2, 3, 4, 5);
        var itemB = new CommonItem("b", 6, 7, 8, 9, 0);
        var parameters = new List<string>
        {
            "a",
            "b"
        };

        var recItemD = new RecipeItem("c", 20, 30, 40, 50, 60, parameters);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);
        inventory.AddRecipeItem(recItemD);

        Assert.AreEqual(50, inventory.TotalHitPointsBonus);
    }

    [Test]
    public void Check_Reciepe_Item_Crafts_Common_Item_And_Calculate_Inteligence_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("a", 1, 2, 3, 4, 5);
        var itemB = new CommonItem("b", 6, 7, 8, 9, 0);
        var parameters = new List<string>
        {
            "a",
            "b"
        };

        var recItemD = new RecipeItem("c", 20, 30, 40, 50, 60, parameters);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);
        inventory.AddRecipeItem(recItemD);

        Assert.AreEqual(40, inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void Check_Reciepe_Item_Crafts_Common_Item_And_Calculate_Agility_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("a", 1, 2, 3, 4, 5);
        var itemB = new CommonItem("b", 6, 7, 8, 9, 0);
        var parameters = new List<string>
        {
            "a",
            "b"
        };

        var recItemD = new RecipeItem("c", 20, 30, 40, 50, 60, parameters);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);
        inventory.AddRecipeItem(recItemD);

        Assert.AreEqual(30, inventory.TotalAgilityBonus);
    }

    [Test]
    public void Check_Reciepe_Item_Crafts_Common_Item_And_Calculate_strength_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("a", 1, 2, 3, 4, 5);
        var itemB = new CommonItem("b", 6, 7, 8, 9, 0);
        var parameters = new List<string>
        {
            "a",
            "b"
        };

        var recItemD = new RecipeItem("c", 20, 30, 40, 50, 60, parameters);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);
        inventory.AddRecipeItem(recItemD);

        Assert.AreEqual(20, inventory.TotalStrengthBonus);
    }

    [Test]
    public void Totall_Intelligence_Bonus_Calculate_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("A", 1, 1, 2, 2, 1);
        var itemB = new CommonItem("B", 1, 1, 13, 13, 1);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);

        Assert.AreEqual(15, inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void Totall_HitPoints_Bonus_Calculate_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("A", 1, 1, 1, 1, 1);
        var itemB = new CommonItem("B", 1, 1, 1, 1, 1);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);

        Assert.AreEqual(2, inventory.TotalHitPointsBonus);
    }

    [Test]
    public void Totall_Agility_Bonus_Calculate_Correct()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("A", 1, 1, 13, 2, 1);
        var itemB = new CommonItem("B", 1, 1, 2, 3, 1);

        inventory.AddCommonItem(itemA);
        inventory.AddCommonItem(itemB);

        Assert.AreEqual(2, inventory.TotalAgilityBonus);
    }

    [Test]
    public void Throll_Exeption_On_Adding_Items_With_Same_Name()
    {
        var inventory = new HeroInventory();
        var itemA = new CommonItem("A", 1, 1, 1, 1, 1);
        var itemB = new CommonItem("A", 1, 1, 1, 1, 1);

        inventory.AddCommonItem(itemA);
        

        Assert.Throws<ArgumentException>(() => inventory.AddCommonItem(itemB));
    }

    [Test]
    public void Throll_Exeption_On_Adding_Recipe_With_Same_Name()
    {
        var inventory = new HeroInventory();
        var itemA = new RecipeItem("A", 1, 1, 1, 1, 1, new List<string>
        {
            "a",
            "b"
        });
        var itemB = new RecipeItem("A", 1, 1, 1, 1, 1, new List<string>
        {
            "a",
            "b"
        });

        inventory.AddRecipeItem(itemA);


        Assert.Throws<ArgumentException>(() => inventory.AddRecipeItem(itemB));
    }

    [Test]
    public void Check_Combine_Method_In_HeroInventory()
    {
        var inventory = new HeroInventory();
        var item1 = new CommonItem("a", 1, 1, 1, 1, 1);
        var item2 = new CommonItem("b", 1, 1, 1, 1, 1);
        var item3 = new CommonItem("c", 1, 1, 1, 1, 1);
        var item4 = new CommonItem("d", 1, 1, 1, 1, 1);
        var combine = new RecipeItem("A", 1, 1, 1, 1, 1, new List<string>
        {
            "a",
            "b"
        });

        inventory.AddCommonItem(item1);
        inventory.AddCommonItem(item2);
        inventory.AddCommonItem(item3);
        inventory.AddCommonItem(item4);
        inventory.AddRecipeItem(combine);
        Type type = inventory.GetType();

        FieldInfo[] fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo commonItemsStorage = fieldInfo.First(f => f.GetCustomAttributes<ItemAttribute>() != null);
        Dictionary<string, IItem> items = (Dictionary<string, IItem>)commonItemsStorage.GetValue(inventory);
        Assert.AreEqual(3, items.Values.Count);
    }

    [Test]
    public void Throw_Exeption_If_AddCommonItem_Send_Null()
    {
        var inventory = new HeroInventory();
      
        Assert.That(
                () => inventory.AddCommonItem(null),
                Throws.InstanceOf<NullReferenceException>());
    }
    [Test]
    public void Throw_Exeption_If_AddRecipeItem_Not_Send_Null()
    {
        var inventory = new HeroInventory();

        Assert.That(
                () => inventory.AddRecipeItem(null),
                Throws.InstanceOf<NullReferenceException>());
    }

    [Test]
    public void Chech_Return_Type_Of_Method_TotalStrengthBonus()
    {
        var inventory = new HeroInventory();
        var result = inventory.TotalStrengthBonus;
        Assert.That(result, Is.TypeOf<long>());
    }

    [Test]
    public void Chech_Return_Type_Of_Method_TotalAgilityBonus()
    {
        var inventory = new HeroInventory();
        var result = inventory.TotalAgilityBonus;
        Assert.That(result, Is.TypeOf<long>());
    }

    [Test]
    public void Chech_Return_Type_Of_Method_TotalIntelligenceBonus()
    {
        var inventory = new HeroInventory();
        var result = inventory.TotalIntelligenceBonus;
        Assert.That(result, Is.TypeOf<long>());
    }

    [Test]
    public void Chech_Return_Type_Of_Method_TotalHitPointsBonus()
    {
        var inventory = new HeroInventory();
        var result = inventory.TotalHitPointsBonus;
        Assert.That(result, Is.TypeOf<long>());
    }

    [Test]
    public void Chech_Return_Type_Of_Method_TotalDamageBonus()
    {
        var inventory = new HeroInventory();
        var result = inventory.TotalDamageBonus;
        Assert.That(result, Is.TypeOf<long>());
    }

    [Test]
    public void Chech_If_Item_Storage_Is_Empty_Due_To_Initialization()
    {
        HeroInventory heroInventory = new HeroInventory();
       
        Type type = heroInventory.GetType();

        FieldInfo[] fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo commonItemsStorage = fieldInfo.First(f => f.GetCustomAttributes<ItemAttribute>() != null);
        Dictionary<string, IItem> items = (Dictionary<string, IItem>)commonItemsStorage.GetValue(heroInventory);
        

        Assert.IsEmpty(items);
    }

    [Test]
    public void Chech_Add_Recipe_To_Inventory_Without_Making_Item()
    {
        HeroInventory heroInventory = new HeroInventory();
        var item1 = new CommonItem("a", 1, 1, 1, 1, 1);
        var item2 = new CommonItem("b", 1, 1, 1, 1, 1);
        

        heroInventory.AddCommonItem(item1);
        heroInventory.AddCommonItem(item2);
        var combine = new RecipeItem("A", 1, 1, 1, 1, 1, new List<string>
        {
            "a",
            "b",
            "c"
        });
        heroInventory.AddRecipeItem(combine);
        Type type = heroInventory.GetType();

        FieldInfo[] fieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        FieldInfo commonItemsStorage = fieldInfo.First(f => f.GetCustomAttributes<ItemAttribute>() != null);
        Dictionary<string, IItem> items = (Dictionary<string, IItem>)commonItemsStorage.GetValue(heroInventory);

        
        Assert.AreEqual(2, items.Count);

        var item3 = new CommonItem("c", 1, 1, 1, 1, 1);
        heroInventory.AddCommonItem(item3);
        Assert.AreEqual(1, items.Values.Count);
    }
}


