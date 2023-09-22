using System;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Boolean.CSharp.Main
{
    public class BankStatement
    {
        public List<Transaction> Transactions { get; set; }
    }
}
