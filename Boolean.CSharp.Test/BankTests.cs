using Boolean.CSharp.Main;
using NuGet.Frameworks;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Tests
    {
        CurrentAccount ca = new CurrentAccount("0123456789", "John Doe", Roles.Customer);
        SavingsAccount sa = new SavingsAccount("9876543210", "John Doe", Roles.Customer);

        [Test]
        public void TestCreateAccount()
        {
            
            Assert.IsNotNull(ca);
            Assert.IsNotNull(ca.Transactions);
            Assert.That(ca.Transactions.Count, Is.EqualTo(0));
            Assert.That(ca.GetBalance(), Is.EqualTo(0)); 
        }


        [Test]
        public void TestDeposit()
        {
            ca.Deposit(1000);

            Assert.That(ca.Transactions.Count, Is.EqualTo(1));
            Assert.That(ca.GetBalance(), Is.EqualTo(1000));

            ca.Deposit(1500);

            Assert.That(ca.Transactions.Count, Is.EqualTo(2));
            Assert.That(ca.GetBalance(), Is.EqualTo(1000 + 1500));

            ca.Withdraw(2500, false);
        }

        [Test]
        public void TestWithdrawal()
        {
            try
            {
                ca.Withdraw(1000, false);
                Assert.Fail();
            }
            catch (Exception ex) { }

            ca.Deposit(2000);
            ca.Withdraw(1000, false);

            Assert.That(ca.GetBalance(), Is.EqualTo(1000));

            ca.Withdraw(1500, true);
            Assert.That(ca.GetBalance(), Is.EqualTo(-500));

            ca.PrintBankStatement();
        }

    }
}