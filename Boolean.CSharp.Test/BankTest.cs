using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BankTest
    {
        [Test]
        public void TestCreateCurrentAccount()
        {
            Bank bank = new Bank();
            CurrentAccount account = new CurrentAccount();
            CurrentAccount result = bank.CreateCurrentAccount(account, Branches.Oslo);
            Assert.IsNotNull(result);

        }

        [Test]
        public void TestCreateSavingAccount()
        {
            Bank bank = new Bank();
            SavingsAccount account = new SavingsAccount();
            
            SavingsAccount result = bank.CreateSavingsAccount(account,Branches.Oslo);
            Assert.IsNotNull(result);

        }

        [Test]
        public void TestMakingStatements()
        {
            Bank bank = new Bank();
            CurrentAccount account = new CurrentAccount();
            CurrentAccount myAccount = bank.CreateCurrentAccount(account, Branches.Oslo);
            bank.Deposit(1000, myAccount);
            bank.Deposit(2000, myAccount);
            bank.Withdrawel(1000, myAccount);
            int expected = 3;

            Assert.That(bank.GetStatementsSize() == expected);

        }

        [Test]
        public void TestMakingDepositAndWithdrawel()
        {
            Bank bank = new Bank();
            SavingsAccount temp1 = new SavingsAccount();
            CurrentAccount temp2 = new CurrentAccount();

            SavingsAccount savAccount = bank.CreateSavingsAccount(temp1, Branches.Oslo);
            CurrentAccount curAccount = bank.CreateCurrentAccount(temp2, Branches.Oslo);
            bank.Deposit(1000, savAccount);
            bank.Deposit(2000, curAccount);
            bank.Withdrawel(1000, savAccount);
            bank.Deposit(2000, savAccount);
            double expected = 2000;
            bank.ShowBankStatements();
            Assert.That(expected == savAccount.Balance);
        }

        [Test]
        public void TestMakingDepositAndWithdrawel2()
        {
            Bank bank = new Bank();
            SavingsAccount temp1 = new SavingsAccount();
            CurrentAccount temp2 = new CurrentAccount();
            SavingsAccount savAccount = bank.CreateSavingsAccount(temp1, Branches.Oslo);
            CurrentAccount curAccount = bank.CreateCurrentAccount(temp2, Branches.Oslo);
            bank.Deposit(1000, savAccount);
            bank.Deposit(2000, curAccount);
            bank.Withdrawel(1000, savAccount);
            bank.Withdrawel(1000, savAccount);
            bank.Withdrawel(3000, curAccount);
            double expected = -1000;
            bank.ShowBankStatements();
            Assert.That(expected == curAccount.Balance);



        }



        }
    }
