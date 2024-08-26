using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public TransactionType type { get; set; }
    }
}
