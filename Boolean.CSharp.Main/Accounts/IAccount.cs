using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public interface IAccount
    {
        public AccountType AType { get; }
        public Branch Branch { get; }
        public string Name { get; }
        public double getBalance();
        public bool makeTransaction();
        public void PrintStatements();
    }
}
