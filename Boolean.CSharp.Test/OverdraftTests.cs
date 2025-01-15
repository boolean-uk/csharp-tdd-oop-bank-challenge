using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

[TestFixture]
public class OverdraftTests
{
    private User _user;
    [SetUp]
    public void Setup()
    {
        _user = new User();
    }
    
    [Test]
    public void CheckingOverdraftTest()
    {
        var account = new CheckingAccount(ref _user);
        
        account.RequestOverdraft(2000);

        account.OverdraftRequests.First().Verdict(true, out var newLimit);
        account.OverdraftLimit = newLimit;
        
        Assert.IsTrue(account.Deposit(1000));
        Assert.IsTrue(account.Withdraw(2000));
        
        Assert.AreEqual(-1000, account.Balance);
    }
    
    [Test]
    public void CheckingOverdraftFailTest()
    {
        var account = new CheckingAccount(ref _user);
        
        account.RequestOverdraft(2000);

        account.OverdraftRequests.First().Verdict(false, out var newLimit);
        account.OverdraftLimit = newLimit;
        
        Assert.IsTrue(account.Deposit(1000));
        Assert.IsFalse(account.Withdraw(2000));
        
        Assert.AreEqual(1000, account.Balance);
    }
    
    [Test]
    public void SavingsOverdraftTest()
    {
        var account = new SavingsAccount(ref _user);
        
        // Withdrawal should fail because the amount is higher than account balance
        Assert.IsTrue(account.Deposit(1000));
        Assert.IsFalse(account.Withdraw(2000));
        
        Assert.AreEqual(1000, account.Balance);
    }
}