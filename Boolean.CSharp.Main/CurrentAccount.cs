using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public CurrentAccount(string accountNumber, double balance) : base(accountNumber, balance, "saving")
        {
        }
    }
}
