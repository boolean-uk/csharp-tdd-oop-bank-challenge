using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        private DateTime _Date {  get; } = DateTime.Now;
        public string FormattedDate => _Date.ToString("yyyy-MM-dd");
        public decimal Amount { get; }
        public decimal Balance { get; }
        
        public Transaction(decimal amount, decimal balance)
        {
            Amount = amount;
            Balance = balance;
        }
    }
}
