using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class BankTransaction
    {
        List<Transaction> TransactionHistory = new List<Transaction> ();

        public void Create_Transaction(object type, object amount, object account_id)
        {
            throw new NotImplementedException();
        }
    }
}
