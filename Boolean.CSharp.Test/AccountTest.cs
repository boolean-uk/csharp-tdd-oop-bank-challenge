using NUnit.Framework;
using Boolean.CSharp.Main;

namespace Boolean.CSharp.Test;

public class AccountTest
{

    private Account _account;

    [SetUp]
    public void Setup()
    {
        Customer customer = new Customer("testcostumer", "83747564");
        BankBranch branch = new BankBranch("testbranch");
        _account = new Account("testaccount", customer.userId, branch);
    }

    [Test]
    public void accountBalanceTest()
    {
        _account.deposit(100);
        _account.withdraw(50);

        Assert.That(_account.getAccountBalance(), Is.EqualTo(50));
    }
}
