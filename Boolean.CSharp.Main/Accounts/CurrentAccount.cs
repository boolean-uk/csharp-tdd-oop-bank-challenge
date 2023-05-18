using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : Account
    {
        public CurrentAccount()
        {
        }

        public float Balance { get; set; }
        public string Transactions { get; set; }

        public object GenerateStatement()
        {
            return new BankStatement();
        }
    }
}
