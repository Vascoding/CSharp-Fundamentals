using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Nation
{
    public Nation(string name)
    {
        this.Name = name;
        this.Monuments = new List<Monument>();
        this.Benders = new List<Bender>();
    }
    public string Name { get; set; }
    public List<Bender> Benders { get; set; }
    public List<Monument> Monuments { get; set; }

    public abstract double TotalPower();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        if (this.Benders.Count == 0)
        {
            sb.AppendLine("Benders: None");
        }
        else
        {
            sb.AppendLine("Benders:");
            foreach (var bender in this.Benders)
            {
                sb.AppendLine(bender.ToString());
            }
        }
        if (this.Monuments.Count == 0)
        {
            sb.AppendLine("Monuments: None");
        }
        else
        {
            sb.AppendLine("Monuments:");
            foreach (var monument in this.Monuments)
            {
                sb.AppendLine(monument.ToString());
            }
        }
        return sb.ToString().Trim();
    }
}

