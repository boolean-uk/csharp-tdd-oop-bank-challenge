namespace Boolean.CSharp.Main;

public class Customer
{
    private List<BankAccount> _accounts;
    public Customer()
    {
        _accounts = new List<BankAccount>();
    }

    public void addAccount(BankAccount account)
    {
        _accounts.Add(account);
    }


}
