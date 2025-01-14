using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;
using NUnit.Framework.Constraints;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account(string name, Branch branch = Branch.Trondheim)
    {
        private List<AccountTransaction> _transactions;
        public string Name { get; set; } = name;
        public Branch Branch { get; } = branch;
        public Guid AccountId { get; } = new Guid();
        public string Statement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public double Balance { get { throw new NotImplementedException(); } }
        public abstract AccountTransaction Deposit(double amount);

        public abstract AccountTransaction Withdraw(double amount);

    }
}
