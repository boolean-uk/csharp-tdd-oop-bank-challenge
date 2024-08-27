using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Boolean.CSharp.Main.BankAccountClasses
{
    public class BankAccount
    {
        #region Properties
        private string _accountName;
        private int _customerID;
        private List<Transaction> _transactionHistory = new List<Transaction>();
        private decimal _balance;
        private StringBuilder _bankStatement = new StringBuilder();

        public string AccountName { get => _accountName; set => _accountName = value; }
        public int CustomerID { get => _customerID; }
        public List<Transaction> TransactionHistory { get => _transactionHistory; }
        public decimal Balance { get => _balance; }
        public StringBuilder BankStatement { get; }
        #endregion

        public BankAccount(string accountName, int customerID)
        {
            _accountName = accountName;
            _customerID = customerID;
        }

        public void Deposit(Transaction transaction)
        {
            _transactionHistory.Add(transaction);
            BalanceUpdate();

            _bankStatement.AppendLine($"{transaction.ToString()}" + "||" + $"{_balance}".PadLeft(6));
        }

        public void Withdraw(Transaction transaction)
        {
            _transactionHistory.Add(transaction);
            BalanceUpdate();

            _bankStatement.AppendLine($"{transaction.ToString()}" + "||" + $"{_balance}".PadLeft(6));
        }

        public void BalanceUpdate()
        {
            foreach (var transaction in _transactionHistory)
            {
                if (transaction.TypeOfTransaction == TransactionType.Deposit & transaction.Checked == false)
                {
                    _balance += transaction.Amount;
                    transaction.Checked = true;
                } else if (transaction.TypeOfTransaction == TransactionType.Withdraw & transaction.Checked == false)
                {
                    _balance -= transaction.Amount;
                }
            }
        }

        public void PrintBankStatement()
        {
            Console.WriteLine($"date".PadRight(11) + "|| credit || debit || balance");

            Console.WriteLine(_bankStatement);
        }
    }
}
