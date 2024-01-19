using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Accounts
{
    public abstract class Account : IAccount
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Balance { get { return _balance; } }

        public List<BankStatement> BankStatements { get { return _bankStatements; } }

        private double _balance = 100d;
        private readonly List<BankStatement> _bankStatements = [];

        public void Deposit(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            _balance += amount;
            GenerateBankStatements(amount);
        }

        public double Withdraw(double amount)
        {
            ArgumentOutOfRangeException.ThrowIfNegative(amount);
            if (amount > _balance)
            {
                throw new Exception("Can't withdraw more than the current balance!");
            }
            _balance -= amount;
            GenerateBankStatements(-amount);
            return amount;
        }

        public void GenerateBankStatements(double amount)
        {
            BankStatement bankStatement = new(_balance, amount);
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
