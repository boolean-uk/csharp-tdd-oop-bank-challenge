using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

[TestFixture]
public class CoreTests
{
    private Core _core;

    public CoreTests()
    {
        _core = new Core();

    }

    [Test]
    public void createCurrentAccountTest()
    {
        bool result = _core.createCurrentAccount("123456789");
        bool result1 = _core.createCurrentAccount("12345678901");
        bool result2 = _core.createCurrentAccount("12345678901");
        bool result3 = _core.createCurrentAccount("12345678902");
        bool result4 = _core.createCurrentAccount("1234567890112");

        Assert.IsFalse(result); // to short (valid length = 11)
        Assert.IsTrue(result1); // valid
        Assert.IsFalse(result2); // not uniqe
        Assert.IsTrue(result3); // valid
        Assert.IsFalse(result4); // to long
    }

    [Test]
    public void createSavingsAccountTest()
    {
        bool result = _core.createSavingsAccount("123456789");
        bool result1 = _core.createSavingsAccount("12345678901");
        bool result2 = _core.createSavingsAccount("12345678901");
        bool result3 = _core.createSavingsAccount("12345678902");
        bool result4 = _core.createSavingsAccount("1234567890112");

        Assert.IsFalse(result); // to short (valid length = 11)
        Assert.IsTrue(result1); // valid
        Assert.IsFalse(result2); // not uniqe
        Assert.IsTrue(result3); // valid
        Assert.IsFalse(result4); // to long
    }

    [Test]
    public void checkBalanceTest()
    {
        SavingsAccount account = new SavingsAccount("12345678901");
        
        double result = account.checkBalance();
        Assert.That(result, Is.EqualTo(0));
        
        bool valid = account.deposit(5000);
        bool invalid = account.deposit(-1000);
        result = account.checkBalance();
        Assert.That(result, Is.EqualTo(5000));
        Assert.That(valid, Is.True);
        Assert.That(invalid, Is.False);

        valid = account.withdraw(1000);
        invalid = account.withdraw(-1000);
        result = account.checkBalance();
        Assert.That(result, Is.EqualTo(4000));
        Assert.That(valid, Is.True);
        Assert.That(invalid, Is.False);
    }

    [Test]
    public void generateBankStatementTest()
    {
        BankAccount account = new BankAccount("12345678901");
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);

        account.deposit(10000);
        account.withdraw(5000);
        account.deposit(3500);
        string result = account.generateBankStatement();

        Assert.That(result, Is.EqualTo($"date       || credit   || debit   || balance\r\n" +
                                           $"{date} || 10000.00 ||         || 10000.00\r\n" +
                                           $"{date} ||          || 5000.00 ||  5000.00\r\n" +
                                           $"{date} ||  3500.00 ||         ||  8500.00"));
    }
}