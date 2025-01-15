using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface Iaccount
    {
        public void Deposit(decimal amount);
        public void Withdraw(decimal amount);
        public decimal CalculateBalance();
        public string GenerateBankStatements();
    }
}
