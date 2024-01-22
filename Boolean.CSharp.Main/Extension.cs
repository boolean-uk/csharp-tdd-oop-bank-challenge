namespace Boolean.CSharp.Main;

public class Extension
{
    private Bank _bank;
    public Extension()
    {
        _bank = new Bank("", "1111", new Manager());
    }
    
    public void createBank(string name, string regNr, Manager manager)
    {
        if (regNr.Trim().Length == 4)
        {
            _bank = new Bank(name.Trim(), regNr.Trim(), manager);
            Console.WriteLine("Bank created");
        }
        else
        {
            Console.WriteLine("RegNr has to be 4 numbers");
        }
    }

    public Bank Bank { get { return _bank; } }
}
