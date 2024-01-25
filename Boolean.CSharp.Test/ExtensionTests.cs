﻿using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountFolder;
using Boolean.CSharp.Main.Overdrafts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static Boolean.CSharp.Main.AccountFolder.Enums;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {

        [Test]

        public void TestODRequest()
        {
            SavingsAccount savings = new SavingsAccount(Enums.Branches.Rohan);
            var request = savings.RequestOverdraft(50000);

            Assert.That(savings.OverDraftRequests.Count() > 0);
            Assert.That(request == true);

        }

        [Test]
        public void TestODApproval() 
        {
            SavingsAccount savings = new SavingsAccount(Enums.Branches.Rohan);
            savings.RequestOverdraft(50000);

            savings.FixODrequest(OverdraftRequests.Approved);

            var filterApproved = savings.OverDraftRequests.Where(x => x.Status == OverdraftRequests.Approved);
            Assert.That(filterApproved.Count() > 0);
        }

        [Test]
        public void TestODDenial()
        {
            SavingsAccount savings = new SavingsAccount(Enums.Branches.Rohan);
            savings.RequestOverdraft(50000);

            savings.FixODrequest(OverdraftRequests.Denied);

            var filterDenied = savings.OverDraftRequests.Where(x => x.Status == OverdraftRequests.Approved);
            Assert.That(filterDenied.Count() > 0);

        }


    }
}
