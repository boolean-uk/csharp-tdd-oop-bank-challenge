using NUnit.Framework;
using System;
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using System.Collections.Generic;

namespace Boolean.CSharp.Test;

public class CustomerTest
{
    private Customer _customer;
    private Account _account;

    [SetUp]
    public void Setup()
    {
        BankBranch branch = new BankBranch("testbranch");
        _customer = new Customer("jonas", "12345672");
        _account = new Account("saving", _customer.userId, branch);
    }

    [Test]
    public void CreateAccount()
    {
        _customer.CreateAccount(_account);
        var statement = _customer.getStatement(_account.accountId);
        Assert.AreNotEqual("Account not found", statement);
    }

    [Test]
    public void DeleteAccount()
    {
        _customer.CreateAccount(_account);
        _customer.DeleteAccount(_account);
        var statement = _customer.getStatement(_account.accountId);
        Assert.AreEqual("Account not found", statement);
    }
}
