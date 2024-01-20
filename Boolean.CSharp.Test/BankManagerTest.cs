using NUnit.Framework;
namespace Boolean.CSharp.Main
{
    [TestFixture]
    public class BankManagerTest
    {

        [Test]
        public void TestApproveOverdraft()
        {
            CurrentAccount current = new CurrentAccount(0);
            BankManager manager = new Main.BankManager();
            current.OverdraftMoney(100f);
            Transaction retunTrans = new Transaction(100f, true);
            Assert.That(manager.ApproveOverdraft(current), Is.EqualTo(retunTrans));
        }

        [Test]
        public void TestDeclineOverdraft()
        {
            CurrentAccount current = new CurrentAccount(0);
            BankManager manager = new Main.BankManager();
            current.OverdraftMoney(100f);
            Assert.That(manager.RejectOverdraft(current), Is.True);
        }
    }
}