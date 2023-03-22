using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string directoryPath = @"C:\Users\UserName\Documents"; // Replace with the path of the directory you want to analyze

        // Get all the files in the directory
        var files = Directory.GetFiles(directoryPath);

        // Return the number of text files in the directory (*.txt)
        var textFiles = files.Where(f => f.EndsWith(".txt"));
        Console.WriteLine($"Number of text files: {textFiles.Count()}");

        // Return the number of files per extension type
        var filesByExtension = files.GroupBy(f => Path.GetExtension(f));
        foreach (var group in filesByExtension)
        {
            Console.WriteLine($"Number of {group.Key} files: {group.Count()}");
        }

        // Return the top 5 largest files, along with their file size (use anonymous types)
        var largestFiles = files.Select(f => new { Name = Path.GetFileName(f), Size = new FileInfo(f).Length })
                               .OrderByDescending(f => f.Size)
                               .Take(5);
        Console.WriteLine("Top 5 largest files:");
        foreach (var file in largestFiles)
        {
            Console.WriteLine($"{file.Name} ({file.Size} bytes)");
        }

        // Return the file with maximum length
        var longestFile = files.OrderByDescending(f => new FileInfo(f).Length).FirstOrDefault();
        Console.WriteLine($"File with maximum length: {longestFile}");
    }
}

