using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using NUnit.Framework.Constraints;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account(string name, Branch branch = Branch.Trondheim, string bankSecret = "")
    {
        private string _bankSecret = bankSecret;
        private List<AccountTransaction> _transactions = [];
        public List<AccountTransaction> Transactions { get { return _transactions.ToList(); } }
        public string Name { get; set; } = name;
        public Branch Branch { get; } = branch;
        public Guid AccountId { get; } = Guid.NewGuid();
        public double Balance { get { return _transactions.Sum(x => x.Amount); } }
        public void WriteStatement(IStatementWriter writer) { writer.WriteStatement(_transactions); }
        protected void AddTransaction(AccountTransaction transaction) { _transactions.Add(transaction); }
        public bool AddTransaction(AccountTransaction transaction, string secret)
        {
            if (secret == _bankSecret) {AddTransaction(transaction); return true; }
            return false;
        }
        public abstract AccountTransaction Deposit(double amount);

        public abstract AccountTransaction Withdraw(double amount);

    }
}
