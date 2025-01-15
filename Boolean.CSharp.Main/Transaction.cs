using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public string type { get; set; } = "Unknown";
        public decimal amount { get; set; } = 0;
        public Transaction(string Type, decimal Amount) 
        {
            type = Type;
            amount = Amount;
        }
    }
}
