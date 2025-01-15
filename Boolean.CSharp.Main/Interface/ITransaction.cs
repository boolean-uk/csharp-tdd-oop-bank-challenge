using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interface
{
    public interface ITransaction
    {
        decimal transactionAmount { get; set; }
        DateTime transactionDate { get; set; }

        string type { get; set; }
        decimal balance { get; set; }

        void PrintTransactions();
        string PrintTransactionsString();




    }


}

