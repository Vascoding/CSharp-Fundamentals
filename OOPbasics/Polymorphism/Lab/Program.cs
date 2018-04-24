using System;
using System.Collections.Generic;
using System.Linq;
namespace ForumTopics
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var dic = new Dictionary<string, List<string>>();
            var dicToPrint = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "filter")
            {
                string[] inputTokens = input.Split(new String[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);

                string topic = inputTokens[0];
                string[] tags = inputTokens[1].Split(new String[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                if (!dic.ContainsKey(topic))
                {
                    dic.Add(topic, new List<string>());
                }

                foreach (var item in tags)
                {
                    if (!dic[topic].Contains(item))
                    {
                        dic[topic].Add(item);
                    }
                }


                foreach (var item in dic[topic])
                {
                    if (!dic[topic].Contains(item))
                    {
                        dic[topic].Add(item);
                    }
                }

                input = Console.ReadLine();
            }

            string[] wantedTags = Console.ReadLine().Split(new String[] { ", " }, StringSplitOptions.RemoveEmptyEntries);


            foreach (var item in dic)
            {
                bool container = true;
                for (int i = 0; i < wantedTags.Length; i++)
                {
                    if (!item.Value.Contains(wantedTags[i]))
                    {
                        container = false;
                    }

                }
                if (container)
                {
                    dicToPrint.Add(item.Key, item.Value);
                }
            }


            // Printing
            foreach (var item in dicToPrint)
            {

                for (int i = 0; i < item.Value.Count; i++)
                {
                    item.Value[i] = "#" + item.Value[i];
                }

                Console.WriteLine($"{item.Key} | {string.Join(", ", item.Value)}");
            }

        }
    }
}