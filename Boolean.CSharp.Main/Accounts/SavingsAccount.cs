using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class SavingsAccount : BankAccount
    {
        // No need to implement here, as it is inherited from BankAccount
        public void GenerateInterest()
        {
            throw new NotImplementedException();
        }

        public object? GetBalanceWithInterest()
        {
            throw new NotImplementedException();
        }
    }
}
