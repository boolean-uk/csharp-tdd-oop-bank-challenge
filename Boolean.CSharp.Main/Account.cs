using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Account : Iaccount
    {

        public List<Transaction> history = new List<Transaction>();
        public List<Request> requests { get; set; } = new List<Request>();
        public Person owner { get; set; }
        public string accountID { get; set; } = ""; //only unique within one person ssn. ID is going to be current or savings
        public decimal overdraft { get; set; } = 0;
        public Account(string accountName, Person Owner) 
        {
            accountID = accountName;
            owner = Owner;

        }
 
        public decimal CalculateBalance()
        {
            decimal balance = 0;
            foreach (Transaction transaction in history)
            {
                if (transaction.type == "Deposit")
                {
                    balance += transaction.amount;
                }
                else if (transaction.type == "Withdraw")
                {
                    balance -= transaction.amount;
                }
            }
            return balance;
        }

        public void Deposit(decimal amount)
        {
            Transaction transaction = new Transaction("Deposit", amount);
            history.Add(transaction);
        }




        public string GenerateBankStatements()
        {
            decimal balance = 0;
            Console.WriteLine("date                || credit             || debit                || balance                 ||");
            history.ForEach(transaction =>
            {
                if (transaction.type == "Withdraw")
                {
                    balance -= transaction.amount;
                    Console.WriteLine($"{DateTime.Now} ||                    || {transaction.amount}                     ||{balance}             ||");
                }
                else if (transaction.type == "Deposit")
                {
                    balance += transaction.amount;
                    Console.WriteLine($"{DateTime.Now} ||{transaction.amount}                    ||                      ||{balance}             ||");
                }
            });
             return "";
        }



        public void Withdraw(decimal amount)
        {
            //fetch the overdraft requests
            owner.GetRequestResponse();
            if ((CalculateBalance() + overdraft) >= amount)
            {
                Transaction transaction = new Transaction("Withdraw", amount);
                history.Add(transaction);
            }

        }
        public Request RequestOverdraft(decimal amount, string accountID)
        {
            Request request = new Request("Overdraft", amount, owner.ssn ,accountID);
            requests.Add(request);
            return request;
            

        }

        public string GetAccountID()
        {
            return accountID;
        }
    }
}
