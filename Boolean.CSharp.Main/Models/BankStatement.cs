using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Models.Transactions;

namespace Boolean.CSharp.Main.Models
{
    public class BankStatement
    {
         public List<ITransaction> Transactions { get; set; }

        public BankStatement(List<ITransaction> transactions)
        {
            Transactions = transactions;
        }

        public string printStatement()
        {
            string statement = "date \r || credit \r || debit \r || balance \n";
            foreach (ITransaction transaction in Transactions)
            {
                statement += transaction.transactionString() + "\n";
            }
            return statement;
        }
    }
}
