using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    internal interface IAccount
    {
        int ID { get; }
        string Type { get; set; }
        string Owner { get; set; }

        //string Branch { get; set; }

        List<Transaction> TransactionHistory { get; set; }

        double Balance { get; }
    }
}
