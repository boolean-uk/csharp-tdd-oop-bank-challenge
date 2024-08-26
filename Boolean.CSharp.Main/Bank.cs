using Boolean.CSharp.Main.Interface;
using Boolean.CSharp.Main.Models;

namespace Boolean.CSharp.Main;

public class Bank(string name)
{
    private string _name = name;
    private List<Customer> _customers = new();
    
    public bool NewCustomer(Customer c)
    {
        if (_customers.Any(x => x.SocialSecurityNumber.Equals(c.SocialSecurityNumber))) return false;
        _customers.Add(c);
        return true;
    }

    public Customer GetCustomer(int ssn)
    {
        return _customers.FirstOrDefault(customer => customer.SocialSecurityNumber.Equals(ssn))!;
    }
    
    public List<Customer> GetAllCustomers() => _customers;
}

public enum Branch
{
    Vest,
    Nord,
    Øst,
    Sør
}