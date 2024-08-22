using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class SavingsAccount : IAccount
    {
        public bool Create(string type,string name)
        {
            if (type == "Savings")
            {
                SavingsAccount savingsAccount = new SavingsAccount(name, new List<Transaction>());
                savingsAccount.rent = rent;
                savingsAccount.overdrafted = false;
                savingsAccount.overdraftedAmount = 0;
                return true;
            }
            return false;
        }

        public bool deposit(decimal amount, IAccount account)
        {
            DateOnly dayOfTransfer = DateOnly.FromDateTime(DateTime.Now);
            if (amount > 0 && account != null)
            {
                Transaction transaction = new Transaction(account, amount, dayOfTransfer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool withdraw(decimal amount, IAccount account)
        {
            DateOnly dayOfTransfer = DateOnly.FromDateTime(DateTime.Now);
            if (amount < 0 && account != null)
            {
                Transaction transaction = new Transaction(account, amount, dayOfTransfer);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Transaction> transactionList = new List<Transaction>();

        public SavingsAccount(string nameOfHolder, List<Transaction> transactionList)
        {
            this.nameOfHolder = nameOfHolder;
            this.transactionList = transactionList;
        }

        public SavingsAccount() { }
        public string nameOfHolder {  get; set; }

        public bool overdrafted {  get; set; }

        private decimal _defuaultRent = 1.25m;
        decimal rent { get { return _defuaultRent; } set { value = _defuaultRent; } }

        public decimal overdraftedAmount { get; set; }
    }
}
