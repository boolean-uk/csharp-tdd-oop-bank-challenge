using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public string OwnerName { get; set; }
        public Roles OwnerRole { get; set; }
        public Branches Branch { get; set; } = Branches.Oslo;
        public double Balance { get; set; } = 0;

        public struct Transaction 
        {
            public DateTime Date { get; set; }
            public double Amount { get; set; }
            public double CurrentBalance { get; set; }

            public Transaction() { }

            public Transaction(DateTime date, double amount, double balance) 
            {
                Date = date;
                Amount = amount;
                CurrentBalance = balance;
            }

        }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();


        public Account(string accountnumber, string name, Roles role) 
        { 
            AccountNumber = accountnumber;
            OwnerName = name;
            OwnerRole = role;
        }

        public double GetBalance()
        {
            if (OwnerRole == Roles.Engineer)
            {
                return Transactions.Sum(t => t.Amount);
            }
            return Balance;
        }

        public void Deposit(double amount) 
        {
            Balance += amount;

            DateTime date = DateTime.Today;
            Transaction deposit = new Transaction(date, amount, Balance);
            Transactions.Add(deposit);  
        }

        public abstract void Withdraw(double amount, bool overdraftApproval);

        public void PrintBankStatement() 
        {
            const int aligned = -10;
            
            Console.WriteLine($"-----Bank Statement - {OwnerName} - {DateTime.Today.ToString("dd/MM/yyyy")}-----");
            Console.WriteLine($"{"Date",aligned} || {"Credit",aligned}|| {"Debit",aligned}|| {"Balance",aligned}");

            foreach ( Transaction transaction in Transactions)
            {
                string debit = "", credit = "";

                if (transaction.Amount < 0) { debit = Math.Abs(transaction.Amount).ToString(); }
                else { credit = Math.Abs(transaction.Amount).ToString(); }

                Console.WriteLine($"{transaction.Date.ToString("dd/MM/yyyy"),aligned} || {credit ,aligned}|| {debit, aligned}|| {transaction.CurrentBalance,aligned}");
            }
        }
    }

}
