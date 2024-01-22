using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankStatement
    {
        private List<Transaction> _transactions;

        public BankStatement(List<Transaction> transactions)
        {
            _transactions = transactions;
        }   

        public List<Transaction> Transactions { get { return _transactions; } set { _transactions = value; } }

        public void PrintBankStatement()
        {
            Console.WriteLine("date     || credit  || debit  || balance");
            foreach( var transaction in _transactions)
            {
                Console.WriteLine($"{transaction.TransactionDate} || {transaction.Amount} || {transaction.Balance}");
            }
        }

    }
}
