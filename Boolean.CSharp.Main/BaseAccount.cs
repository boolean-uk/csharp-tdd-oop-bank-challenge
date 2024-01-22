using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class BaseAccount
    {
        private LogTransaction _logger = new LogTransaction();
        private Branch _branch;
        public LogTransaction Logger { get { return _logger; } }
        public BaseAccount(Branch branch)
        {
            _branch = branch;
        }
        public bool Deposit(float amount)
        {
            if (amount < 0) return false;
            _logger.AddLog(amount);
            return true;
        }
        public bool Withdraw(float amount, bool isOverdraft = false)
        {
            if (amount < 0 || (_logger.CurrentBalance() < amount && !isOverdraft)) return false;
            _logger.AddLog(-amount);
            return true;
        }

        public OverdraftRequest RequestOverdraft(int amountMoney)
        {
            OverdraftRequest request = new OverdraftRequest(amountMoney, this);
            return request;
        }

    }
}
