using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interface;

namespace Boolean.CSharp.Main
{
    public class CreditTransaction : ITransaction
    {
        public decimal transactionAmount { get; set; }
        public DateTime transactionDate { get; set;  }
        public string type { get; set; } = "Credit";
        public decimal balance { get; set; }

        public CreditTransaction(decimal _transactionAmount)
        {
            this.transactionAmount = _transactionAmount;
            this.transactionDate = DateTime.Now;
        }
            
       
       
    }
}
