using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {

        MainMenu menu = new MainMenu();
        CurrentAccount newcurrentaccount = new CurrentAccount();

        [Test]
        public void CreateOverdraft()
        {
            newcurrentaccount.Request_Overdraft(Main.Enums.Overdraft.Pending, 1000);

            Assert.IsTrue(newcurrentaccount.Overdraft == Main.Enums.Overdraft.Pending);
        }

        [Test]
        public void QualifyOverdraftbyManager()
        {
            newcurrentaccount.Request_Overdraft(Main.Enums.Overdraft.Pending, 1000);
            // As a manager
            menu.Qualify_Overdraft(newcurrentaccount);

            Assert.IsTrue(newcurrentaccount.Overdraft == Main.Enums.Overdraft.Approved);
        }

        [Test]
        public void GetBalanceFromTransactions()
        {
            BankTransaction newtransaction = new BankTransaction();
            BankTransaction secondtransaction = new BankTransaction();

            newtransaction.Date = DateTime.Now.ToString("dd/MM/yyyy");
            newtransaction.Transaction_type = Main.Enums.Transaction.Withdraw;
            newtransaction.Amount = 500;
            newtransaction.OldBalance = newcurrentaccount.balance;
            newtransaction.Calculate_Transaction("Withdraw", 500, newcurrentaccount);

            menu.TransactionHistory.Add(newtransaction);

            secondtransaction.Date = DateTime.Now.ToString("dd/MM/yyyy");
            secondtransaction.Transaction_type = Main.Enums.Transaction.Deposit;
            secondtransaction.Amount = 1500;
            secondtransaction.OldBalance = newcurrentaccount.balance;
            secondtransaction.Calculate_Transaction("Deposit", 1500, newcurrentaccount);

            menu.TransactionHistory.Add(secondtransaction);

            menu.BalanceFromTransactions(menu.TransactionHistory);

            Assert.IsTrue(menu.BalanceFromTransactions(menu.TransactionHistory) == 1000);
        }
    }
}
