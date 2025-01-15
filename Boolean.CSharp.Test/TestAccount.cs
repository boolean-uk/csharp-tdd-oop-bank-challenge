using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

public class TestAccount
{
    [TestCase(10, true)]
    [TestCase(-10, false)]
    public void TestAccountCanDeposit(decimal funds, bool expected)
    {
        Guid id = Guid.NewGuid();
        Account acc = new Account(id);


        ActionMessage actual = acc.Deposit(funds);

        Assert.That(actual.Success, Is.EqualTo(expected));
        Assert.That(acc.Balance == funds, Is.EqualTo(expected)); //All accounts start with 0 funds
    }

    [TestCase(5, true)]
    [TestCase(10, true)]
    [TestCase(20, false)]
    [TestCase(-10, false)]
    public void TestWithDraw(decimal funds, bool expected)
    {
        Guid id = Guid.NewGuid();
        Account acc = new Account(id);
        decimal standardBalance = 10; //Set 10 as the standard accountbalance for this test

        ActionMessage msg = acc.Deposit(standardBalance); 

        ActionMessage actual = acc.Withdraw(funds);

        Assert.That(actual.Success, Is.EqualTo(expected));
        Assert.That(actual.ReturnValue == funds, Is.EqualTo(expected));
        Assert.That(acc.Balance == (standardBalance - funds), Is.EqualTo(expected));
    }

    [Test]
    public void TestGetTranactionStatement()
    {
        Guid id = Guid.NewGuid();
        Account acc = new Account(id);
        
        acc.Deposit(10);
        string depositStatement = acc.GetTransactionStatement();
        acc.Withdraw(5);
        string withdrawStatement = acc.GetTransactionStatement();

        Assert.IsTrue(depositStatement is string && withdrawStatement is string);
        
        Assert.IsTrue(depositStatement.Length > 0);
        Assert.IsTrue(withdrawStatement.Length > depositStatement.Length);
    }

    [Test]
    public void TestSavingAndCurrentHaveDifferentInterests()
    {
        Guid id = Guid.NewGuid();
        Account acc1 = new Account(id, "Current", "branch");
        Account acc2 = new Account(id, "Savings", "branch");
        
        Assert.IsTrue(acc1.Interest != acc2.Interest);

    }

    [Test]
    public void TestGetBalance()
    {
        Guid id = Guid.NewGuid();
        Account acc = new Account(id, "Current", "branch");
        decimal deposit = 10;
        decimal withdrawal = 3;
        acc.Deposit(deposit);
        acc.Withdraw(withdrawal);


        Assert.IsTrue(acc.GetBalance() == deposit - withdrawal);
    }


    [Test]
    public void TestAccountCanOverdraftIfAvailable()
    {
        Guid id = Guid.NewGuid();
        Account acc = new Account(id, "Current", "branch");
        decimal overdraft = 10;
        acc.AvailableOverdraft = overdraft;

        ActionMessage withdrawal = acc.Withdraw(overdraft);

        Assert.IsTrue(withdrawal.Success);
        Assert.IsTrue(acc.Balance == -overdraft);

    }




}
