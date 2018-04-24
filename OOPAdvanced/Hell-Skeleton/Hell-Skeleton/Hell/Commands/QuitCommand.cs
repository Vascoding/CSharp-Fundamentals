using System.Collections.Generic;
using System.Linq;
using System.Text;

public class QuitCommand : Command
{
    private List<string> args;
    private HeroManager manager;
    public QuitCommand(List<string> args, HeroManager heroManager)
    {
        this.args = args;
        this.manager = heroManager;
    }
    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();
        var count = 1;

        foreach (var heroes in manager.heroes.Values
            .OrderByDescending(a => a.PrimaryStats)
            .ThenByDescending(v => v.SecondaryStats))
        {
            sb.AppendLine($"{count}. {heroes.GetType()}: {heroes.Name}");
            sb.AppendLine($"###HitPoints: {heroes.HitPoints}");
            sb.AppendLine($"###Damage: {heroes.Damage}");
            sb.AppendLine($"###Strength: {heroes.Strength}");
            sb.AppendLine($"###Agility: {heroes.Agility}");
            sb.AppendLine($"###Intelligence: {heroes.Intelligence}");
            if (heroes.Items.Count == 0)
            {
                sb.AppendLine("###Items: None");
            }
            else
            {
                sb.AppendLine("###Items: " + string.Join(", ", heroes.Items.Select(i => i.Name)));
            }
            count++;
        }
        //return base.Manager.Quit(this.ArgsList);
        return sb.ToString().Trim();
    }
}