using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public interface Iaccount
    {
        public void Deposit();
        public void Withdraw();
        public void CalculateBalance();
        public string GenerateBankStatements();
    }
}
