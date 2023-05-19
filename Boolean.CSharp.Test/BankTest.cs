using Boolean.CSharp.Main;
using Boolean.CSharp.Main.BankAccounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using Boolean.CSharp.Main.IUsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class BankTest
    {
        [Test]
        public void ChecksIfAccountWasCreated()
        {
            Bank bank = new Bank();
            IUser customer = new Customer("Stavros", "1212121212");
            BankAccount currentAccount = new BankAccount(customer);

            Assert.AreEqual(bank.CreateAccount(currentAccount, AccountType.Current), $"Current account created sucessfully for {currentAccount.User.Name}");
            Assert.AreEqual(bank.CreateAccount(currentAccount, AccountType.Current), $"A current account already exists for {currentAccount.User.Name}");
            Assert.AreEqual(bank.BankAccounts.Count, 1);
        }
    }
}
