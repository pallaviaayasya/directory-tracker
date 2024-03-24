//using Directorywatcher;

//IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        services.AddHostedService<Worker>();
//    })
//    .Build();

//host.Run();

class Program
{
    static void Main(string[] args)
    {
        // Change this to the path of the directory you want to watch
        string directoryPath = @"/Users/pallaviss/Documents/Learning";

        DirectoryWatcher directoryWatcher = new DirectoryWatcher(directoryPath);
        directoryWatcher.StartWatching();

        Console.WriteLine("Press any key to stop watching the directory.");
        Console.ReadKey();

        directoryWatcher.StopWatching();
    }
}