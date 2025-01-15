using System.Text;

namespace Boolean.CSharp.Main;

public abstract class Account
{
    private Guid _accountNumber = Guid.NewGuid();
    internal Branch _branch;
    private User _accountHolder;
    internal List<Transaction> _transactions = new List<Transaction>();
    
    public Guid AccountNumber => _accountNumber;
    public decimal Balance => CalculateBalance();
    public List<Transaction> Transactions => SortTransactions();

    public Account(ref User accountHolder)
    {
        _accountHolder = accountHolder;
        _branch = Branch.Kristiansand;
    }
    public Account(ref User accountHolder, Branch branch)
    {
        _accountHolder = accountHolder;
        _branch = branch;
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
        var standardFormat = "{0, -10} || {1, -8:F2} || {2, -8:F2} || {3, -9:F2}\n";
        
        sb.AppendLine("---------------Account  Statement---------------");
        sb.AppendFormat("Account holder: {0} {1} ({2})\n",
            _accountHolder.FirstName,
            _accountHolder.LastName,
            _accountHolder.DOB.ToString("dd/MM/yyyy"));
        sb.AppendFormat("Account number: ***-*-*-*-{0} ({1} Branch)\n", shortenedAccountNumber(), _branch);
        sb.AppendLine("------------------------------------------------");
        
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
    
    private string shortenedAccountNumber()
    {
        return _accountNumber.ToString().Substring(30, 6);
    }
}