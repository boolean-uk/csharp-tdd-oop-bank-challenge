using Boolean.CSharp.Main;
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
        public void CheckBalance()
        {
           
            // I want account balances to be calculated based on transaction history instead of stored in memory.

            // Arrange
            Core _core = new Core();

            List<IAccount> accountslist = new List<IAccount>();
 
            _core.CreateUser("Malimo", "123456", accountslist);
            var user = _core.userList.First();
            var type = AccountType.Current;


            _core.creatBankAcc(user, type);

            var accountname = _core.userList.First().AccountList.First();

            int amount = 2000;
            int amount1 = 1500;

            // Act
            _core.WithdrawAmount(user, amount1, accountname);
            _core.DepositAmount(user, amount, accountname);

            // Assert
            Assert.AreEqual(-amount1 + amount, _core.userList.First().AccountList.First().Transactions.Last().Balance);
        }

    }
}
