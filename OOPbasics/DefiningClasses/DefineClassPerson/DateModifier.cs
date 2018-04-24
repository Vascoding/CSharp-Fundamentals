using System;

namespace DefineClassPerson
{
    public class DateModifier
    {
        private int difference;

        public int Difference
        {
            get { return this.difference; }
            set { this.difference = value; }
        }

        public void GetDifference(string firstDate, string secondDate)
        {
            DateTime first = DateTime.Parse(firstDate);
            DateTime second = DateTime.Parse(secondDate);
            TimeSpan result = new TimeSpan();
            if (first >= second)
            {
                result = first - second;
            }
            else
            {
                result = second - first;
            }
            this.difference = result.Days;
        }
    }
}
