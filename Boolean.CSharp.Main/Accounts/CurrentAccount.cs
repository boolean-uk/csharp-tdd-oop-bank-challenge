using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Accounts
{
    public class CurrentAccount : BankAccount
    {

        public CurrentAccount() : base() { }

        public override string GenerateStatement()
        {
            throw new NotImplementedException();
        }
    }
}
