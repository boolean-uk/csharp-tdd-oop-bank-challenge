using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CurrentAccount : IAccount
    {
        private readonly List<ITransaction> _transactions = new List<ITransaction>();
        private decimal _balance {  get; set; }
        public CurrentAccount()
        {
            AccountNumber = Guid.NewGuid().ToString();
        }
        public void Deposit(decimal amount)
        {
            _balance += amount;
            _transactions.Add(new Transaction(amount, "Deposit", _balance));
        }


        public void Withdraw(decimal amount)
        {
            _balance -= amount;
            _transactions.Add(new Transaction(amount, "Withdrawal", _balance));
        }

        public List<ITransaction> GetTransactions()
        {
            return _transactions;
        }
        public string GenerateStatement()
        {
            _transactions.Reverse();
            string statement = "date       || credit  || debit  || balance\n";
            foreach (var transaction in _transactions)
            {
                string credit = transaction.Type == "Deposit" ? transaction.Amount.ToString("0.00") : "";
                string debit = transaction.Type == "Withdrawal" ? transaction.Amount.ToString("0.00") : "";
                statement += $"{transaction.TransactionDate:dd/MM/yyyy} || {credit} || {debit} || {transaction.BalanceAfterTransaction:0.00}\n";
            }
            return statement;
        }

       public decimal Balance {  get {  return _balance; } }
        

        

        public List<ITransaction> Transactions { get => _transactions; }
        public string AccountNumber { get; set; }


    }
}
