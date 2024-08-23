using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface ITransaction
    {
        DateTime TransactionDate { get; }

        decimal Amount { get; set; }
        decimal BalanceAfterTransaction { get; set; }
        string Type { get; set; }
    }
}
