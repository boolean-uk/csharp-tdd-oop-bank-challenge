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

        MainMenu menu = new MainMenu();
        CurrentAccount newcurrentaccount = new CurrentAccount();

        [Test]
        public void CreateOverdraft()
        {
            newcurrentaccount.Request_Overdraft(Main.Enums.Overdraft.Pending, 1000);

            Assert.IsTrue(newcurrentaccount.Overdraft == Main.Enums.Overdraft.Pending);
        }

        [Test]
        public void QualifyOverdraftbyManager()
        {
            newcurrentaccount.Request_Overdraft(Main.Enums.Overdraft.Pending, 1000);
            // As a manager
            menu.Qualify_Overdraft(newcurrentaccount);

            Assert.IsTrue(newcurrentaccount.Overdraft == Main.Enums.Overdraft.Approved);
        }
    }
}
