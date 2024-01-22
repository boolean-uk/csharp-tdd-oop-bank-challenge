using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main.Objects
{
    public class BankStatement
    {
        private int _id;
        private List<ITransaction> _transactions = new List<ITransaction>();

        public BankStatement()
        {
        }
        public int Id { get { return _id; } set { _id = value; } }
        public List<ITransaction> Transactions { get { return _transactions; } set { _transactions = value; } }

        public void PrintBankStatement()
        {
            Console.WriteLine("date     || credit  || debit  || balance");
            foreach (var transaction in _transactions)
            {              
                Console.WriteLine($"{transaction.Date} || {transaction.Amount} || {transaction.OldBalance}");
            }
        }

    }
}
