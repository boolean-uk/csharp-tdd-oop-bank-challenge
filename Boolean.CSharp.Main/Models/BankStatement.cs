using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Models.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Main.Models
{
    public class BankStatement
    {
         public List<ITransaction> Transactions { get; set; }

        public BankStatement(List<ITransaction> transactions)
        {
            Transactions = transactions;
        }

      
        //I might have gotten some help on the formating of the strings
        public string getStatementString()
        {
            string statement = System.String.Format("{0,-12} || {1,-8} || {2,-8} || {3,-10}\n", "date", "credit", "debit", "balance");

            foreach (ITransaction transaction in Transactions)
            {
                statement += transaction.transactionString() + "\n";
            }
            return statement;
        }

     

    }
}
