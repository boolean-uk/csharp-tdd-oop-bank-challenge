namespace Boolean.CSharp.Test;

using Boolean.CSharp.Main;
using NUnit.Framework;

public class TransactionTest
{
    [TestCase(0.0)]
    [TestCase(1.0)]
    [TestCase(999.0)]
    [TestCase(999.9999)]
    public void CorrectValue(decimal amount)
    {
        Assert.That(Transaction.Withdraw(amount).ToValue(), Is.EqualTo(-amount));
        Assert.That(Transaction.Deposit(amount).ToValue(), Is.EqualTo(amount));
    }
}

public class AccountTest
{
    private Account account = new Account { Name = "acc" };

    [SetUp]
    public void SetUp()
    {
        account = new Account { Name = "acc" };
    }

    [Test]
    public void DepositWithdrawBalance()
    {
        account.ChangeOverdraft(10000.0M);
        Assert.That(account.Balance, Is.EqualTo(0.0).Within(0.0001));
        account.Deposit(900.0M);
        Assert.That(account.Balance, Is.EqualTo(900.0).Within(0.0001));
        account.Deposit(300.0M);
        Assert.That(account.Balance, Is.EqualTo(1200.0).Within(0.0001));
        Assert.True(account.Withdraw(1000.0M));
        Assert.That(account.Balance, Is.EqualTo(200.0).Within(0.0001));
        Assert.True(account.Withdraw(400.2M));
        Assert.That(account.Balance, Is.EqualTo(-200.2).Within(0.0001));
    }

    [Test]
    public void ChangeOverdraft()
    {
        Assert.That(account.AllowedOverdraft, Is.EqualTo(0.0));
        account.ChangeOverdraft(2000.0M);
        Assert.That(account.AllowedOverdraft, Is.EqualTo(2000.0));
        account.Withdraw(1000.0M);
        Assert.False(account.ChangeOverdraft(0.0M));
        Assert.That(account.AllowedOverdraft, Is.EqualTo(2000.0));
    }

    [Test]
    public void StringLog()
    {
        account.Deposit(100.0m);
        Thread.Sleep(10);
        account.Withdraw(85.0m);
        var transactionLog = account.GetTransactionLog();
        Console.WriteLine(transactionLog);
        Assert.That(
            transactionLog.IndexOf("100.0"),
            Is.GreaterThan(transactionLog.IndexOf("85.0"))
        );
    }
}

public class TransactionLogFieldTest
{
    private List<Transaction> transactions = new List<Transaction>
    {
        Transaction.Deposit(900.0M),
        Transaction.Withdraw(920.0M),
    };

    [Test]
    public void FieldToString()
    {
        var tlf = new TransactionLogField(transactions[0], 2000.0M);
        var tlf2 = new TransactionLogField(transactions[1], 2300.0M);
        Assert.That(tlf.ToString(), Contains.Substring("2000.0"));
        Assert.That(tlf.ToString(), Contains.Substring("900.0"));
        Assert.That(tlf2.ToString(), Contains.Substring("2300.0"));
        Assert.That(tlf2.ToString(), Contains.Substring("920.0"));
    }
}

public class UserTest
{
    private User user = new User { UserId = "plebian" };
    private AdminUser admin = new AdminUser { UserId = "admin" };

    [SetUp]
    public void SetUp()
    {
        user = new User { UserId = "plebian" };
        admin = new AdminUser { UserId = "admin" };

        user.CreateAccount("testAccount", AccountType.Savings, BankBranch.BranchA);
        user.CreateAccount("testAccount2", AccountType.Current, BankBranch.BranchB);
    }

    [Test]
    public void ChangeOVerdraft()
    {
        Assert.False(admin.ChangeAllowedOverdraft(user, "nonexistent", 1000.0M));
        Assert.True(admin.ChangeAllowedOverdraft(user, "testAccount", 1000.0M));
        Assert.That(user.GetAllowedOverdraft("testAccount"), Is.EqualTo(1000.0M));
        Assert.True(user.Withdraw("testAccount", 900.0M));
        Assert.False(admin.ChangeAllowedOverdraft(user, "testAccount", 0.0M));
    }

    [Test]
    public void DepositWithdraw()
    {
        Assert.That(user.GetBalance("testAccount"), Is.EqualTo(0.0M));
        user.Deposit("testAccount", 55.5M);
        Assert.That(user.GetBalance("testAccount"), Is.EqualTo(55.5M));
        user.Deposit("testAccount", 25.5M);
        Assert.That(user.GetBalance("testAccount"), Is.EqualTo(81.0M));
        user.Withdraw("testAccount", 15.0M);
        Assert.That(user.GetBalance("testAccount"), Is.EqualTo(66.0M));
        user.Withdraw("testAccount", 15.3M);
        Assert.That(user.GetBalance("testAccount"), Is.EqualTo(50.7M));
    }
}
