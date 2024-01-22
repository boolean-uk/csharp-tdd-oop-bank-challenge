using Boolean.CSharp.Main.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public class Account : IAccount
    {
        //Public values
        public string Name { get { return _name; } }
        public double Balance { get { return _balance; } }
        public List<Transaction> Transactions { get { return _transactions; } }
        public AccountType AType { get { return _type; } }
        public Branch Branch { get { return _branch; } }

        //Encapsulated values
        private string _name;
        private double _balance = 0d;
        public AccountType _type;
        public Branch _branch;
        private readonly List<Transaction> _transactions = [];

        public Account(AccountType type, Branch branch, string name)
        {
            _type = type;
            _branch = branch;
            _name = name;
        }

        public double getBalance()
        {
            throw new NotImplementedException();
        }

        public bool makeTransaction()
        {
            throw new NotImplementedException();
        }

        public void PrintStatements()
        {
            throw new NotImplementedException();
        }
    }
}
