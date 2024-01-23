using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Transactions
{
    public class CreditTransaction : ITransaction
    {
        public decimal Amount => throw new NotImplementedException();

        public DateTime Date => throw new NotImplementedException();

        public void ApplyToAccount(BankAccount account)
        {
            throw new NotImplementedException();
        }

        public decimal EffectOnBalance()
        {
            throw new NotImplementedException();
        }
    }
}
