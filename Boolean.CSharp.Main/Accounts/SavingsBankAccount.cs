using Boolean.CSharp.Main.TransactionManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsBankAccount : BankAccount
    {
        public SavingsBankAccount() : base(new SimpleTransactionManager())
        {
        }
    }
}
