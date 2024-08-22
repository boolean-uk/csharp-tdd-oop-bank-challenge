using Boolean.CSharp.Main.Interface;
using Boolean.CSharp.Main.Models;

namespace Boolean.CSharp.Main.Core;

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
}