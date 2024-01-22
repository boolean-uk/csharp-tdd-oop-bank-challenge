using Boolean.CSharp.Main;
using NUnit.Framework;
using static Boolean.CSharp.Main.AllEnums;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class BranchTests
    {
        private User GetSampleUser()
        {
            return new User("Harry Potter", "LordVoldemort23", "SneepyWeepyStreet", "111111", "harry@potter.hogwarts");
        }

        [Test]
        public void AnAccountShouldAlwaysBeCorrespontedWithABranchWhenWeCreateAccount()
        {
            var account = new Account(Branches.Antwerpen, GetSampleUser());
            Assert.AreEqual(Branches.Antwerpen, account.Branch);
        }

        [Test]
        public void CurrentAccountShouldAlwaysBeCorrespontedWithABranchWhenWeCreateAccount()
        {
            var currentAccount = new CurrentAccount(Branches.Antwerpen, GetSampleUser());
            Assert.AreEqual(Branches.Antwerpen, currentAccount.Branch);
        }

        [Test]
        public void AnSavingsAccountShouldAlwaysBeCorrespontedWithABranchWhenWeCreateAccount()
        {
            var savingsAccount = new SavingsAccount(Branches.Antwerpen, GetSampleUser());
            Assert.AreEqual(Branches.Antwerpen, savingsAccount.Branch);
        }
    }
}
