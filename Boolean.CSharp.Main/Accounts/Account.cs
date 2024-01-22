using Boolean.CSharp.Main.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        public string Name { get; }
        public double Balance { get { return _bankStatements.Last().Balance; } }

        public List<BankStatement> BankStatements { get { return _bankStatements; } }

        public IBranch Branch { get; }

        private readonly List<BankStatement> _bankStatements = [];

        public Account(IBranch branch, string name)
        {
            Branch = branch;
            Name = name;
        }

        public void Deposit(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            GenerateBankStatements(amount);
        }

        public double Withdraw(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            if (amount > Balance)
            {
                throw new Exception("Can't withdraw more than the current balance!");
            }
            GenerateBankStatements(-amount);
            return amount;
        }

        public void GenerateBankStatements(double amount)
        {
            double balance = _bankStatements.Count == 0 ? 0 : Balance;
            BankStatement bankStatement = new(balance, amount);
            _bankStatements.Add(bankStatement);
        }

        public void PrintBankStatements()
        {
            var statements = _bankStatements;
            statements.Sort((a, b) => a.Date.CompareTo(b.Date));
            Console.WriteLine("{0,10}{1,10}{2,10}{3,10}",
                "Date", "Credit", "Debit", "Balance");
            foreach (var statement in statements)
            {
                Console.WriteLine("{0,10}{1,10}{2,10}{3,10}",
                    $"{statement.Date:dd/MM/yyyy}", 
                    $"{statement.Credit:0.00}", 
                    $"{statement.Debit:0.00}", 
                    $"{statement.Balance:0.00}");
            }
        }
    }
}
