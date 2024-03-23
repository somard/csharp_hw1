using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Use the user's home directory as the root to start searching from
        // This makes the application platform-agnostic
        var rootDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        
        try
        {
            var largestFiles = FindLargestFiles(rootDirectory, 5);

            Console.WriteLine("Top 5 Largest Files:");
            foreach (var file in largestFiles)
            {
                Console.WriteLine($"{file.FullName} - {file.Length / 1024.0 / 1024.0:F2} MB");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static List<FileInfo> FindLargestFiles(string directoryPath, int count)
    {
        var directoryInfo = new DirectoryInfo(directoryPath);
        var files = new List<FileInfo>();

        try
        {
            // Get all files in the current directory
            files.AddRange(directoryInfo.GetFiles("*", SearchOption.TopDirectoryOnly));
            
            // Recursively get files from subdirectories
            foreach (var directory in directoryInfo.GetDirectories())
            {
                try
                {
		    Console.Write(".");
                    files.AddRange(FindLargestFiles(directory.FullName, count));
                }
                catch
                {
                    // Ignore directories that can't be accessed
                }
            }
        }
        catch
        {
            // Ignore directories that can't be accessed
        }

        // Return the top 'count' largest files
        return files.OrderByDescending(f => f.Length).Take(count).ToList();
    }
}

