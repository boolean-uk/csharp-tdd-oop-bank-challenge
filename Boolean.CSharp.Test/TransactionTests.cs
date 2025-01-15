using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

[TestFixture]
public class TransactionTests
{
    private User _user;
    [SetUp]
    public void Setup()
    {
        _user = new User();
        _user.FirstName = "John";
        _user.LastName = "Doe";
        _user.DOB = new DateTime(2001, 2, 3);
    }
    
    [Test]
    public void AcceptanceCriteriaTests()
    {
        Account checkingAccount = new CheckingAccount(ref _user, Branch.Zurich);
        
        checkingAccount.Deposit(1000, new DateTime(2012, 1, 10));
        checkingAccount.Deposit(2000, new DateTime(2012, 1, 13));
        checkingAccount.Withdraw(500, new DateTime(2012, 1, 14));
        
        Assert.AreEqual(2500, checkingAccount.Balance);

        string statement = checkingAccount.ToString();
        
        Console.WriteLine(statement);
        
        Assert.IsNotEmpty(statement);
    }
}