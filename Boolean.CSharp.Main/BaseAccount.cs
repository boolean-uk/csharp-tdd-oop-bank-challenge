using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class BaseAccount
    {
        public float Money { get { return _logger.CurrentBalance(); } }
        private LogTransaction _logger = new LogTransaction();
        public bool Deposit(float amount)
        {
            if (amount < 0) return false;
            _logger.AddLog(amount);
            return true;
        }
        public bool Withdraw(float amount)
        {
            if (amount < 0 || _logger.CurrentBalance() < amount) return false;
            _logger.AddLog(-amount);
            return true;
        }

    }
}
