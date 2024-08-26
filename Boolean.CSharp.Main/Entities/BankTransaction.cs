using Boolean.CSharp.Main.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Entities
{
    public class BankTransaction
    {
        private DateTime _date;
        private TransactionType _transationType;
        private double _credit;
        private double _debit;

        public BankTransaction(double amount, TransactionType t)
        {
            this._date = DateTime.Now.Date;
            this._transationType = t;

            if (t == TransactionType.Deposit) 
            {
                this._debit = amount;
                this._credit = 0;
            }
            else
            {
                this._credit = amount;
                this._debit = 0;
            }
        }

    
    }
}

