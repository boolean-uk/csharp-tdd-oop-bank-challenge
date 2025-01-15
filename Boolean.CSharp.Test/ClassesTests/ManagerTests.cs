using NUnit.Framework;
using System;
using Boolean.CSharp.Main.Classes;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Boolean.CSharp.Test;

public class ManagerTests
{
    private Bank bank;
    private Manager manager;
    private Customer customer;
    private Account account;
    private OverdraftRequest overdraftRequest;

    [SetUp]
    public void SetUp()
    {
        bank = new Bank("Experis Bank", "Bergen Branch");
        manager = new Manager("John", "Smith", "john.smith@experis.no", "Vestre Strømkaien 14", bank);
        customer = new Customer("Jone", "Hjorteland", "jonehjorteland@experis.no", "Vestre Strømkaien 13", bank);
        customer.CreateAccount("Savings");
        account = customer.Accounts[0];
        overdraftRequest = new OverdraftRequest(customer, account, 1500m);
    }

    [Test]
    public void ProcessOverdraftRequest1()
    {
        manager.ProcessOverdraftRequest(overdraftRequest, true);

        Assert.IsTrue(overdraftRequest.IsApproved);
        Assert.IsTrue(overdraftRequest.IsProcessed);
    }

    [Test]
    public void ProcessOverdraftRequest2()
    {
        manager.ProcessOverdraftRequest(overdraftRequest, false);

        Assert.IsFalse(overdraftRequest.IsApproved);
        Assert.IsTrue(overdraftRequest.IsProcessed);
    }

    [Test]
    public void ProcessOverdraftRequest3()
    {
        manager.ProcessOverdraftRequest(overdraftRequest, true);

        Assert.Throws<InvalidOperationException>(() => manager.ProcessOverdraftRequest(overdraftRequest, false));
    }
}
