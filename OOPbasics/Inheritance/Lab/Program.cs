using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int linesCount = int.Parse(Console.ReadLine());
            Dictionary<string, string> registeredUsers = new Dictionary<string, string>();

            for (int i = 0; i < linesCount; i++)
            {
                string input = Console.ReadLine();
                string action = input.Split()[0];

                if (action == "register")
                {
                    RegisterUser(input, registeredUsers);
                }
                else if (action == "unregister")
                {
                    UnRegisterUser(input, registeredUsers);
                }
            }

            foreach (var registeredUser in registeredUsers)
            {
                Console.WriteLine($"{registeredUser.Key} => {registeredUser.Value}");
            }
        }

        private static bool LicensePlateIsValid(string licensePlate)
        {
            if (licensePlate.Length != 8)
            {
                return false;
            }

            string middle = licensePlate.Substring(2, 4);
            string ends = licensePlate.Substring(0, 2) + licensePlate.Substring(licensePlate.Length - 2, 2);

            int value = 0;
            bool endsAreLetters = ends.All(l => l >= 65 && l <= 90);
            bool middleIsNumbers = int.TryParse(middle, out value);

            if (!(endsAreLetters && middleIsNumbers))
            {
                return false;
            }

            return true;
        }

        private static void RegisterUser(string input, Dictionary<string, string> registeredUsers)
        {
            string username = input.Split()[1];
            string licensePlate = input.Split()[2];
            if (registeredUsers.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {registeredUsers[username]}");
            }
            
            if (LicensePlateIsValid(licensePlate))
            {
                
                if (registeredUsers.ContainsValue(licensePlate))
                {
                    Console.WriteLine($"ERROR: license plate {licensePlate} is busy");
                }
                else
                {
                    Console.WriteLine($"{username} registered {licensePlate} successfully");
                    registeredUsers[username] = licensePlate;
                }
            }
            else 
            {
                Console.WriteLine($"ERROR: invalid license plate {licensePlate}");
            }

        }

        private static void UnRegisterUser(string input, Dictionary<string, string> registeredUsers)
        {
            string username = input.Split()[1];
            if (!registeredUsers.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            else
            {
                Console.WriteLine($"user {username} unregistered successfully");
                registeredUsers.Remove(username);
            }
        }
        
    }
}
