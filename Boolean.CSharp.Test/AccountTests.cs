using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test;

[TestFixture]
public class AccountTests
{
    [TestCase(5000, 2000, 3000)]
    [TestCase(100, 10, 90)]
    public void AccountDepositAndWithdrawTest(decimal deposit, decimal withdrawal, decimal expectedBalance)
    {
        var user = new User();
        var account = new CheckingAccount(ref user);
        
        account.Deposit(deposit);
        account.Withdraw(withdrawal);
        
        Assert.AreEqual(expectedBalance, account.Balance);
    }
}