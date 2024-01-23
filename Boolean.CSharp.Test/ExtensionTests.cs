using Boolean.CSharp.Main;
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
            public void ExtensionAccountTypeSavingsTest()
            {
            
           Branch mainBranch = new Branch("Main Branch");
            BankAccountExtension userAccount = new SavingsAccountExtension("1234", mainBranch);

           
            Assert.AreEqual(AccountTypeExtension.Savings, userAccount.Type);
            }
        [Test]
        public void CorrectBranchTest()
        {
            
            Branch mainBranch = new Branch("Main Branch");
            BankAccountExtension userAccount = new CurrentAccountExtension("123", mainBranch);

          
            Assert.AreEqual(mainBranch, userAccount.AssociatedBranch);
        }

    }
}
