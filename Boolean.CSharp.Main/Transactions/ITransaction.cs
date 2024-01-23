using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Accounts;

namespace Boolean.CSharp.Main.Transactions
{
    public interface ITransaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public void ApplyToAccount(BankAccount account);
        public decimal EffectOnBalance();
    }
}
