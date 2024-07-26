public class ConsoleLogger : Logger
{
    protected override void WriteMessage(string message)
    {
        Console.WriteLine(message);
    }
}