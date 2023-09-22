using Boolean.CSharp.Main;
using NUnit.Framework;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class OverDraftTests
    {
        private User GetSampleUser()
        {
            return new User("Harry Potter", "LordVoldemort23", "SneepyWeepyStreet", "111111", "harry@potter.hogwarts");
        }

        [Test]
        public void CanWeRequestAnOverdraft()
        {
            var account = new CurrentAccount(AllEnums.Branches.Antwerpen, GetSampleUser());
            account.RequestOverdraft(5000);
            Assert.AreEqual(5000, account.OverdraftLimit);
            Assert.AreEqual(AllEnums.OverdraftStatus.Requested, account.OverdraftStatus);
        }

        [Test]
        public void CanWeApproveAnOverdraftRequest()
        {
            var account = new CurrentAccount(AllEnums.Branches.Antwerpen, GetSampleUser());
            account.RequestOverdraft(2000);
            account.ApproveOverdraft();
            Assert.AreEqual(AllEnums.OverdraftStatus.Approved, account.OverdraftStatus);
        }

        [Test]
        public void CanWeRejectAnOverdraftRequest()
        {
            var account = new CurrentAccount(AllEnums.Branches.Antwerpen, GetSampleUser());
            account.RequestOverdraft(2999);
            account.RejectOverdraft();
            Assert.AreEqual(0, account.OverdraftLimit);
            Assert.AreEqual(AllEnums.OverdraftStatus.Rejected, account.OverdraftStatus);
        }

        [Test]
        public void WeShouldNotBeAbleToRequestNegativeOverdraft()
        {
            var account = new CurrentAccount(AllEnums.Branches.Antwerpen, GetSampleUser());
            Assert.Throws<ArgumentException>(() => account.RequestOverdraft(-1000));
        }

        [Test]
        public void WeCannotApproveWithoutARequest()
        {
            var account = new CurrentAccount(AllEnums.Branches.Antwerpen, GetSampleUser());
            Assert.Throws<InvalidOperationException>(() => account.ApproveOverdraft());
        }

        [Test]
        public void WeCannotRejectWithoutARequest()
        {
            var account = new CurrentAccount(AllEnums.Branches.Antwerpen, GetSampleUser());
            Assert.Throws<InvalidOperationException>(() => account.RejectOverdraft());
        }
    }
}
