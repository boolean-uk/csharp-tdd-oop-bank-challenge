using System;

namespace Boolean.CSharp.Main.Actors;

public abstract class Actor
{

    public Guid ID {get;set;}
    public IBank BankService;

    public Actor(IBank bank) 
    {
        ID = Guid.NewGuid();
        BankService = bank; //Dependeicy injection. We can now switch banks!
    }

    public bool CreateAccount(string accountType)
    {
        return BankService.CreateAccount(this, accountType);
    }

    public List<Account> GetAccounts()
    {
        return BankService.GetAccounts(this);
    }

    public ActionMessage AlterFunds(Account account, decimal funds, bool deposit)
    {
        if (deposit)
        {
            return BankService.Deposit(account, funds);
        }
        return BankService.Withdraw(account, funds);
    }

    //No tests for this function
    public void RequestOverdraft(Account account, decimal amount)
    {
        BankService.RequestOverdraft(account, amount);
    }

    public abstract bool AcceptOverdraft(Account account);


    
}
