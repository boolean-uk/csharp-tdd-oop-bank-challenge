using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    internal class CheckingAccount : Account
    {
        public CheckingAccount(string accountNumber, string customerName, float startBalance, string accountType) : base(accountNumber, customerName, startBalance, accountType)
        {
        }
    }
}
