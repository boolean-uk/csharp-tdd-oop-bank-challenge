using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class OverdraftRequestFixedAmount : IOverdraftRequest
    {
        Customer _customer;
        decimal _desiredOverdraftLimit;
        DateTime _time;
        IAccount _account;

        public OverdraftRequestFixedAmount(Customer customer, decimal newLimit, IAccount account)
        {
            _customer = customer;
            _desiredOverdraftLimit = newLimit;
            _time = DateTime.Now;
            _account = account;
        }

        /// <inheritdoc />
        public IAccount GetOverdraftRequestAccount()
        {
            return _account;
        }

        /// <inheritdoc />
        public DateTime GetRequestDate()
        {
            return _time;
        }

        /// <inheritdoc />
        public Customer GetRequester()
        {
            return _customer;
        }

        /// <inheritdoc />
        public decimal GetRequestOverdraftLimit()
        {
            return _desiredOverdraftLimit;
        }
    }
}
