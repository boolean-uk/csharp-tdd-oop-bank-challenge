using System;
using Boolean.CSharp.Main.Actors;

namespace Boolean.CSharp.Main;

public interface IBank
{
    public string Branch {get;set;}
    
    public bool CreateAccount(Actor actor, string accountType);
    

    public ActionMessage Deposit(Account toDepositTo, decimal funds);

    public List<Account> GetAccounts(Actor actor);

    public string GetTransactionStatement(Account toGetStatementFrom);

    public ActionMessage Withdraw(Account toWithdrawFrom, decimal funds);

    public void RequestOverdraft(Account account, decimal amount);

    public bool AcceptOverdraft(Account account);

}
