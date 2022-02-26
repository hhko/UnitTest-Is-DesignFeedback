using System;

namespace Helloworld;

public class Program
{
    public static void Main(string[] args)
    {
        string name = Console.ReadLine();

        string output = CreateGreetingMessage(name);

        Console.WriteLine($"{output}");
    }

    public static string CreateGreetingMessage(string name)
    {
        return $"Hi {name}";
    }

    public static int Add(int x, int y)
    {
        return x + y;
    }

    public static int Sub(int x, int y)
    {
        x += 100;
        return x - y;
    }
}