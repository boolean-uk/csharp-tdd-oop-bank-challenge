using Boolean.CSharp.Main.Models;

namespace Boolean.CSharp.Main.Interface;

public interface IBranch
{
    public bool NewCustomer(Customer c);
    public Customer GetCustomer(int ssn);
}