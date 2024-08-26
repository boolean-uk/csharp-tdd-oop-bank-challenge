using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Enum;
using Boolean.CSharp.Main.Person;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CustomerTest
    {


        [Test]
        public void TestFindBankAccount()
        {
            Manager m = new Manager();
            Bank b = new Bank(m);

            Customer c = new Customer("Espen", "Luna", 93458577);

            b.CreateAccount(c, AccountType.Current);
            BankAccount act = c.FindBankAccount(0);

            Assert.That(act, Is.Not.Null);
        }

    }
}
