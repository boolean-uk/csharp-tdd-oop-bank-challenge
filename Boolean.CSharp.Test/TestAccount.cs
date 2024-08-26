using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Branches;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class TestAccount
    {
        [TestCase(5, 2)]
        [TestCase(500, 0)]
        [TestCase(5000, 723)]
        [TestCase(250, 69)]
        [TestCase(35, 2)]
        [TestCase(52, 42)]
        public void TestBalance(double funds, double withdraw)
        {
            AmericanExpress branch = new AmericanExpress();
            Savings account = new Savings(1, 1, branch);

            account.Deposit(funds);

            account.Withdraw(withdraw);

            Assert.That(account.Balance() == funds - withdraw);
        }


        [Test]
        public void TestGenerateStatement()
        {
            AmericanExpress branch = new AmericanExpress();
            Savings account = new Savings(1, 1, branch);

            for (double funds = 1000.00; funds < 4000.00; funds += 1000.00)
            {
                account.Deposit(funds);
                account.Withdraw(funds / 2.0);
            }
            /*
             * +1000 
             * -500
             * +2000
             * -1000
             * +3000
             * -1500
             * 
             * 
             * 
            date       || credit  || debit  || balance
            14/01/2012 ||         || 500.00 || 2500.00
            13/01/2012 || 2000.00 ||        || 3000.00
            10/01/2012 || 1000.00 ||        || 1000.00
             */
            string date = DateTime.Now.ToString("dd/MM/yyyy");

            string expected =
             "date       || credit  || debit   || balance\n" +
                date + " ||         || 1500.00 || 3000.00\n" +
                date + " || 3000.00 ||         || 4500.00\n" +
                date + " ||         || 1000.00 || 1500.00\n" +
                date + " || 2000.00 ||         || 2500.00\n" +
                date + " ||         || 500.00  || 500.00 \n" +
                date + " || 1000.00 ||         || 1000.00\n";


            string result = account.GenerateStatement();

            Assert.That(result == expected);
        }

    }
}
