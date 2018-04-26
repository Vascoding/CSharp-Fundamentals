using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Bag
{
    private const int DefaultCapacity = 100;

    private readonly List<Item> items;
    private int capacity;

    protected Bag(int capacity = DefaultCapacity)
    {
        this.Capacity = capacity;
        this.items = new List<Item>();
    }

    protected int Capacity
    {
        get
        {
            return this.capacity;
        }
        set
        {
            this.capacity = value;
        }
    }

    private int Load => this.items.Sum(i => i.Weight);

    public IReadOnlyCollection<Item> Items
    {
        get
        {
            return this.items.AsReadOnly();
        }
    }

    public void AddItem(Item item)
    {
        if (this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }

        this.items.Add(item);
    }

    public Item GetItem(string name)
    {
        EnsureItemExists(name);

        var item = this.items.First(i => i.GetType().Name == name);
        this.items.Remove(item);

        return item;
    }

    private void EnsureItemExists(string name)
    {
        if (!this.items.Any())
        {
            throw new InvalidOperationException("Bag is empty!");
        }

        var itemExists = this.Items.Any(i => i.GetType().Name == name);
        if (!itemExists)
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }
    }
}