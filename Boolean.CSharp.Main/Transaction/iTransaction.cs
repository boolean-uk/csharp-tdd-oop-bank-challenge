using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transaction
{
    public interface iTransaction
    {
        List<Transaction> CurrentTransactions { get; set; }
        List<Transaction> SavingsTransactions { get; set; }
    }
}
