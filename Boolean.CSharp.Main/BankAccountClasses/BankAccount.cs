using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccountClasses
{
    public class BankAccount
    {
        #region Properties
        private string _accountName;
        private int _customerID;
        private List<Transaction> _transactionHistory = new List<Transaction>();

        public string AccountName { get => _accountName; set => _accountName = value; }
        public int CustomerID { get => _customerID; }
        public List<Transaction> TransactionHistory { get => _transactionHistory; }
        #endregion

        public BankAccount(string accountName, int customerID)
        {
            _accountName = accountName;
            _customerID = customerID;
        }
    }
}
