using System;
using System.Collections.Generic;
using System.IO;

namespace Exercise.Classes
{
    public class SlicingFile
    {
        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            FileStream open = new FileStream(sourceFile, FileMode.Open);

            var fileLength = (int)Math.Ceiling((double)open.Length / parts);
            using (open)
            {

                var buffer = new byte[4096];
                for (int i = 1; i <= parts; i++)
                {
                    FileStream slice = new FileStream(destinationDirectory + "part" + i + ".txt", FileMode.Create);
                    using (slice)
                    {
                        int number = open.Read(buffer, 0, buffer.Length);
                        
                        while (number != 0 && slice.Length <= fileLength)
                        {
                            slice.Write(buffer, 0, number);
                            number = slice.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }

        public static void Assemble(List<string> files, string destinationDirectory)
        {
            var buffer = new byte[4096];
            using (var assembeled = new FileStream(destinationDirectory + "assembled.txt", FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    FileStream assemble = new FileStream(files[i], FileMode.Open);
                    using (assemble)
                    {
                        int number = assemble.Read(buffer, 0, buffer.Length);
                        while (number != 0)
                        {
                            assembeled.Write(buffer, 0, number);
                            number = assemble.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}
