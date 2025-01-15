namespace Boolean.CSharp.Main;

public class CheckingAccount : Account, IOverdraftable
{
    public decimal OverdraftLimit { get; set; }
    public List<OverdraftRequest> OverdraftRequests { get; set; }

    public CheckingAccount(ref User accountHolder) : base(ref accountHolder)
    {
        OverdraftRequests = new List<OverdraftRequest>();
        _branch = Branch.Kristiansand;
    }
    
    public CheckingAccount(ref User accountHolder, Branch branch) : base(ref accountHolder, branch)
    {
        OverdraftRequests = new List<OverdraftRequest>();
    }
    
    public void RequestOverdraft(decimal amount)
    {
        OverdraftRequests.Add(new OverdraftRequest(amount));
    }

    public new bool Withdraw(decimal amount)
    {
        return Withdraw(amount, DateTime.Now);
    }
    
    public new bool Withdraw(decimal amount, DateTime date)
    {
        if (Balance + OverdraftLimit < amount)
        {
            return false;
        }
        
        _transactions.Add(new Transaction(amount, TransactionType.Withdrawal, date));
        return true;
    }
}