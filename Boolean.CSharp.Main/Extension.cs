namespace Boolean.CSharp.Main;

public class Extension
{
    private Bank _bank;
    private IMessage _messenger;
    public Extension()
    {
        _messenger = new ConsoleMessage();
        _bank = new Bank("", "1111", new Manager(), _messenger);
    }
    
    public void createBank(string name, string regNr, Manager manager)
    {
        if (regNr.Trim().Length == 4)
        {
            _bank = new Bank(name.Trim(), regNr.Trim(), manager, _messenger);
            Console.WriteLine("Bank created");
        }
        else
        {
            Console.WriteLine("RegNr has to be 4 numbers");
        }
    }

    public Bank Bank { get { return _bank; } }
}
