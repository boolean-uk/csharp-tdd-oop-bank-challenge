using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

[TestFixture]
public class MessageProviderTests
{
    private User _user = new User();
    
    [SetUp]
    public void Setup()
    {
        _user.FirstName = "John";
        _user.LastName = "Doe";
        _user.DOB = new DateTime(2001, 12, 31);
    }
    
    [Test]
    public void SendAccountStatementTest()
    {
        // No SMS sadly. Colorful console messages should do instead
        var messageProvider = new ConsoleMessageProvider();
        
        var account = new CheckingAccount(ref _user);
        
        account.Deposit(100);
        account.Withdraw(50);
        
        // Anything that doesn't cause an exception means it's good
        Assert.DoesNotThrow(() => account.SendStatement(messageProvider));
    }
}