using Boolean.CSharp.Main;
using NUnit.Framework;
using System.Diagnostics;

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
        bool result = _core.createSavingsAccount("223456789");
        bool result1 = _core.createSavingsAccount("22345678901");
        bool result2 = _core.createSavingsAccount("22345678901");
        bool result3 = _core.createSavingsAccount("22345678902");
        bool result4 = _core.createSavingsAccount("2234567890112");

        Assert.IsFalse(result); // to short (valid length = 11)
        Assert.IsTrue(result1); // valid
        Assert.IsFalse(result2); // not uniqe
        Assert.IsTrue(result3); // valid
        Assert.IsFalse(result4); // to long
    }

    [Test]
    public void checkBalanceTest()
    {
        SavingsAccount account = new SavingsAccount("32345678901");
        
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
        BankAccount account = new BankAccount("42345678901");
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        string expected = string.Format("{0,-10} {1,-10} {2, -10} {3, -10}\n", "date", "credit", "debit", "balance");
        expected += string.Format("{0,-10} {1,-10} {2, -10} {3, -10}\n", date, 10000.00, "", 10000.00);
        expected += string.Format("{0,-10} {1,-10} {2, -10} {3, -10}\n", date, "", 5000.00, 5000.00);
        expected += string.Format("{0,-10} {1,-10} {2, -10} {3, -10}\n", date, 3500.00, "", 8500.00);

        account.deposit(10000);
        account.withdraw(5000);
        account.deposit(3500);
        string result = account.generateBankStatement();

        Assert.That(result, Is.EqualTo(expected));
    }
}