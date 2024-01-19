using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
//using Boolean.CSharp.Main;


namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public DateTime Date { get; }
        public decimal Credit { get; }
        public decimal Debit { get; }

        public Transaction(DateTime date, decimal credit, decimal debit)
        {
            if ((credit >= 0 && debit == 0) || (credit == 0 && debit >= 0))
            {
                Date = date;
                Credit = credit;
                Debit = debit;
            }
            else { throw new ArgumentException("Can't deposit and withdraw at the same time"); }
        }

    }




}
