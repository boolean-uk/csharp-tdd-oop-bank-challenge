using Boolean.CSharp.Main;
using NuGet.Frameworks;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class Tests
    {
        User ola = new User("Ola Nordmann");
        User manny = new User("Man Ager");

        CurrentAccount ca = new CurrentAccount("0123456789", "John Doe", Roles.Customer);
        SavingsAccount sa = new SavingsAccount("9876543210", "John Doe", Roles.Customer);

        [Test]
        public void TestCreateAccount()
        {

            Assert.IsNotNull(ca);
            Assert.IsNotNull(ca.Transactions);
            Assert.That(ca.Transactions.Count, Is.EqualTo(0));
            Assert.That(ca.GetBalance(), Is.EqualTo(0));

            CurrentAccount OlaCurAccount = ola.CreateAndGetCurrentAccount();

            Console.WriteLine(ola.Accounts[0].AccountNumber);
            Assert.That(ola.Accounts.Count, Is.EqualTo(1));
            Assert.That(ola.Accounts.Contains(OlaCurAccount));
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

            sa.Deposit(5000);
            sa.Withdraw(1000, false);
            sa.Withdraw(1000, false);
            sa.Withdraw(1000, false);
            sa.Withdraw(1000, false);

            try
            {
                ca.Withdraw(1000, false);
                Assert.Fail();
            }
            catch (Exception ex) { }

            sa.PrintBankStatement();
        }


        [Test]
        public void TestEngineerBalance()
        {
            double balanceCus = ola.GetBalance(ola.Accounts[0].AccountNumber);

            ola.Role = Roles.Engineer;

            double balanceEng = ola.GetBalance(ola.Accounts[0].AccountNumber);

            Assert.That(balanceCus, Is.EqualTo(balanceEng));
        }


        [Test]
        public void TestOverdraft()
        {
            manny.Role = Roles.Manager;

            CurrentAccount OlaCurAccount = ola.CreateAndGetCurrentAccount();

            ola.OverdraftRequests.Add(OlaCurAccount);

            try 
            {
                ola.HandleOverdraftRequest(OlaCurAccount.AccountNumber, ola.Accounts, 500);
                Assert.Fail();
            }catch (Exception ex) { }

            Assert.That(OlaCurAccount.Balance, Is.EqualTo(0));

            manny.HandleOverdraftRequest(OlaCurAccount.AccountNumber, ola.Accounts, 500);

            Assert.That(OlaCurAccount.Balance, Is.EqualTo(-500));

        }
        
    }
}