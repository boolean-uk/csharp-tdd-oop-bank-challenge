using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Transaction
    {
        public string Date { get; set; }
        public string Credit { get; set; }
        public string Debit { get; set; }
        public string Balance { get; set; }

        public Transaction(string date, string credit, string debit, string balance)
        {
            Date = date;
            Credit = credit;
            Debit = debit;
            Balance = balance;
        }
    }
}
