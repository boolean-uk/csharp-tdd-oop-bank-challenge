using Boolean.CSharp.Main;
using NUnit.Framework;
using static Boolean.CSharp.Main.AllEnums;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BranchTests
    {
        [Test]
        public void AnAccountShouldAlwaysBeCorrespontedWithABranchWhenWeCreateAccount()
        {
            var account = new Account(Branches.Antwerpen);
            Assert.AreEqual(Branches.Antwerpen, account.Branch);
        }

        [Test]
        public void CurrentAccountShouldAlwaysBeCorrespontedWithABranchWhenWeCreateAccount()
        {
            var currentAccount = new CurrentAccount(Branches.Antwerpen);
            Assert.AreEqual(Branches.Antwerpen, currentAccount.Branch);
        }

        [Test]
        public void AnSavingsAccountShouldAlwaysBeCorrespontedWithABranchWhenWeCreateAccount()
        {
            var savingsAccount = new SavingsAccount(Branches.Antwerpen);
            Assert.AreEqual(Branches.Antwerpen, savingsAccount.Branch);
        }
    }
}
