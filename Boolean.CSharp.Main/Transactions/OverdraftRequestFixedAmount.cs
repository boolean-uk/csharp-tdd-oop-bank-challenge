using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class OverdraftRequestFixedAmount(Customer customer, decimal newLimit, IAccount account) : IOverdraftRequest
    {
        Customer _customer = customer;
        decimal _desiredOverdraftLimit = newLimit;
        DateTime _time = DateTime.Now;
        IAccount _account = account;

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
