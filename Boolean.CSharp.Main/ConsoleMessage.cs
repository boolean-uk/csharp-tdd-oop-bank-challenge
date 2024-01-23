namespace Boolean.CSharp.Main;

public class ConsoleMessage : IMessage
{
    public void sendMessage(string message)
    {
        Console.WriteLine(message);
    }
}
