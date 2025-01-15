using System.Text;

namespace Boolean.CSharp.Main;

public abstract class Account
{
    private Guid _accountNumber = Guid.NewGuid();
    private Branch _branch;
    private User _accountHolder;
    internal List<Transaction> _transactions = new List<Transaction>();
    
    public Guid AccountNumber => _accountNumber;
    public decimal Balance => CalculateBalance();
    public List<Transaction> Transactions => SortTransactions();

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
        var calculatedBalance = Balance;
        StringBuilder sb = new StringBuilder();
        var standardFormat = "{0, -10} || {1, -6} || {2, -6} || {3, -8}\n";
        
        sb.AppendFormat(standardFormat, "Date", "Credit", "Debit", "Balance");
        sb.Append("------------------------------------------------\n");

        foreach (var transaction in Transactions)
        {
            sb.AppendFormat(standardFormat,
                transaction.Date.ToString("dd/MM/yyyy"), 
                transaction.TransactionType == TransactionType.Deposit ? transaction.Amount : 0, 
                transaction.TransactionType == TransactionType.Withdrawal ? transaction.Amount : 0, 
                calculatedBalance);
            
            calculatedBalance += transaction.TransactionType == TransactionType.Deposit ? -transaction.Amount : transaction.Amount;
        }
        
        return sb.ToString();
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
    
    // Sort transactions. Necessary for calculating account balance on the spot
    private List<Transaction> SortTransactions()
    {
        return _transactions.OrderByDescending(t => t.Date).ToList();
    }
}