using System;

namespace Mankind
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                var studentInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var workerInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentInput[0], studentInput[1], studentInput[2]);
                Worker worker = new Worker(workerInput[0], workerInput[1], decimal.Parse(workerInput[2]), decimal.Parse(workerInput[3]));
                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }
    }
}
