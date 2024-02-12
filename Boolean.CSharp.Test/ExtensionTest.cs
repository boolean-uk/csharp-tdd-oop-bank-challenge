using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTest
    {
        [Test]
        public void TestGenerateBankStatement2()
        {

            Customer customer = new Customer();
            CurrentAccount currentaccount = new CurrentAccount();
            BankTransaction newtransaction = new BankTransaction();
            BankTransaction secondtransaction = new BankTransaction();
            BankTransaction thirdtransaction = new BankTransaction();
            newtransaction.makeTransaction("10.01.2012", "Deposit", 1000, currentaccount);

            customer.TransactionHistory.Add(newtransaction);

            secondtransaction.makeTransaction("13.01.2012", "Deposit", 2000, currentaccount);

            customer.TransactionHistory.Add(secondtransaction);

            thirdtransaction.makeTransaction("14.01.2012", "Withdrawal", 500, currentaccount);

            customer.TransactionHistory.Add(thirdtransaction);

            customer.generateStatement();

            // Assert
            var expectedOutput = "      Date ||     Credit ||      Debit ||    Balance\r\n" +
                                 $"{"14.01.2012"} ||          0 ||        500 || 2500,00\r\n" +
                                 $"{"13.01.2012"} ||       2000 ||          0 || 3000,00\r\n" +
                                 $"{"10.01.2012"} ||       1000 ||          0 || 1000,00\r\n";

            Assert.AreEqual(expectedOutput, customer.generateStatement());
        }


        [Test]
        public void TestCreateBranchs()
        {
            CurrentAccount currentaccount = new CurrentAccount();
            currentaccount.creatCurrentAccount(123, 500, "Current", Branch.Oslo, "None");
            Assert.AreEqual(Branch.Oslo, currentaccount.Branch);
        }

        [Test]

        public void TestOverdraft()
        {
            Customer customer = new Customer();
            CurrentAccount currentaccount = new CurrentAccount();
            BankTransaction firsttransaction = new BankTransaction();
    
            firsttransaction.makeTransaction("23.01.2023", "Deposit", 500, currentaccount);

            customer.TransactionHistory.Add(firsttransaction);

            BankTransaction secondtransaction = new BankTransaction();

            secondtransaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Withdrawal", 1500, currentaccount);

            customer.TransactionHistory.Add(secondtransaction);

            Assert.AreEqual(-1000, customer.BalanceFromTransactions(customer.TransactionHistory));

        }


        [Test]
        public void TestRejectOverdraft()
        {
            Customer customer = new Customer();
            CurrentAccount currentaccount = new CurrentAccount();
            BankTransaction firsttransaction = new BankTransaction();

            firsttransaction.makeTransaction("23.01.2023", "Deposit", 500, currentaccount);

            customer.TransactionHistory.Add(firsttransaction);

            BankTransaction secondtransaction = new BankTransaction();

            secondtransaction.makeTransaction(DateTime.Now.ToString("dd/MM/yyyy"), "Withdrawal", 4000, currentaccount);

            customer.TransactionHistory.Add(secondtransaction);

            Assert.AreEqual(-3500, customer.BalanceFromTransactions(customer.TransactionHistory));

        }


    }
}
