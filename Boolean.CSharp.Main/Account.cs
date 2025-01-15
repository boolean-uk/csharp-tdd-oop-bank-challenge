namespace Boolean.CSharp.Main;

public enum BankBranch
{
    BranchA,
    BranchB,
}

public enum AccountType
{
    Savings,
    Current,
}

public class Account
{
    private List<Transaction> Transactions = new List<Transaction>();
    public decimal AllowedOverdraft { get; private set; } = 0.0M;
    public BankBranch Branch { get; init; }
    public AccountType Type { get; init; }
    public required string Name { get; init; }
    public decimal Balance
    {
        get { return this.Transactions.Select(t => t.ToValue()).Sum(); }
    }

    public bool Withdraw(decimal amount)
    {
        if ((Balance - amount) > -AllowedOverdraft)
        {
            Transactions.Add(Transaction.Withdraw(amount));
            return true;
        }
        return false;
    }

    public void Deposit(decimal amount)
    {
        Transactions.Add(Transaction.Deposit(amount));
    }

    public bool ChangeOverdraft(decimal newOverdraft)
    {
        if (Balance < -newOverdraft)
        {
            return false;
        }
        AllowedOverdraft = newOverdraft;
        return true;
    }

    public string GetTransactionLog()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine($"{"date", -11}|| {"credit", -9} || {"debit", -9} || {"balance", -10}");
        decimal balance = 0.0M;
        List<TransactionLogField> log = new List<TransactionLogField>();
        foreach (Transaction transaction in Transactions)
        {
            balance += transaction.ToValue();
            log.Add(new TransactionLogField(transaction, balance));
        }
        log.Reverse();
        log.ForEach(x => sb.AppendLine(x.ToString()));
        return sb.ToString();
    }
}
