using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class BankStatement
    {
        public BankStatement(double v, bool s, eType e, DateTime d = default(DateTime)) 
        {
            _value = v;
            Status = s;
            Type = e;
            Date = d;

        }
        public readonly double _value;
        // transactionstatus enum?
        public readonly bool Status;
        public readonly eType Type;
        public readonly DateTime Date;

        public double Transaction { get { return Type == eType.Credit ? _value : _value * -1d; } }
    }
}
