using System;

namespace Boolean.CSharp.Main;

public class Account
{

    private decimal _balance;
    private List<Tuple<DateTime, string, decimal, decimal>> _transactionHistory = new List<Tuple<DateTime, string, decimal, decimal>>();
    public Guid AccountID = Guid.NewGuid();

    public decimal Interest {get;set;}
    public decimal Balance {get{return _balance;}}
    
    public Guid UserID;
    public string Branch {get; set;}
    public decimal AvailableOverdraft {get; set;} = 0;

    public Account(Guid userID)
    {
        UserID = userID;
        _balance = 0;
        Interest = 0;
        Branch = "";
    }

    public Account(Guid userID, string accountType, string branch)
    {
        UserID = userID;
        _balance = 0;
        Branch = branch;
        switch (accountType)
        {
            case "Current":
            Interest = 0.5M;
            break;

            case "Savings":
            Interest = 3;
            break;

        }
    }
    public ActionMessage Deposit(decimal funds)
    {
        if (funds > 0)
        {
            _balance += funds;
            _transactionHistory.Add(new Tuple<DateTime, string, decimal, decimal>(DateTime.Now, "Deposit", funds, _balance));
            return new ActionMessage(true, _balance, "Deposited into account");
        }
        
        return new ActionMessage(false, 0, "Funds needs to be > 0");
    }

    public ActionMessage Withdraw(decimal funds)
    {
        if (funds > 0 && funds <= (_balance + AvailableOverdraft))
        {
            _balance -= funds;
            _transactionHistory.Add(new Tuple<DateTime, string, decimal, decimal>(DateTime.Now, "Withdraw", funds, _balance));
            return new ActionMessage(true, funds, $"Withdrawed {funds} from Account");
        }

        return new ActionMessage(false, 0, $"Could not withdraw {funds} from Account");
        
    }

    public string GetTransactionStatement()
    {
    
    string statement = String.Format("{0,-20} {1,9} {2,12} {3,12} {4,11}\n", "DateTime", "Credit", "Debit", "Balance", "||");

    foreach (Tuple<DateTime, string, decimal, decimal> transaction in _transactionHistory)
    {
        if (transaction.Item2 == "Deposit")
        {
            
            statement += String.Format("{0,-20} {1,10} {2,12} {3,12} {4,10}\n", 
                transaction.Item1.ToString(), 
                transaction.Item3.ToString("F2"), 
                "", 
                transaction.Item4.ToString("F2"), 
                "||");
        }
        else
        {
            
            statement += String.Format("{0,-20} {1,10} {2,12} {3,12} {4,10}\n", 
                transaction.Item1.ToString(), 
                "", 
                transaction.Item3.ToString("F2"), 
                transaction.Item4.ToString("F2"), 
                "||");
        }
    }

    return statement;
}

    public decimal GetBalance()
    {
        decimal balance = 0;

        foreach (Tuple<DateTime, string, decimal, decimal> accountAction in _transactionHistory)
        {
            if (accountAction.Item2 == "Deposit")
            {
                balance += accountAction.Item3;
            }
            else if (accountAction.Item2 == "Withdraw")
            {
                balance -= accountAction.Item3;
            }
        }

        return balance;
    }

}
