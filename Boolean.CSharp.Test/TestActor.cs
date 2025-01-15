using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Actors;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

public class TestActor
{
    [Test]
    public void TestActorCanCreateAccount()
    {
        SpareBank b = new SpareBank("Vestland");
        Actor customer = new Customer(b);
        Actor manager = new Manager(b);

        bool currrentCAccount = customer.CreateAccount("Current");
        bool savingsCAccount = customer.CreateAccount("Savings");

        bool currentMAccount = manager.CreateAccount("Current");
        bool savingsMAccount = manager.CreateAccount("Savings");

        Assert.IsTrue(currrentCAccount == savingsMAccount && currrentCAccount == currentMAccount && currrentCAccount == savingsCAccount && currrentCAccount == true);
    }

    [Test]
    public void TestActorCanAlterFunds()
    {
        SpareBank b = new SpareBank("Vestland");
        Actor customer = new Customer(b);
        Actor manager = new Manager(b);

        customer.CreateAccount("Current");
        customer.CreateAccount("Savings");

        manager.CreateAccount("Current");
        manager.CreateAccount("Savings");

        List<Account> cAccounts = customer.GetAccounts();
        List<Account> mAccounts = manager.GetAccounts();


        cAccounts.ForEach(acc => customer.AlterFunds(acc, 10, true));
        mAccounts.ForEach(acc => manager.AlterFunds(acc, 10, true));

        cAccounts.ForEach(acc => customer.AlterFunds(acc, 9, false));
        mAccounts.ForEach(acc => manager.AlterFunds(acc, 9, false));


        Assert.IsTrue(cAccounts.Sum(acc => acc.Balance) == 2);
        Assert.IsTrue(mAccounts.Sum(acc => acc.Balance) == 2); 

    }

    [Test]
    public void TestOnlyManagerCanAcceptOverdrafts()
    {
        SpareBank b = new SpareBank("Vestland");
        Actor customer = new Customer(b);
        Actor manager = new Manager(b);

        customer.CreateAccount("Current");
        manager.CreateAccount("Current");
        List<Account> cAccounts = b.GetAccounts(customer);
        List<Account> mAccounts = b.GetAccounts(manager);

        customer.RequestOverdraft(cAccounts[0], 10);
        manager.RequestOverdraft(mAccounts[0], 10);


        bool customerAccepts = customer.AcceptOverdraft(mAccounts[0]);
        bool managerAccepts = manager.AcceptOverdraft(cAccounts[0]);


        Assert.IsFalse(customerAccepts);
        Assert.IsTrue(managerAccepts);
    }
    
}
