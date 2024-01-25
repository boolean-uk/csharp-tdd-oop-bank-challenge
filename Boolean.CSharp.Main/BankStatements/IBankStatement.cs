using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankStatements
{
    public interface IBankStatement
    {
        public BankAccount Account { get; set; }

        public string GenerateStatement();
    }
}
