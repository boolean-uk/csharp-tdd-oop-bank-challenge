using Boolean.CSharp.Main.Enums;
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
        public Enums.Transaction transaction_type { get; set; }
        public int amount { get; set; }
        public string account_id;

        public void Create_Transaction(string transaction_type, int amount, string account_id)
        {
            this.amount = amount;
            this.account_id = account_id;
            if (transaction_type == "Withdraw")
            {
                this.transaction_type = Enums.Transaction.Withdraw;
            }else if(transaction_type == "Deposit")
            {
                this.transaction_type = Enums.Transaction.Deposit;
            }
        }
    }
}
