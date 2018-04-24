using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            : base (firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }
        public string FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (IsNumberInvalid(value))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb
                .Append(base.ToString())
                .Append("Faculty number: ").AppendLine(this.FacultyNumber);



            return sb.ToString();
        }

        private static bool IsNumberInvalid(string value)
        {
            bool isNumberInvalid = false;

            string numberPattern = @"^([0-9a-zA-Z]{5,10})$";

            var regex = new Regex(numberPattern);

            var match = regex.Match(value);

            if (match.Success)
            {
                return isNumberInvalid;
            }

            return !isNumberInvalid;
        }
    }
}
