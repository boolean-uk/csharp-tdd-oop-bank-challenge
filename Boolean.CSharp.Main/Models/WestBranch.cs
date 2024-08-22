using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main.Models;

public class WestBranch(Manager m) : IBranch
{
    private Manager _manager = m;
    private List<Customer> _customers = new List<Customer>();
    
    public bool NewCustomer(Customer c)
    {
        throw new NotImplementedException();
    }

    public Customer GetCustomer(int ssn)
    {
        throw new NotImplementedException();
    }
    
    public List<Customer> GetAllCustomers() => _customers;
}