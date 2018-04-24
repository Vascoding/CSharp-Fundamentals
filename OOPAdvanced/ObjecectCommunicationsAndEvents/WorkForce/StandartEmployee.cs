namespace WorkForce
{
    public class StandartEmployee : BaseEmployee
    {
        private const int WorkHoursPerWeek = 40;

        public StandartEmployee(string name) : base(name, WorkHoursPerWeek)
        {
        }
    }
}