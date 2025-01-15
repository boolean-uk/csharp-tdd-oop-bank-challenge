using System.Security.Cryptography.X509Certificates;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Actors;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

public class TestBank
{
    

    [Test]
    public void TestCreateCurrentAccount()
    {
        SpareBank b = new SpareBank("Vestland");
        Customer customer = new Customer(b);
        Manager manager = new Manager(b);

        bool cusAccountCreated = b.CreateAccount(customer, "Current");
        bool manAccountCreated = b.CreateAccount(manager, "Current");

        Assert.IsTrue(cusAccountCreated && manAccountCreated); //Both customer and manager can create Current accounts
    }

    [Test]
    public void TestCreateSavingsAccount()
    {
        SpareBank b = new SpareBank("Vestland");
        Customer customer = new Customer(b);
        Manager manager = new Manager(b);

        bool cusAccountCreated = b.CreateAccount(customer, "Savings");
        bool manAccountCreated = b.CreateAccount(manager, "Savings");

        Assert.IsTrue(cusAccountCreated && manAccountCreated); //Both customer and manager can create Savings accounts
    }

    [Test]
    public void TestGetAccountReturnsJustMyAccounts()
    {
        SpareBank b = new SpareBank("Vestland");
        Customer customer = new Customer(b);

        bool currentAccountCreated = b.CreateAccount(customer, "Current");
        bool savingsAccountCreated = b.CreateAccount(customer, "Savings");

        List<Account> myAccounts = b.GetAccounts(customer);

        Assert.IsTrue(currentAccountCreated && savingsAccountCreated);
        Assert.That(myAccounts.Where(acc => acc.UserID == customer.ID).ToList().Count, Is.EqualTo(2));
    }

    [TestCase(10, true)]
    [TestCase(-10, false)]
    public void TestDeposit(decimal funds, bool expected)
    {
        SpareBank b = new SpareBank("Vestland");
        Customer customer = new Customer(b);
        Manager manager = new Manager(b);

        b.CreateAccount(customer, "Savings");
        b.CreateAccount(customer, "Current");
        b.CreateAccount(manager, "Savings");
        b.CreateAccount(manager, "Current");

        List<Account> cAccounts = b.GetAccounts(customer);
        List<Account> mAccounts = b.GetAccounts(manager); 

        cAccounts.ForEach(acc => b.Deposit(acc, funds));
        mAccounts.ForEach(acc => b.Deposit(acc, funds));

        
        Assert.That(cAccounts.Sum(x => x.Balance) == funds*2, Is.EqualTo(expected));
        Assert.That(mAccounts.Sum(x => x.Balance) == funds*2, Is.EqualTo(expected));
    }

    [TestCase(10, true)]
    [TestCase(-10, false)]
    public void TestWithdraw(decimal funds, bool expected)
    {
        SpareBank b = new SpareBank("Vestland");
        Customer customer = new Customer(b);
        Manager manager = new Manager(b);

        b.CreateAccount(customer, "Savings");
        b.CreateAccount(customer, "Current");
        b.CreateAccount(manager, "Savings");
        b.CreateAccount(manager, "Current");

        List<Account> cAccounts = b.GetAccounts(customer);
        List<Account> mAccounts = b.GetAccounts(manager); 

        cAccounts.ForEach(acc => b.Deposit(acc, funds + 1));
        mAccounts.ForEach(acc => b.Deposit(acc, funds + 1));

        cAccounts.ForEach(acc => b.Withdraw(acc, funds));
        mAccounts.ForEach(acc => b.Withdraw(acc, funds));


        Assert.That(cAccounts.Sum(x => x.Balance) == 2, Is.EqualTo(expected));
        Assert.That(mAccounts.Sum(x => x.Balance) == 2, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetTransactionStatementReturnsString()
    {
        SpareBank b = new SpareBank("Vestland");
        Customer customer = new Customer(b);

        b.CreateAccount(customer, "Current");

        List<Account> accs = b.GetAccounts(customer);
        string statement = b.GetTransactionStatement(accs[0]);

        Assert.IsTrue(statement is string);
    }


    [Test]
    public void TestRequestOverDraftCreatesRequest()
    {
        SpareBank b = new SpareBank("Vestland");
        Customer customer = new Customer(b);
        b.CreateAccount(customer, "Current");
        b.CreateAccount(customer, "Savings");
        decimal overdraft = 10;

        List<Account> accounts = b.GetAccounts(customer);

        accounts.ForEach(acc => b.RequestOverdraft(acc, overdraft));

        List<Tuple<Account, decimal>> requests = b.OverdraftRequests;

        List<Guid> requestsAccounts = requests.Select(rq => rq.Item1).Select(acc => acc.AccountID).ToList(); // Get a list of all account IDS in the overdraft requests

        accounts.ForEach(acc => Assert.IsTrue(requestsAccounts.Contains(acc.AccountID))); //Check that all accounts that have requested an overdraft are accounted for
    }

    [Test]
    public void TestAcceptOverdraft()
    {
        SpareBank b = new SpareBank("Vestland");
        Customer customer = new Customer(b);
        b.CreateAccount(customer, "Current");
        b.CreateAccount(customer, "Savings");
        decimal overdraft = 10;

        List<Account> accounts = b.GetAccounts(customer);

        accounts.ForEach(acc => b.RequestOverdraft(acc, overdraft));

        accounts.ForEach(acc => Assert.IsTrue(b.AcceptOverdraft(acc)));

        accounts.ForEach(acc => Assert.IsTrue(acc.AvailableOverdraft == overdraft));

        Assert.IsFalse(b.OverdraftRequests.Count > 0);

    }
    

}
