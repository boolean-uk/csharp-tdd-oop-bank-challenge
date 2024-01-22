using NUnit.Framework.Internal.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class OverdraftRequest
    {
        private OverdraftStatus status;
        private int _amountMoney;
        BaseAccount _account;
        public OverdraftStatus Status { get { return status; } }
        public int Money { get { return _amountMoney; } }
        public OverdraftRequest(int amountMoney, BaseAccount account)
        {
            _amountMoney = amountMoney;
            status = OverdraftStatus.Pending;
            _account = account;
        }

        public bool Decline()
        {
            if (status == OverdraftStatus.Accepted) return false;
            status = OverdraftStatus.Declined;
            return true;
        }

        public bool Approve()
        {
            if (status == OverdraftStatus.Declined) return false;
            status = OverdraftStatus.Accepted;
            _account.Withdraw(_amountMoney, true);
            return true;
        }
    }

    public enum OverdraftStatus
    {
        Pending,
        Accepted,
        Declined
    }
}
