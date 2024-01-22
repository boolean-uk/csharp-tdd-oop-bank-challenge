using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Transations
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public TransactionStatus Status { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public decimal NewBalance { get; set; }
        public decimal OldBalance { get; set; }
        public string getTransations()
        {
            throw new NotImplementedException();
        }
    }
}
