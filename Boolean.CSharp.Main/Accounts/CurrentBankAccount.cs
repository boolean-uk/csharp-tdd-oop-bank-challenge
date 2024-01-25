using Boolean.CSharp.Main.TransactionManagement;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentBankAccount : BankAccount
    {
        public CurrentBankAccount() : base(new SimpleTransactionManager())
        {
        }

        public void ApplyOverdraftTransaction(ITransaction transaction)
        {
            try { ApplyTransaction(transaction); }
            catch { ApplyTransaction(new OverdraftTransaction(transaction)); }
        }
    }
}
