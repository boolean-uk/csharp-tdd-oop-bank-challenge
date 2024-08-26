using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Acounts;
using Boolean.CSharp.Main.Extensions;
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
            Person pax = new Person("Flier", Role.CUSTOMER, null);
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

        [Test]

        public void AcceptOverdraftRequestTest()
        {
            decimal expectedBalance = -100;
            decimal expectedEmergencyFund = 9900;
            Bank bank = new Bank("DNB", 10000);
            Person avgjoe = new Person("Flier", Boolean.CSharp.Main.Role.CUSTOMER, null);
            Person manager = new Person("Big Dawg", Boolean.CSharp.Main.Role.MANAGER, bank);
            SavingsAccount savings = new SavingsAccount();
            avgjoe.addAccount(savings);


            savings.Deposit(1000);
           
            savings.RequestOverdraft(1100);

            manager.answerOverdraft(savings.OverdraftRequests.First());

            decimal resultBalance = savings.Balance;
            decimal resultEmergencyFund = bank.EmergencyFund;
            Assert.AreEqual(expectedBalance, resultBalance);
            Assert.AreEqual(resultEmergencyFund, expectedEmergencyFund);

        }
    }
}
