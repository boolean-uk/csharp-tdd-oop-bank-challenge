using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface Iaccount
    {

        public decimal CalculateBalance();
        public void Deposit(decimal amount);




        public string GenerateBankStatements();

        public void Withdraw(decimal amount);
        public Request RequestOverdraft(decimal amount, string accountID);
        public string GetAccountID();

    }
}
