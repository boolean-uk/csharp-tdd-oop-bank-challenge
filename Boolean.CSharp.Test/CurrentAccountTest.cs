using Boolean.CSharp.Main.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class CurrentAccountTest
    {
        [Test]
        public void ClientMakesDeposit()
        {
            //Arrange
            CurrentAccount currentAccount = new CurrentAccount();

            // Act
            currentAccount.Deposit(1000);

            // Assert
            Assert.AreEqual(1000, currentAccount.GetBalance());

        }
    }
}
