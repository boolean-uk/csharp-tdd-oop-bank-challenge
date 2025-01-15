using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

[TestFixture]
public class AccountTests
{
    [TestCase(5000, 2000, 3000)]
    [TestCase(100, 10, 90)]
    public void AccountDepositAndWithdrawTest(decimal deposit, decimal withdrawal, decimal expectedBalance)
    {
        var user = new User();
        var account = new CheckingAccount(ref user);
        
        account.Deposit(deposit);
        account.Withdraw(withdrawal);
        
        Assert.AreEqual(expectedBalance, account.Balance);
    }
    
    [Test]
    public void AccountStatementTest()
    {
        var user = new User();
        var account = new CheckingAccount(ref user);
        
        account.Deposit(1000, new DateTime(2012, 1, 10));
        account.Deposit(2000, new DateTime(2012, 1, 13));
        account.Withdraw(500, new DateTime(2012, 1, 14));
        
        var statement = account.ToString();
        
        Console.WriteLine(statement);
        Assert.IsNotNull(statement);
    }
}