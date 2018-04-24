using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Exercise.Classes
{
    public class ZippingSlicedFiles
    {
        public static void Compress(string sourceFile, string destinationDirectory, int parts)
        {
            FileStream open = new FileStream(sourceFile, FileMode.Open);
            
            var fileLength = (int)Math.Ceiling((double)open.Length / parts);
            using (open)
            {

                var buffer = new byte[4096];
                for (int i = 1; i <= parts; i++)
                {
                    FileStream slice = new FileStream(destinationDirectory + "part" + i + ".gz", FileMode.Create);
                    GZipStream compress = new GZipStream(slice, CompressionMode.Compress, false);
                    using (slice)
                    {
                        using (compress)
                        {
                            int number = open.Read(buffer, 0, buffer.Length);

                            while (number != 0 && slice.Length <= fileLength)
                            {
                                compress.Write(buffer, 0, number);
                                number = slice.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }

        public static void Decompress(List<string> files, string destinationDirectory)
        {
            var buffer = new byte[4096];
            FileStream assembeled = new FileStream(destinationDirectory + "decompressed.txt", FileMode.Create);
            using (assembeled)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    FileStream assemble = new FileStream(files[i], FileMode.Open);
                    GZipStream decompress = new GZipStream(assemble, CompressionMode.Decompress, false);
                    using (assemble)
                    {
                        using (decompress)
                        {
                            int number = decompress.Read(buffer, 0, buffer.Length);
                            while (number != 0)
                            {
                                assembeled.Write(buffer, 0, number);
                                number = decompress.Read(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
            }
        }
    }
}
