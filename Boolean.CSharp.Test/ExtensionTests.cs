using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Acounts;
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

        public void PersonAccountTest()
        {
            Person pax = new Person("Flier", Role.CUSTOMER);
            CurrentSavingsAccount savingsAccount = new CurrentSavingsAccount();
            pax.addAccount(savingsAccount);

            decimal expected = 1500;
            savingsAccount.Deposit(1500);

            decimal result = pax.Accounts.First().getBalance();
            Assert.AreEqual(result, expected);


        }


        [Test]
        public void getBranchesTest()
        {
            Bank bank = new Bank("DNB", 10000);
            Branch stavangerBranch = new Branch("StavangerDNB");
            Branch osloBranch = new Branch("OsloDNB");

            bank.addBranch(stavangerBranch);
            bank.addBranch(osloBranch);
            string expected = "StavangerDNB";
            List<Branch> results = bank.getBranches();
            Assert.AreEqual(expected, results.First().Name);


        }
    }
}
