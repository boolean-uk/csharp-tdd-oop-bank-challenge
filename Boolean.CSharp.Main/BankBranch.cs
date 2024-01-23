namespace Boolean.CSharp.Main;

public class BankBranch
{
    private string _name;
    private string _regNr;
    private List<Customer> _customers;
    private Manager _manager;
    private IMessage _messenger;

    public BankBranch(string name, string regNr, Manager manager, IMessage messenger)
    {
        _name = name;
        _regNr = regNr;
        _customers = new List<Customer>();
        _messenger = messenger;
    }

    public string Name { get { return _name; } }
    public bool createCustomer(string name, string customerNr)
    {
        if (customerNr.Trim().Length == 6 && name.Trim() != string.Empty)
        {
            if (_customers.Find(x => x.CustomerNr == customerNr.Trim()) == null)
            {
                _customers.Add(new Customer(name.Trim(), customerNr.Trim(), _regNr, _manager, _messenger));
                return true;
            }
        }
        return false;
    }

    public Customer? GetCustomerByNr(string customerNr)
    {
        return _customers.Find(x => x.CustomerNr == customerNr.Trim());
    }

    public List<Customer> Customers { get { return _customers; } }
}
