using Boolean.CSharp.Main;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    public class ExtensionTests
    {
        [Test]
        public void CanSetBranch()
        {
            //create new bankAccount
            BankAccount myAccount = new BankAccount();

            //Check if branch is default
            Assert.IsTrue(myAccount.branch.Equals("DefaultBranch"));

            //set branch to paris
            myAccount.SetBranch("Paris");

            //check if branch is set to paris
            Assert.IsTrue(myAccount.branch.Equals("Paris"));
        }

        [Test]
        public void OverdraftTest()
        {
            //new bankAccount
            BankAccount myAccount = new BankAccount();

            //try to make withdrawal without overdraft approved
            myAccount.MakeTransaction(-100.0f);
            Assert.AreEqual(0.0f, myAccount.currentBalance);

            //insert money
            myAccount.MakeTransaction(50.0f);

            //request overdraft
            myAccount.RequestOverdraft(500.0f);

            //approve overdraft
            myAccount.ApproveOverdraftRequest();

            //withdraw overdraft
            myAccount.MakeTransaction(-100.0f);
            Assert.AreEqual(-50.0f, myAccount.currentBalance);

            myAccount.MakeTransaction(-400.0f);
            Assert.AreEqual(-450.0f, myAccount.currentBalance);

            //check that it is not possible to make overdraft over the limit
            myAccount.MakeTransaction(-400.0f);
            Assert.AreEqual(-450.0f, myAccount.currentBalance);
        }
    }
}
