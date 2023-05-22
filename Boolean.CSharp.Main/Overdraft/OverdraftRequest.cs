using BankingApp.Boolean.CSharp.Main;
using BankingApp.Boolean.CSharp.Main.Accounts;
using BankingApp.Boolean.CSharp.Main.Overdraft;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main.Overdraft
{
    public class OverdraftRequest
    {
        public Account Account { get; set; }
        public decimal RequestedAmount { get; set; }
        public bool IsApproved { get; set; } = false;

    }
}
