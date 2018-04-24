using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Program
    {
        public static void Main()
        {
            Dictionary<int, BankAccount> bankAcc = new Dictionary<int, BankAccount>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("End"))
                {
                    break;
                }
                var command = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var cmdType = command[0];
                switch (cmdType)
                {
                    case "Create":
                        Create(command, bankAcc);
                        break;
                    case "Deposit":
                        Deposit(command, bankAcc);
                        break;
                    case "Withdraw":
                        Withdraw(command, bankAcc);
                        break;
                    case "Print":
                        Print(command, bankAcc);
                        break;
                }
            }
        }

        private static void Print(string[] command, Dictionary<int, BankAccount> bankAcc)
        {
            var accId = int.Parse(command[1]);
            if (!bankAcc.ContainsKey(accId))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine(bankAcc[accId].ToString());
            }
        }

        private static void Withdraw(string[] command, Dictionary<int, BankAccount> bankAcc)
        {
            var accId = int.Parse(command[1]);
            var amount = double.Parse(command[2]);
            if (!bankAcc.ContainsKey(accId))
            {
                Console.WriteLine("Account does not exist");
                return;
            }
            if (bankAcc[accId].Balance < double.Parse(command[2]))
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                bankAcc[accId].Withdraw(amount);
            }
        }

        private static void Deposit(string[] command, Dictionary<int, BankAccount> bankAcc)
        {
            var accId = int.Parse(command[1]);
            var amount = double.Parse(command[2]);
            if (bankAcc.ContainsKey(accId))
            {
                bankAcc[accId].Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void Create(string[] command, Dictionary<int, BankAccount> bankAcc)
        {
            var accId = int.Parse(command[1]);
            if (bankAcc.ContainsKey(accId))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                bankAcc.Add(accId, new BankAccount
                {
                    ID = accId
                });
            }
        }
    }
}
