namespace Boolean.CSharp.Main;

public abstract class Account
{
    private Guid _accountNumber = Guid.NewGuid();
    private Branch _branch;
    private User _accountHolder;
    private List<Transaction> _transactions = new List<Transaction>();
    
    public Guid AccountNumber => _accountNumber;
    public decimal Balance => CalculateBalance();

    public Account(ref User accountHolder)
    {
        _accountHolder = accountHolder;
    }
    
    public bool Withdraw(decimal amount, DateTime date)
    {
        if (Balance < amount)
        {
            return false;
        }
        
        _transactions.Add(new Transaction(amount, TransactionType.Withdrawal, date));
        return true;
    }
    
    public bool Deposit(decimal amount, DateTime date)
    {
        _transactions.Add(new Transaction(amount, TransactionType.Deposit, date));
        return true;
    }
    
    public bool Withdraw(decimal amount)
    {
        return Withdraw(amount, DateTime.Now);
    }
    
    public bool Deposit(decimal amount)
    {
        return Deposit(amount, DateTime.Now);
    }

    public override string ToString()
    {
        throw new NotImplementedException();
    }
    
    private decimal CalculateBalance()
    {
        decimal balance = 0;

        foreach (var transaction in _transactions)
        {
            switch (transaction.TransactionType)
            {
                case TransactionType.Deposit:
                    balance += transaction.Amount;
                    break;
                case TransactionType.Withdrawal:
                    balance -= transaction.Amount;
                    break;
                default:
                    throw new Exception("Invalid transaction type");
            };
        }
        
        return balance;
    }
}