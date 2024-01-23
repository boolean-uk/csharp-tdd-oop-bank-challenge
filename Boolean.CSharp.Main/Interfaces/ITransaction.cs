using Boolean.CSharp.Main.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface ITransaction
    {
        DateTime _dateTime { get; set; }
        double _amount { get; set; }
        double _balance { get; set; }

        TransactionType _type { get; set; }
    }
}
