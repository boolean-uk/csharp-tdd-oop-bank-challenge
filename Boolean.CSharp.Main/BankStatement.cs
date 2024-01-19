using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankStatement
    {
        public DateTime Date { get; } = new DateTime();
        public double? Credit { get; }
        public double Debit { get; }
        public double? Balance { get; }

        public BankStatement(double balance, double amount)
        {
            if (amount > 0)
            {
                Credit = amount;
            } else
            {
                Debit = amount;
            }
            Balance = balance;
        }
    }
}
