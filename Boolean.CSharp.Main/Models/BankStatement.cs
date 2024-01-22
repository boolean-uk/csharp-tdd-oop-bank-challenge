using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models
{
    public class BankStatement
    {
        public DateTime Date { get; } = DateTime.Now;
        public double? Credit { get; }
        public double? Debit { get; }
        public double Balance { get { return _balance; } }
        private readonly double _balance;

        public BankStatement(double balance, double amount)
        {
            balance += amount;
            if (Math.Round(amount) > 0)
            {
                Credit = amount;
            }
            else if (amount < 0)
            {
                Debit = Math.Abs(amount);
            }
            _balance = balance;
        }
    }
}
