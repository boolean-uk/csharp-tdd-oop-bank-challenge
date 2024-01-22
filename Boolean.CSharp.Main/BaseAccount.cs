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
        private float _money;
        public float Money { get { return _money; } }
        private LogTransaction _logger = new LogTransaction();
        public bool Deposit(float amount)
        {
            if (amount < 0) return false;
            _money += amount;
            _logger.AddLog(amount, _money);
            return true;
        }
        public bool Withdraw(float amount)
        {
            if (amount < 0 || _money < amount) return false;
            _money -= amount;
            _logger.AddLog(-amount, _money);
            return true;
        }

    }
}
