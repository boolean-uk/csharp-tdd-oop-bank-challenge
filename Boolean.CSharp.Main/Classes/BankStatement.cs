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
            _valid = v;
            _type = e;
            _date = d;

        }
        double _creditDebit;
        // transactionstatus enum?
        bool _valid;
        eType _type;
        DateTime _date;

        public double Transaction { get { return _type == eType.Deposit ? _creditDebit : _creditDebit * -1d; } }
    }
}
