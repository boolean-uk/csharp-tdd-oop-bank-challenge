using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : Account
    {
        public bool Overdraft { get; set; } = false;

        public override string Withdraw(decimal amount)
        {
            if (Overdraft || Balance - amount > 0)
            {
                TransactionHistory.Add(new Transaction(-amount));
                return $"Withdrew {amount}NOK";
            }
            return "Insufficent funds";
        }
    }
}
