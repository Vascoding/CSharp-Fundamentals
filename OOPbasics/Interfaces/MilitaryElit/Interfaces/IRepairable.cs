namespace MilitaryElit.Interfaces
{
    public interface IRepairable
    {
        string PartName { get; }
        int HoursWorked { get; }
    }
}