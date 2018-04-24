using System;
using System.Collections.Generic;
using Exercise.Classes;

namespace Exercise
{
    class Startup
    {
        static void Main(string[] args)
        {
            // Problem 1. Odd Lines 
            //OddLines.PrintOddLines();

            // ------------------------------------------------------------------------------

            // Problem 2. Line Numbers
            //LineNumbers.ReadAndWrite();

            // ------------------------------------------------------------------------------

            // Problem 3. Word Count
            //WordCount.MatchWords();

            // ------------------------------------------------------------------------------

            // Problem 4. Copy Binary File
            //CopyBinaryFile.Copy();

            // ------------------------------------------------------------------------------

            // Problem 5. Slicing File

            //string sourceFile = @"../../Files/MyText.txt";
            //string destinationDirectory = @"../../Files/";
            //int parts = int.Parse(Console.ReadLine());
            //List<string> files = new List<string>
            //{
            //    @"../../Files/part1.txt",
            //    @"../../Files/part2.txt",
            //    @"../../Files/part3.txt",
            //    @"../../Files/part4.txt",
            //    @"../../Files/part5.txt",
            //};

            //SlicingFile.Slice(sourceFile, destinationDirectory, parts);
            //SlicingFile.Assemble(files, destinationDirectory);

            // ------------------------------------------------------------------------------

            //Problem 6.Zipping Sliced File

            string sourceFile = @"../../Files/MyText.txt";
            string destinationDirectory = @"../../Files/";
            int parts = int.Parse(Console.ReadLine());
            List<string> files = new List<string>
            {
                @"../../Files/part1.gz",
                @"../../Files/part2.gz",
                @"../../Files/part3.gz",
                @"../../Files/part4.gz",
                @"../../Files/part5.gz",
            };

            ZippingSlicedFiles.Compress(sourceFile, destinationDirectory, parts);
            ZippingSlicedFiles.Decompress(files, destinationDirectory);

            // ------------------------------------------------------------------------------

            // Problem 7. Directory Traversal

            //string directory = Console.ReadLine();
            //DirectoryTraversal.Report(directory);

            // ------------------------------------------------------------------------------

            // Uncomment for each problem.
        }
    }
}
