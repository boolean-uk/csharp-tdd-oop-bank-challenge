using Boolean.CSharp.Main.Classes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class BankTests
    {

        [Test]

        public void checkIfRegularAccountCreated()
        {
            //Arrange
            Bank bank = new Bank();
            RegularAccount Raccount = new RegularAccount();
            string accountHolder = "Jonh Johnson";
            string type = "Regular";

            //Act
            Raccount.Create(type,accountHolder);
            var account = bank.accounts.OfType<RegularAccount>().FirstOrDefault(x => x.nameOfHolder==accountHolder);

            //Assert
            Assert.IsTrue(bank.accounts.Contains(account));
            bank.accounts.Remove(account);

        }

        public void checkIfSavingsAccountCreated()
        {

            //Arrange 
            Bank bank = new Bank();
            SavingsAccount Saccount = new SavingsAccount();
            string accountHolder = "Mike Smith";
            string type = "Savings";
            bool overdrafted  = false;
            decimal overdraftAmount = 0;
            decimal rent = 1.23m;

            //Act
            Saccount.Create(type, accountHolder);
            var account = bank.accounts.OfType<SavingsAccount>().FirstOrDefault(x => x.nameOfHolder == accountHolder);


            //Assert
            Assert.IsTrue(bank.accounts.Contains(account));
            bank.accounts.Remove(account);

        }
    }
}
