using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : Account
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

        public override AccountTransaction Deposit(double amount)
        {
            throw new NotImplementedException();
        }

        public override AccountTransaction Withdraw(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
