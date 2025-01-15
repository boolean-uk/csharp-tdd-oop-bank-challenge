namespace Boolean.CSharp.Main;

public class ConsoleMessageProvider : IMessageProvider
{
    public void Send(string message)
    {
        /*
         THese colors are broken
         Console.BackgroundColor = ConsoleColor.Yellow;
         Console.ForegroundColor = ConsoleColor.Black;
        */
        
        const string yellowBackground = "\u001b[43m";
        const string blackForeground = "\u001b[30m";
        const string reset = "\u001b[0m";

        Console.WriteLine("\n\nMessage incoming:\n\n");
        Console.WriteLine($"{yellowBackground}{blackForeground}{message}{reset}");
    }
}