using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

class DirectoryWatcher
{
    private readonly string directoryPath;
    private Dictionary<string, DateTime> fileLastModifiedTimes;
    private Dictionary<string, int> wordCounts;
    private Timer timer;

    public DirectoryWatcher(string directoryPath)
    {
        this.directoryPath = directoryPath;
        this.fileLastModifiedTimes = new Dictionary<string, DateTime>();
        this.wordCounts = new Dictionary<string, int>();
    }

    public void StartWatching()
    {
        string[] files = Directory.GetFiles(directoryPath);
        foreach (string file in files)
        {
            fileLastModifiedTimes[file] = File.GetLastWriteTime(file);
            int count = CountWordOccurrences(file, "the");
            wordCounts[file] = count;
        }
        // Start the timer with an initial delay of 0 and a period of 3 minutes (180,000 milliseconds)
        timer = new Timer(CheckDirectoryChanges, null, TimeSpan.Zero, TimeSpan.FromMinutes(3));
    }

    private int CountWordOccurrences(string filePath, string word)
    {
        try
        {
            string text = File.ReadAllText(filePath);
            int count = Regex.Matches(text, @"\b" + word + @"\b", RegexOptions.IgnoreCase).Count;
            return count;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while counting occurrences in file '{filePath}': {ex.Message}");
            return 0;
        }
    }

    private void CheckDirectoryChanges(object state)
    {
        try
        {
            Console.WriteLine($"Checking directory '{directoryPath}' for changes...");

            // Check for changes in the directory
            string[] files = Directory.GetFiles(directoryPath);

            foreach (string file in files)
            {
                DateTime lastModifiedTime = File.GetLastWriteTime(file);

                if (fileLastModifiedTimes.ContainsKey(file))
                {
                    // Check if the file has been modified since the last check
                    if (lastModifiedTime != fileLastModifiedTimes[file])
                    {
                        Console.WriteLine($"File '{file}' has been modified.");

                        // Update the last modified time for the file
                        fileLastModifiedTimes[file] = lastModifiedTime;

                        // Perform any specific actions here based on the file change
                    }
                }
                else
                {
                    // Add the file to the dictionary if it's new
                    fileLastModifiedTimes[file] = lastModifiedTime;
                    Console.WriteLine($"New file detected: '{file}'");
                }
            }

            // You can add more logic here to process the files found

            Console.WriteLine("Directory checked.");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while checking directory changes: {ex.Message}");
        }
    }

    public void StopWatching()
    {
        // Stop the timer
        timer.Dispose();
    }
}

