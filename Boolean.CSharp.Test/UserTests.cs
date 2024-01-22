using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    public class UserTests
    {
        [Test]
        public void CreateCurrentAccount()
        {
            User user = new User();
            BranchCode branchCode = BranchCode.LOND;
            Account currentAcount = user.CreateCurrent(branchCode);
            Assert.That(currentAcount, Is.TypeOf<CurrentAccount>());
            Assert.That(currentAcount.GetBalance(), Is.EqualTo(0));
            Assert.That(currentAcount.BranchCode, Is.EqualTo(branchCode));
            Assert.That(currentAcount.transactions.Count(), Is.EqualTo(0));
            Assert.That(currentAcount.overdraftRequests.Count(), Is.EqualTo(0));
        }

        [Test]
        public void CreateSavingsAccount()
        {
            User user = new User();
            BranchCode branchCode = BranchCode.LOND;
            Account savingsAcount = user.CreateSavings(branchCode);
            Assert.That(savingsAcount, Is.TypeOf<SavingsAccount>());
            Assert.That(savingsAcount.GetBalance(), Is.EqualTo(0));
            Assert.That(savingsAcount.BranchCode, Is.EqualTo(branchCode));
            Assert.That(savingsAcount.transactions.Count(), Is.EqualTo(0));
            Assert.That(savingsAcount.overdraftRequests.Count(), Is.EqualTo(0));
        }
    }
}
