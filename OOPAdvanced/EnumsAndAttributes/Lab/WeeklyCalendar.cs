using System.Collections.Generic;

public class WeeklyCalendar
{
    public List<WeeklyEntry> WeeklySchedule { get; set; }

    public WeeklyCalendar()
    {
        this.WeeklySchedule = new List<WeeklyEntry>();
    }
    public void AddEntry(string weekday, string notes)
    {
        this.WeeklySchedule.Add(new WeeklyEntry(weekday, notes));
    }
}
