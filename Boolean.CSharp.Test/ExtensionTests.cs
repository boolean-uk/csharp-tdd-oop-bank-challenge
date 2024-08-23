using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        [Test]
        public void TestCalculateBankBalanceWithTransactionHistory()
        {
            Bank bank = new Bank();
            string user = "Bob";
            BankTypes bankType = BankTypes.Current;
            double amountDeposit = 1000;
            double amountWithdraw = 700;
            double expectedResult = 300;

            int bankID = bank.AddAccount(user, bankType);
            bank.Deposit(bankID, amountDeposit);
            bank.Withdraw(bankID, amountWithdraw);

            double result = bank.CalculateBalance(bankID);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void AddAccountWithBranch()
        {
            Bank bank = new Bank();
            string user = "Spanders";
            BankTypes bankType = BankTypes.Saving;
            BankTypes banktype2 = BankTypes.Current;
            Branches branch = Branches.Oslo;

            bank.AddAccount(user, bankType, branch);
            int result = bank.AddAccount(user, banktype2, branch);

            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void RequestOverdraftTest()
        {
            Bank bank = new Bank();
            string user = "Spanders";
            BankTypes bankType = BankTypes.Current;
            Branches branch = Branches.Oslo;
            int requestAmount = 1000;

            int ID = bank.AddAccount(user, bankType, branch);
            int requestID = bank.RequestOverdraft(ID, requestAmount);

            Assert.That(requestID, Is.EqualTo(1));
        }
        [Test]
        public void ApproveOverDraftRequestTest()
        {
            Bank bank = new Bank();
            string user = "Spanders";
            BankTypes bankType = BankTypes.Current;
            Branches branch = Branches.Oslo;
            int requestAmount = 1000;
            Roles IsAdmin = Roles.Admin;
            RequestStatus toBeStatus = RequestStatus.Accepted;

            int ID = bank.AddAccount(user, bankType, branch);
            int requestID = bank.RequestOverdraft(ID, requestAmount);

            double result = bank.ApproveOverdraftRequest(ID, requestID, IsAdmin, toBeStatus);
            Assert.That(result, Is.EqualTo(requestAmount));
        }

        [Test]
        public void ApproveOverDraftRequestTestAsUser()
        {
            Bank bank = new Bank();
            string user = "Spanders";
            BankTypes bankType = BankTypes.Current;
            Branches branch = Branches.Oslo;
            int requestAmount = 1000;
            Roles IsAdmin = Roles.User;
            RequestStatus toBeStatus = RequestStatus.Accepted;

            int ID = bank.AddAccount(user, bankType, branch);
            int requestID = bank.RequestOverdraft(ID, requestAmount);

            double result = bank.ApproveOverdraftRequest(ID, requestID, IsAdmin, toBeStatus);
            Assert.That(result, Is.EqualTo(-1));
        }
    }
}
