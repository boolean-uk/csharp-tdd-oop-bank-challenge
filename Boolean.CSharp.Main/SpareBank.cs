using System;
using Boolean.CSharp.Main.Actors;

namespace Boolean.CSharp.Main;

public class SpareBank : IBank
{
    private List<Account> _accounts = new List<Account>();
    public string Branch {get;set;}
    private List<Tuple<Account, decimal>> _overdraftRequests = new List<Tuple<Account, decimal>>();
    public List<Tuple<Account, decimal>> OverdraftRequests {get{return _overdraftRequests;}}
    public SpareBank(string branch)
    {
        Branch = branch;
    }
    public bool CreateAccount(Actor actor, string accountType)
    {
        // MVP: All actors can create an account at any time
        Account accountToAdd = new Account(actor.ID, accountType, Branch);
        _accounts.Add(accountToAdd);
        return _accounts.Contains(accountToAdd);
    }

    public ActionMessage Deposit(Account toDepositTo, decimal funds)
    {
        Account? accountToDepositTo = _accounts.FirstOrDefault(acc => acc.AccountID == toDepositTo.AccountID); //Find the account in the banks registry

        try 
        {
            return accountToDepositTo.Deposit(funds); // Deposit if account exists
        }
        catch (NullReferenceException e)
        {
            return new ActionMessage(false, 0, "Account not found!");
        }

        

    }

    public List<Account> GetAccounts(Actor actor)
    {
        return new List<Account>(_accounts.Where(acc => acc.UserID == actor.ID).ToList());
    }

    public string GetTransactionStatement(Account toGetStatementFrom)
    {
        Account? accountWithStatementRequest = _accounts.FirstOrDefault(acc => acc.AccountID == toGetStatementFrom.AccountID); //Find the account in the banks registry

        try 
        {
            return accountWithStatementRequest.GetTransactionStatement(); // Deposit if account exists
        }
        catch (NullReferenceException e)
        {
            return "";
        }

        
    }

    public ActionMessage Withdraw(Account toWithdrawFrom, decimal funds)
    {
        Account? accountToWithdrawFrom = _accounts.FirstOrDefault(acc => acc.AccountID == toWithdrawFrom.AccountID); //Find the account in the banks registry

        try
        {
            return accountToWithdrawFrom.Withdraw(funds); // Deposit if account exists
        }
        catch (NullReferenceException e)
        {
            return new ActionMessage(false, 0, "Account not found!");
        }
        
    }

    public void RequestOverdraft(Account account, decimal amount)
    {
        Account? accountWithRequest = _accounts.FirstOrDefault(acc => acc.AccountID == account.AccountID); //Find the account in the banks registry


        try
        {
            _overdraftRequests.Add(new Tuple<Account, decimal>(account, amount));
        }
        catch (NullReferenceException e)
        {
            
        }
    }

    public bool AcceptOverdraft(Account account)
    {
        Tuple<Account, decimal>? request = _overdraftRequests.FirstOrDefault(rq => rq.Item1.AccountID == account.AccountID); //Find the account in the overdraftrequests
        try
        {
            request.Item1.AvailableOverdraft = request.Item2;
            return _overdraftRequests.Remove(request);
        }
        catch (NullReferenceException e)
        {
            return false;
        } 

       
    }
}
