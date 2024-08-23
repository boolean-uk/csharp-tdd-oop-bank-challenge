using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Models;

public class WestBranch(Manager m) : IBranch
{
    private Manager _manager = m;
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