using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekday;
    
    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, out this.weekday);
        this.Notes = notes;
    }

    public string Notes { get; set; }
    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var weekDayCompresion = this.weekday.CompareTo(other.weekday);
        if (weekDayCompresion != 0)
        {
            return weekDayCompresion;
        }
        return string.CompareOrdinal(this.Notes, other.Notes);
    }

    public override string ToString()
    {
        return $"{this.weekday} -> {this.Notes}";
    }
}
