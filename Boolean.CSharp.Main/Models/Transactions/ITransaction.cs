using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Models.Transactions
{
    public interface ITransaction
    {
        decimal Amount { get; set; }
        DateTime Date { get; set; }
        decimal Balance { get; set; }
        void printTransaction();

    }
}
