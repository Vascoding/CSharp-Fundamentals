using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseURLs
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("(\\:\\/\\/)");
            if (regex.Matches(input).Count == 1)
            {
                var protocolLength = input.IndexOf("://");
                var protocol = input.Substring(0, protocolLength);
                var splited = input.Split(new string[] { "://" }, StringSplitOptions.RemoveEmptyEntries);
                var serverlength = splited[1].IndexOf("/");
                if (serverlength != -1)
                {
                    var server = splited[1].Substring(0, splited[1].IndexOf("/"));
                    var resources = input.Substring(protocolLength + serverlength + 4);
                    Console.WriteLine($"Protocol = {protocol}\r\nServer = {server}\r\nResources = {resources}");
                }
                else
                {
                    Console.WriteLine("Invalid URL");
                }
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }
    }
}
