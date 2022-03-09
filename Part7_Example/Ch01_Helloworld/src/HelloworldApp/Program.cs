using System.Diagnostics.CodeAnalysis;
using Helloworld;
using static System.Console;

namespace HelloworldApp;

public class Program
{
    [ExcludeFromCodeCoverage]
    public static void Main(string[] args)
    {
        // Impure : I/O
        WriteLine("Enter your name: ");

        // Pure
        Greeting greeting = new Greeting();
        string message = greeting.For(ReadLine());

        // Impure : I/O
        WriteLine(message);
    }
}