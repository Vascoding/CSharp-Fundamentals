using System;
using System.Collections.Generic;
using System.IO;

namespace Exercise.Classes
{
    public class DirectoryTraversal
    {
        public static void Report(string directory)
        {
            Dictionary<string, Dictionary<string, string>> fileDict = new Dictionary<string, Dictionary<string, string>>();
            string[] files = Directory.GetFiles(directory);
            foreach (var file in files)
            {
                FileStream open = new FileStream(file, FileMode.Open);
                using (open)
                {
                    var fileName = Path.GetFileName(file);
                    var extension = Path.GetExtension(file);
                    FileInfo info = new FileInfo(file);
                    double size = info.Length / 1000d;

                    if (fileDict.ContainsKey(extension))
                    {
                        fileDict[extension].Add(fileName, size + "kb");
                    }
                    else
                    {
                        fileDict.Add(extension, new Dictionary<string, string>());
                        fileDict[extension].Add(fileName, size + "kb");
                    }
                }
            }
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            StreamWriter writer = new StreamWriter(desktopPath + "/report.txt");
            using (writer)
            {
                foreach (var file in fileDict)
                {
                    writer.WriteLine($"{file.Key}");

                    foreach (var value in file.Value)
                    {
                        writer.WriteLine($"{value.Key} - {value.Value}");
                    }
                }
            }
        }
    }
}
