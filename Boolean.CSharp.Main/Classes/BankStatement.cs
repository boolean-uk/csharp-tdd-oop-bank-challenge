using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class BankStatement
    {
        public BankStatement(double c, bool v, eType e, DateTime d = default(DateTime)) 
        {
            _creditDebit = c;
            Status = v;
            Type = e;
            Date = d;

        }
        public readonly double _creditDebit;
        // transactionstatus enum?
        public readonly bool Status;
        public readonly eType Type;
        public readonly DateTime Date;

        public double Transaction { get { return Type == eType.Credit ? _creditDebit : _creditDebit * -1d; } }
    }
}
