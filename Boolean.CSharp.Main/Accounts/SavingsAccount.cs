using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Exceptions;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : RegularAccount
    {
        private double _withdrawalLimit;
        private DateTime _withdrawalLock;

        public double WithdrawalLimit
        {
            get { return _withdrawalLimit; }
            set
            {
                if (DateTime.Now > _withdrawalLock) { _withdrawalLimit = value; }
            }
        }
        public DateTime WithdrawalLock { get { return _withdrawalLock; } }
        public SavingsAccount(string name, double withdrawalLimit, DateTime withdrawalLock, Branch branch = Branch.Trondheim) : base(name, branch)
        {
            _withdrawalLimit = withdrawalLimit;
            _withdrawalLock = withdrawalLock;
        }

        public SavingsAccount(string name, double withdrawalLimit, Branch branch = Branch.Trondheim) : base(name, branch)
        {
            _withdrawalLimit = withdrawalLimit;
            _withdrawalLock = DateTime.Now;
        }

        public override AccountTransaction Withdraw(double amount)
        {
            if (_withdrawalLimit < amount) throw new LimitExceededException($"You have set the limit for withdrawals to {_withdrawalLimit}, but tried to withdraw {amount}");
            else if (DateTime.Now < _withdrawalLock) throw new LockedAccountException($"This account has locked withdrawals until {_withdrawalLock.ToString("yyyy-MM-dd HH-mm-ss")}");
            return base.Withdraw(amount);
        }
    }
}
