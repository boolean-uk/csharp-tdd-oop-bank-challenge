using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.enums;
using Boolean.CSharp.Main.Interfaces;
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
        [Test]
        public void Test_01_GetBalance_BasedOnTransactionHistory_LotsaTransactions()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer, Branch.Retail);
            for (int i = 0; i < 20; i++) //10x each
            {
                if (!(i % 2 == 0))
                {
                    currentAccount.Deposit(1900);
                }
                else
                {
                    currentAccount.Withdraw(1000);
                }
            }
            currentAccount.Deposit(1);

            //Act
            decimal expectedResult = currentAccount.GetBalance();
            decimal actualResult = 9001;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }


        [Test]
        public void Test_02_BranchTest()
        {
            //Arrange
            Customer customer1 = new Customer("Andreas Lauvhjell");
            Customer customer2 = new Customer("Halfdan the Black");
            Customer customer3 = new Customer("Harald Fairhair");
            Customer customer4 = new Customer("Eirik Bloodaxe");
            Customer customer5 = new Customer("Harald Greycloak");
            Customer customer6 = new Customer("Håkon the Good");

            AccountCurrent retail1 = new AccountCurrent(customer1, Branch.Retail);
            AccountCurrent retail2 = new AccountCurrent(customer2, Branch.Retail);
            AccountCurrent retail3 = new AccountCurrent(customer3, Branch.Commercial);
            AccountCurrent retail4 = new AccountCurrent(customer4, Branch.Private);
            AccountSavings retail5 = new AccountSavings(customer5, Branch.Pension);
            AccountSavings retail6 = new AccountSavings(customer6, Branch.Pension);

            List<Account> accounts =
            [
                retail1,
                retail2,
                retail3,
                retail4,
                retail5,
                retail6,
            ];

            //Act
            int expectedRetail = accounts.Count(account => account.Branch == Branch.Retail);
            int expectedCommercial = accounts.Count(account => account.Branch == Branch.Commercial);
            int expectedPrivate = accounts.Count(account => account.Branch == Branch.Private);
            int expectedPension = accounts.Count(account => account.Branch == Branch.Pension);


            int actualRetail = 2;
            int actualCommercial = 1;
            int actualPrivate = 1;
            int actualPension = 2;

            //Assert
            Assert.That(expectedRetail, Is.EqualTo(actualRetail));
            Assert.That(expectedCommercial, Is.EqualTo(actualCommercial));
            Assert.That(expectedPrivate, Is.EqualTo(actualPrivate));
            Assert.That(expectedPension, Is.EqualTo(actualPension));
        }

        [Test]
        public void Test_03_OverdraftRequest()
        {
            //Arrange
            Customer customer = new Customer("Andreas Lauvhjell");
            AccountCurrent currentAccount = new AccountCurrent(customer, Branch.Retail);
            currentAccount.Deposit(1000);

            //Act
            currentAccount.RequestOverdraft(2000);
            decimal expectedResult = currentAccount.GetBalance();
            decimal actualResult = -1000;

            //Assert
            Assert.That(expectedResult, Is.EqualTo(actualResult));
        }
    }
}
