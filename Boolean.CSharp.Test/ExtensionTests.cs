using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

[TestFixture]
public class ExtensionTests
{
    private Extension _extension;
    public ExtensionTests()
    {
        _extension = new Extension();
    }

    [Test]
    public void createBankBranchTest()
    {
        bool valid = _extension.Bank.createBankBranch("Innlandet");
        bool invalid = _extension.Bank.createBankBranch("Innlandet");

        Assert.That(valid, Is.True);
        Assert.That(invalid, Is.False);
        Assert.That(1, Is.EqualTo(_extension.Bank.getBanks().Count));
    }

    [Test]
    public void createCustomerTest()
    {
        _extension.Bank.createBankBranch("Innlandet");
        BankBranch branch = _extension.Bank.GetBankBranch("Innlandet");

        bool valid = branch.createCustomer("Gudbrand", "123456");
        bool invalid = branch.createCustomer("Guy", "123456");

        Assert.That(valid, Is.True);
        Assert.That(invalid, Is.False);
        Assert.That(1, Is.EqualTo(branch.Customers.Count));
    }

    [Test]
    public void createOverdraftRequestTest()
    {
        Manager manager = new Manager();
        IMessage messenger = new SmsSender();
        Customer customer = new Customer("Gudbrand", "123456", "1234", manager, messenger);

        customer.createCurrentAccount("1");
        customer.createOverdraftRequest(1, "12341234561", 10000);

        Assert.IsNotNull(manager.getOverdraftRequestById(1));
    }

    [Test]
    public void grantRequestTest()
    {
        Manager manager = new Manager();
        IMessage messenger = new SmsSender();
        Customer customer = new Customer("Gudbrand", "123456", "1234", manager, messenger);
        customer.createCurrentAccount("1");
        BankAccount account = customer.getAccountByNumber("12341234561");
        customer.createOverdraftRequest(1, "12341234561", 10000);

        manager.getOverdraftRequestById(1).grantRequest();
        bool valid = account.withdraw(10000);
        bool invalid = account.withdraw(1);

        Assert.IsNotNull(account);  
        Assert.That(valid, Is.True);
        Assert.That(invalid, Is.False);
    }

    [Test]
    public void denyRequestTest()
    {
        Manager manager = new Manager();
        IMessage messenger = new SmsSender();
        Customer customer = new Customer("Gudbrand", "123456", "1234", manager, messenger);
        customer.createCurrentAccount("2");
        BankAccount account = customer.getAccountByNumber("12341234562");
        customer.createOverdraftRequest(2, "12341234562", 10000);

        manager.getOverdraftRequestById(2).denyRequest();
        manager.getOverdraftRequestById(2).grantRequest(); // request is already denied so customer has to send another one
        bool invalid = account.withdraw(1);

        Assert.That(invalid, Is.False);
    }
}
