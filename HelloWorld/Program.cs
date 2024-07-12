namespace HelloWorld;

class Program
{
    static void Main(string[] args)
    {
        // adapted from https://learn.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-code?pivots=dotnet-8-0
        Console.WriteLine("What is your name?");
        var name = Console.ReadLine();
        name = string.IsNullOrWhiteSpace(name)? "Jack": name;  // default name
        var currentDate = DateTime.Now;
        Console.WriteLine($"{Environment.NewLine}Hello, {name}, now is {currentDate:d} at {currentDate:t}!");
        Console.WriteLine($"Press any key to exit.");
        Console.ReadKey(true);  // read pressed key info, but suppress any output
    }
}
