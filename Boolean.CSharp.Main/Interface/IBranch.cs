namespace Boolean.CSharp.Main;

public interface IBranch
{
    public bool NewCustomer(Customer c);
    public Customer GetCustomer(int ssn);
}