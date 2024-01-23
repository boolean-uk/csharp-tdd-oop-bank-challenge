using Boolean.CSharp.Main.TransactionManagement;
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
    }
}
