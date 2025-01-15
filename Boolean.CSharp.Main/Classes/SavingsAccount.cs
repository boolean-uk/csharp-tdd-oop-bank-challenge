using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Fax;


namespace Boolean.CSharp.Main.Classes
{


    public class SavingsAccount : IAccount
    {

        Statement statement = new Statement();


        public bool Create(string type, string name)
        {
            if (type == "Savings")
            {
                SavingsAccount account = new SavingsAccount(new List<Transaction>());
                account.AccountHolderName = name;
                account.overdrafted = false;
                account.overdraftedAmount = 0;
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
                account.transactionList.Add(transaction);
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
                account.transactionList.Add(transaction);
                return true;
            }
            return false;
        }

        public decimal balance(string receiver)
        {
            SavingsAccount account1 = Bank.accounts?.OfType<SavingsAccount>().FirstOrDefault(x => x.AccountHolderName == receiver);

            if (account1 == null)
            {
                Console.WriteLine("Account not found for receiver: " + receiver);
                return 0;
            }

            return account1.transactionList
            .Sum(item => item.type.Equals("Withdraw", StringComparison.OrdinalIgnoreCase) ? -item.amount : item.amount);
        }



        public bool RequestOverdraft(string name, string justification, decimal amount)
        {
            var account = Bank.accounts?.OfType<SavingsAccount>().FirstOrDefault(x => x.AccountHolderName == name);
            if (account == null || account.overdrafted)
            {
                return false;
            }

            var request = new Request(justification, amount, name);
            Bank.requestQueue.Add(request);
            return true;
        }







        public SavingsAccount() { }
        public SavingsAccount(List<Transaction> transactionList)
        {

            _transactionList = transactionList;
        }

        private List<Transaction> _transactionList = new List<Transaction>();
        public List<Transaction> transactionList
        {
            get { return _transactionList; }
            set { _transactionList = value; }
        }

        public bool overdrafted { get; set; }

        private decimal _defuaultRent = 1.25m;

        private string _AccountHolderName;
        public string AccountHolderName { get { return _AccountHolderName; } set { _AccountHolderName = value; } }
        decimal rent { get { return _defuaultRent; } set { value = _defuaultRent; } }

        public decimal overdraftedAmount { get; set; }

    }
}
