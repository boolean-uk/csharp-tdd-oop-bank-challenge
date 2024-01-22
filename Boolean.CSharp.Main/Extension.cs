namespace Boolean.CSharp.Main;

public class Extension
{
    Dictionary<string, Customer> _customers;
    private Core _core;
    public Extension()
    {
        _core = new Core();
        _customers = new Dictionary<string, Customer>();
    }
    
    
}
