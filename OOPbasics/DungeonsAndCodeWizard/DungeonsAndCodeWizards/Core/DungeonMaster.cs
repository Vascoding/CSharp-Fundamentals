using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DungeonMaster
{
    private List<Character> party;
    private Stack<Item> pool;
    private int lastSurvivorRounds;
    private List<Character> survivors;
    public DungeonMaster()
    {
        this.party = new List<Character>();
        this.survivors = new List<Character>();
        this.pool = new Stack<Item>();
        this.lastSurvivorRounds = 0;
    }

    public string JoinParty(string[] args)
    {
        var faction = args[0];
        var type = args[1];
        var name = args[2];
        //if (faction != "CSharp" && faction != "Java")
        //{
        //    throw new ArgumentException($"Invalid faction \"{faction}\"!");
        //}
        //if (type != "Warrior" && type != "Cleric")
        //{
        //    throw new ArgumentException($"Invalid character type \"{type}\"!");
        //}

        var character = CharacterFactory.CreateCharacter(faction, type, name);

        this.party.Add(character);
        return $"{name} joined the party!";
    }

    public string AddItemToPool(string[] args)
    {
        var itemName = args[0];
        //if (itemName != "ArmorRepairKit" && itemName != "HealthPotion" && itemName != "PoisonPotion")
        //{
        //    throw new ArgumentException($"Invalid item \"{itemName}\"!");
        //}
        var item = ItemFactory.CreateItem(itemName);

        this.pool.Push(item);
        return $"{itemName} added to pool.";
    }

    public string PickUpItem(string[] args)
    {
        var characterName = args[0];
        var character = this.party.FirstOrDefault(c => c.Name == characterName);
        if (character == null)
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }
        
        if (this.pool.Count() == 0)
        {
            throw new InvalidOperationException($"No items left in pool!");
        }

        var pickedItem = this.pool.Pop();
        character.Bag.AddItem(pickedItem);

        return $"{characterName} picked up {pickedItem}!";
    }

    public string UseItem(string[] args)
    {
        var characterName = args[0];
        var itemName = args[1];

        var character = this.party.FirstOrDefault(c => c.Name == characterName);
        if (character == null)
        {
            throw new ArgumentException($"Character {characterName} not found!");
        }

        var item = character.Bag.GetItem(itemName);
        
        character.UseItem(item);

        return $"{character.Name} used {itemName}.";
    }

    public string UseItemOn(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        var giver = this.party.FirstOrDefault(c => c.Name == giverName);
        if (giver == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }
        var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        var item = giver.Bag.GetItem(itemName);

        giver.UseItemOn(item, receiver);

        return $"{giverName} used {itemName} on {receiverName}.";
    }

    public string GiveCharacterItem(string[] args)
    {
        var giverName = args[0];
        var receiverName = args[1];
        var itemName = args[2];

        var giver = this.party.FirstOrDefault(c => c.Name == giverName);
        if (giver == null)
        {
            throw new ArgumentException($"Character {giverName} not found!");
        }
        var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }

        var item = giver.Bag.GetItem(itemName);

        giver.GiveCharacterItem(item, receiver);

        return $"{giverName} gave {receiverName} {itemName}.";
    }

    public string GetStats()
    {
        return string.Join(Environment.NewLine, this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health));
    }

    public string Attack(string[] args)
    {
        var attackerName = args[0];
        var receiverName = args[1];

        var attacker = this.party.FirstOrDefault(c => c.Name == attackerName);
        if (attacker == null)
        {
            throw new ArgumentException($"Character {attackerName} not found!");
        }
        var receiver = this.party.FirstOrDefault(c => c.Name == receiverName);
        if (receiver == null)
        {
            throw new ArgumentException($"Character {receiverName} not found!");
        }
        IAttackable attackable = null;
        try
        {
           attackable = (IAttackable)attacker;
        }
        catch (Exception)
        {
            throw new ArgumentException($"{attackerName} cannot attack!");
        }

        attackable.Attack(receiver);
        var message = $"{attackerName} attacks " +
                $"{receiverName} for " +
                $"{attacker.AbilityPoints} hit points!" +
                $" {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and " +
                $"{receiver.Armor}/{receiver.BaseArmor} AP left!";
        if (receiver.IsAlive)
        {
            return message;
        }


        return message + Environment.NewLine + $"{receiverName} is dead!";
    }

    public string Heal(string[] args)
    {
        var healerName = args[0];
        var healingReceiverName = args[1];

        var healer = this.party.FirstOrDefault(c => c.Name == healerName);
        if (healer == null)
        {
            throw new ArgumentException($"Character {healerName} not found!");
        }
        var receiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);
        if (receiver == null)
        {
            throw new ArgumentException($"Character {healingReceiverName} not found!");
        }
        IHealable healeable = null;
        try
        {
            healeable = (IHealable)healer;
        }
        catch (Exception)
        {
            throw new ArgumentException($"{healerName} cannot heal!");
        }

        healeable.Heal(receiver);

        return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!";
    }

    public string EndTurn(string[] args)
    {
        StringBuilder sb = new StringBuilder();
        var alive = this.party.Where(c => c.IsAlive).Count();
        if (alive == 0)
        {
            this.lastSurvivorRounds++;
        }
        if (alive == 1)
        {
            this.lastSurvivorRounds++;
            this.survivors.Add(this.party.FirstOrDefault(c => c.IsAlive));
        }
        foreach (var character in this.party.Where(c => c.IsAlive))
        {
            sb.Append($"{character.Name} rests ({character.Health}");
            character.Rest();
            sb.AppendLine($" => {character.Health})");
        }
        return sb.ToString().Trim();
    }

    public bool IsGameOver()
    {
        return this.lastSurvivorRounds > 1;
    }

}

