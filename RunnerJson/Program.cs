using RunnerJson;

namespace RunnerJson;

internal class Program
{

    static void Main()
    {
        MainAsync().GetAwaiter().GetResult();
    }

    static async Task MainAsync()
    {
        Console.WriteLine("Hello, World!");
    }
}
