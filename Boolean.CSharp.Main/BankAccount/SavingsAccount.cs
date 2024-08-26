using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccount
{
    public class SavingsAccount : IBankAccount
    {
        #region Properties
        private string _accountName;
        private AccountType _accountType;
        private List<Transaction> _transactionHistory = new List<Transaction>();

        public string AccountName { get => _accountName; set => _accountName = value; }
        public AccountType AccountType { get => _accountType; }
        public List<Transaction> TransactionHistory { get => _transactionHistory; }
        #endregion

        public SavingsAccount (string accountName, AccountType accountType) 
        {
            _accountName = accountName;
            _accountType = accountType;
        }
    }
}
