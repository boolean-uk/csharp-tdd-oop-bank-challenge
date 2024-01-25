using Boolean.CSharp.Main.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ITransaction
    {
        double Balance { get; }
        double Amount { get; }
        DateTime DateTime { get; }
        double OldBalance { get; }
        TransactionType TransactionType { get; }

    }
}
