using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;
using NHibernate.Mapping.ByCode;
using NHibernate.Type;
using NUnit.Framework;

namespace Boolean.CSharp.Test;
public class TestAccount
{
    private Branch mockBranch;

    [SetUp]
    public void Setup()
    {
        // Create a mock branch for testing
        mockBranch = new Branch("Mock Branch", "123 Mock Street");
    }

    [Test]
    public void TestInitialAccountSetup()
    {
        Account account = new Account("Saving Account", 1000.0, mockBranch);
        double balance = account.calculateBalance();
        Assert.AreEqual(1000.0, balance, "Initial balance should be 1000.0");
    }

    [Test]
    public void TestAddingTransactions()
    {
        Account account = new Account("Saving Account", 1000.0, mockBranch);
        account.addTransaction(new Transaction(DateTime.Now, 200.0, 1200.0, "Credit"));
        account.addTransaction(new Transaction(DateTime.Now, 100.0, 1100.0, "Debit"));

        List<Transaction> transactions = account.getTransactionHistory();
        Assert.AreEqual(3, transactions.Count, "There should be 3 transactions in total");
    }

    [Test]
    public void TestBalanceCalculation()
    {
        Account account = new Account("Saving Account", 1000.0, mockBranch);
        account.addTransaction(new Transaction(DateTime.Now, 200.0, 1200.0, "Credit"));
        account.addTransaction(new Transaction(DateTime.Now, 100.0, 1100.0, "Debit"));

        double balance = account.calculateBalance();
        Assert.AreEqual(1100.0, balance, "Balance should be 1100.0 after transactions");
    }

    [Test]
    public void TestTransactionHistory()
    {
        Account account = new Account("Saving Account", 1000.0, mockBranch);
        Transaction transaction1 = new Transaction(DateTime.Now, 200.0, 1200.0, "Credit");
        Transaction transaction2 = new Transaction(DateTime.Now, 100.0, 1100.0, "Debit");
        account.addTransaction(transaction1);
        account.addTransaction(transaction2);

        List<Transaction> transactions = account.getTransactionHistory();
        Assert.IsTrue(transactions.Contains(transaction1) && transactions.Contains(transaction2),
            "Transaction history should contain all transactions");
    }
}
