using Boolean.CSharp.Main;
using NUnit.Framework;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        MainMenu menu = new MainMenu();
        CurrentAccount newcurrentaccount = new CurrentAccount();
        BankTransaction newtransaction = new BankTransaction();
        BankTransaction secondtransaction = new BankTransaction();
        BankTransaction thirdtransaction = new BankTransaction();

        [Test]
        public void CreateAccount()
        {
            newcurrentaccount.Create_Account("GR2342456708", 500, "Current");

            Assert.IsTrue(newcurrentaccount.account_id == "GR2342456708");
            Assert.AreEqual(newcurrentaccount.balance, 500);
        }


        [Test]
        public void ShouldCreateTransaction()
        {
            newcurrentaccount.Create_Account("GR2342456708", 500, "Current");
            newtransaction.Date = DateTime.Now.ToString("dd/MM/yyyy");
            newtransaction.Transaction_type = Main.Enums.Transaction.Withdraw;
            newtransaction.Amount = 500;
            newtransaction.OldBalance = newcurrentaccount.balance;
            newtransaction.Calculate_Transaction("Withdraw", 500, newcurrentaccount);

            Assert.AreEqual(newcurrentaccount.balance, 0);
        }

        [Test]
        public void WriteStatementAndCheckBalance()
        {
            newcurrentaccount.Create_Account("GR2342456708", 500, "Current");

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

            thirdtransaction.Date = DateTime.Now.ToString("dd/MM/yyyy");
            thirdtransaction.Transaction_type = Main.Enums.Transaction.Deposit;
            thirdtransaction.Amount = 700;
            thirdtransaction.OldBalance = newcurrentaccount.balance;
            thirdtransaction.Calculate_Transaction("Deposit", 700, newcurrentaccount);

            menu.TransactionHistory.Add(thirdtransaction);

            Assert.AreEqual(newcurrentaccount.balance, 2200); // the correct balance after all the transactions
        }
    }
}