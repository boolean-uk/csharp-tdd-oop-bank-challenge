using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Bank
{
    public class Transaction : ITransaction
    {
        public DateTime _dateTime { get; set; }
        public double _amount { get; set; }
        public double _balance { get; set; }

        public TransactionType _type { get; set; }

    }
}
