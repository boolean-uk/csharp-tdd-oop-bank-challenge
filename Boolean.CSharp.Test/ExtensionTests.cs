using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts.Constants;
using Boolean.CSharp.Main.Users;
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
        public BankApplication bankApp;
        public Custommer custommer1;
        public Engineer engineer1;

        [SetUp]
        public void Setup()
        {
            bankApp = new BankApplication();

            custommer1 = new Custommer()
            {
                Name = "Kanthee",
                Branch = Branches.Bergen,
                Id = 1000
            };

            engineer1 = new Engineer() { 
                Name = "Idaa",
                Id = 0001
            };


        }

        [Test]
        public void TestMakeEngineerAccount()
        {

            bankApp.Add(custommer1);
            bankApp.Add(engineer1);
            custommer1.makeAccount(Enums.Saving);
            custommer1.makeAccount(Enums.Current);
            var users = bankApp.seeUsers();

            // There should be 1 user in the bank and the custommer should have 2 accounts.
            Assert.IsTrue(users.Count == 2 && custommer1.getAccAccounts().Count == 2);

        }
    }
}
