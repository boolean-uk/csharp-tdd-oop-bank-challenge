using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Boolean.CSharp.Main.Classes
{
    public class RegularAccount : IAccount
    {
        public bool Create(string type, string name)
        {
            if (type == "Regular")
            {
                RegularAccount account = new RegularAccount(name,new List<Transaction>());
                return true;
            }
            return false;
        }


        public bool deposit(decimal amount, IAccount account)
        {
            DateOnly dayOfTransfer =DateOnly.FromDateTime(DateTime.Now);
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

        public decimal balance(IAccount account)
        {
            decimal sum = 0;

            foreach (var item in transactionList)
            {
                sum += item.amount;
            }
            return sum;
        }

        public Request requestOverdraft(IAccount account, string justficiation, decimal amount)
        {
            if ((account as RegularAccount)?.overdrafted == true)
            {
                return null;
            }
            else
            {
                Request request = new Request(justficiation,amount,account);
                return request;
            }
        }

        public void updateOverdraft(IAccount account, bool status, decimal toBeGiven)
        {
            if (status == true)
            {
                (account as RegularAccount).overdrafted = status;
                (account as RegularAccount).overdraftedAmount = toBeGiven;

            }

        }


        public string nameOfHolder { get; set; }

        private List<Transaction> _transactionList = new List<Transaction>();


        public RegularAccount() { }
        public RegularAccount(string nameOfHolder, List<Transaction> transactionList)
        {
            this.nameOfHolder = nameOfHolder;
            _transactionList = transactionList;
        }

        public List<Transaction> transactionList { get { return _transactionList; } }

        public bool overdrafted { get; set; }

        private decimal _defuaultRent = 0;
        decimal rent { get { return _defuaultRent; } set { value = _defuaultRent; } }

        public decimal overdraftedAmount { get; set; }

    }
}
