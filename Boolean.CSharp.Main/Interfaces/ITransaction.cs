using Boolean.CSharp.Main.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ITransaction
    {
        
        DateTime transactionTime { get; set; }

        decimal transactionAmount { get; set; }

        decimal newBalance { get; set; }

        TransactionType TransactionType { get; set; }
    }
}
