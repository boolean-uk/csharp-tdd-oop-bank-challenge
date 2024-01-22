﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
//using Boolean.CSharp.Main;


namespace Boolean.CSharp.Main
{
    public abstract class Account
    {
       
        public List<Transaction> Transactions { get; } = new List<Transaction>();
        public string branch { get; protected set; }
        public bool overdraft { get; protected set; }

        public Account()
        {
            this.branch=string.Empty;
        }

        public bool Deposit(decimal amount)
        {
            if (amount >= 0)
            {
                Transactions.Add(new Transaction(DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss"), amount, 0));
                return true;
            }
            else { return false; }
        }

        public virtual bool Withdraw(decimal amount)
        {
            
                if (amount >= 0 || amount > this.GetBalance())

                {

                    Transactions.Add(new Transaction(DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss"), 0, amount));
                    return true;
                }
                else if (this.overdraft == true)
                {
                    Transactions.Add(new Transaction(DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss"), 0, amount));
                    return true;
                }
                else
                { 
                    return false; 
                }
                
        }


        public string GenerateStatement()
        {
            StringBuilder statementBuilder = new StringBuilder();
            decimal currentBalance = 0;

            foreach (var transaction in Transactions)
            {
                currentBalance += transaction.Credit - transaction.Debit;

                statementBuilder.AppendLine($"Transaction Date: {transaction.Date}");
                statementBuilder.AppendLine($"Credit: {transaction.Credit}");
                statementBuilder.AppendLine($"Debit: {transaction.Debit}");
                statementBuilder.AppendLine($"Balance at the time of transaction: {currentBalance}");
                statementBuilder.AppendLine();
            }
            return statementBuilder.ToString();
        }


        public decimal GetBalance()
        {
            decimal balance = 0;

            foreach (var transaction in Transactions)
            {
                balance += transaction.Credit - transaction.Debit;
            }

            return balance;
        }



        //Extension
        public bool setBranch(string Branch)
        {
            if (Branch == "")
            {
                return false;
            }
            else 
            {
                this.branch = Branch; 
                return true; 
            }
        }


        public bool requestOverdraft(decimal amount)
        {
            return true;
        }

        public string denieOverdraft(decimal amount)
        {
            if (this.requestOverdraft(amount) == true)
            {
                return "denied";
            }
            else { return ""; }

        }

        public string approveOverdraft(decimal amount)
        {
            if (this.requestOverdraft(amount) == true)
            {
                this.overdraft = true;
                Transactions.Add(new Transaction(DateTime.Today.Date.ToString("dd-MM-yyyy HH:mm:ss"), 0, amount));
                return "approved";
            }
            else { return ""; }
        }

        public void sendToPhone(string phoneNumber)
        {
            if (phoneNumber.Length == 8) //length of Danish phone Numbers
            {
                Console.WriteLine(this.GenerateStatement());
            }

        }
    }


}
