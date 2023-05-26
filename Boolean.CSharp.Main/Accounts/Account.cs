using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account
    {
        public string _CustomerName { get; set; }
        public decimal _balance { get; set; } = 0;
        public List<Transaction> transactions = new List<Transaction>();
        public BranceType _branceType { get; set; }
        public Role role { get; set; } = Role.customer;
    }
}
