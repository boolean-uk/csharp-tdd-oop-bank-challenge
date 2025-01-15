using NUnit.Framework;
using Boolean.CSharp.Main;

namespace Boolean.CSharp.Test;

public class OverDraftTests
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
    public void TestOverdraftGetsSentToBranch()
    {
        _account.deposit(100);
        _account.withdraw(150);

        Assert.That(_account.bankBranch.GetOverdraftRequests().Count>0, Is.True);
    }

    [Test]
    public void TestOverdraftGetsApproved()
    {
        _account.deposit(100);
        _account.withdraw(150);

        var overdraftRequest = _account.bankBranch.GetOverdraftRequests()[0];
        overdraftRequest.Approve(Main.Enums.Role.Manager);

        Assert.That(_account.getAccountBalance(), Is.EqualTo(-50));
    }
}
