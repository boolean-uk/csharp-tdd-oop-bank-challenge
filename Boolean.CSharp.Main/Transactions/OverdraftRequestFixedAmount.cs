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

        public OverdraftRequestFixedAmount(Customer customer, decimal newLimit)
        {
            _customer = customer;
            _desiredOverdraftLimit = newLimit;
        }
        public Customer GetRequester()
        {
            throw new NotImplementedException();
        }

        public decimal GetRequestOverdraftLimit()
        {
            throw new NotImplementedException();
        }
    }
}
