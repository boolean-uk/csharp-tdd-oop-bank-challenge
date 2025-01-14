namespace Boolean.CSharp.Main;

public abstract class Account
{
    private Guid _accountNumber = Guid.NewGuid();
    private Branch _branch;
    private User _accountHolder;
    private List<Transaction> _transactions;
    
    public Guid AccountNumber { get => _accountNumber; }

    public decimal Balance
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public Account(ref User accountHolder)
    {
        _accountHolder = accountHolder;
    }
    
    public bool Withdraw(decimal amount)
    {
        throw new NotImplementedException();
    }
    
    public bool Deposit(decimal amount)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }
}