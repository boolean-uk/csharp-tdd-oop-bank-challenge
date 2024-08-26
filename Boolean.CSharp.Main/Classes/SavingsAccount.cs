using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class SavingsAccount :  IAccount
    {

         Statement statement = new Statement();
        public bool Create(string type, string name)
        {
            if (type == "Savings")
            {
                SavingsAccount account = new SavingsAccount(new List<Transaction>());
                account.AccountHolderName = name;
                Bank.accounts.Add(account);
                return true;
            }
            return false;
        }

        public bool deposit(decimal amount, string Receiver)
        {
            DateOnly dayOfTransfer = DateOnly.FromDateTime(DateTime.Now);
            SavingsAccount account = Bank.accounts.OfType<SavingsAccount>().FirstOrDefault(x => x.AccountHolderName == Receiver);
            string receipt;
            string type = "Deposit";

            if (amount > 0 && account != null)
            {
                Transaction transaction = new Transaction(account, amount, dayOfTransfer, type);
                transactionList.Add(transaction);
                return true;
            }
            else
            {

                return false;
            }
        }

        public bool withdraw(decimal amount, string receiver)
        {
            DateOnly dayOfTransfer = DateOnly.FromDateTime(DateTime.Now);
            string type = "Withdraw";
            decimal currentBalance = balance(receiver);


            SavingsAccount account = Bank.accounts.OfType<SavingsAccount>()
                .FirstOrDefault(x => x.AccountHolderName == receiver);


            if (amount > 0 && account != null && currentBalance >= amount)
            {
                // Create and add the transaction
                Transaction transaction = new Transaction(account, amount, dayOfTransfer, type);
                transactionList.Add(transaction);
                return true;
            }
            return false;
        }

        public decimal balance(String Receiver)
        {
            decimal sum = 0;

            foreach (var item in transactionList)
            {
                if (item.type == "Withdraw")
                {
                    sum -= item.amount;
                }
                else if (item.type == "Deposit")
                {
                    sum += item.amount;
                }
            }
            return sum;
        }


        private List<Transaction> _transactionList = new List<Transaction>();


        public List<Transaction> transactionList { get { return _transactionList; } set { _transactionList = value; } }

        public SavingsAccount(List<Transaction> transactionList)
        {
            this.transactionList = transactionList;
        }

        public SavingsAccount() { }
        private string _AccountHolderName;
        public string AccountHolderName { get { return _AccountHolderName; } set { _AccountHolderName = value; } }

        public bool overdrafted {  get; set; }

        private decimal _defuaultRent = 1.25m;
        decimal rent { get { return _defuaultRent; } set { value = _defuaultRent; } }

        public decimal overdraftedAmount { get; set; }
    }
}
