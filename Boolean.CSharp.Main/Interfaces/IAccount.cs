using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Interfaces
{
    public interface IAccount
    {
        public AccountType AccountType { get; set; }
        public BankBranchType BranchType { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
