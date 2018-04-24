using System;
using System.Collections.Generic;
using System.Linq;

public class War
{
    public War(string name)
    {
        this.Name = name;
        this.Nations = new List<Nation>();
    }

    public List<Nation> Nations { get; set; }
    public string Name { get; set; }
    public void Fight()
    {
        var winning = this.Nations.OrderByDescending(a => a.TotalPower()).First();
        foreach (var nation in Nations.Where(n => n.Name != winning.Name))
        {
            nation.Benders.Clear();
            nation.Monuments.Clear();
        }
    }
}

