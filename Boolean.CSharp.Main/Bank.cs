using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Account;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;


namespace Main
{
    public class Bank
    {
        private List<Account> bankAccounts = new List<Account>();
        private string _bankName;
        public Bank(string name) {
            _bankName = name;
        
        }
        /// <summary>
        /// creates an account of the given user and adds it to List of accounts
        /// </summary>
        /// <param name="user"></param>
        public void CreateAccount(User user)
        {
            Account newAccount = new (user.firstName, user.lastName, user.phoneNumber, user.balance, user.accountType);
            if (!bankAccounts.Contains(newAccount) ) {
                bankAccounts.Add(newAccount);
            
            }
            
        }
        /// <summary>
        /// checks if the account exists and then checks the typoe of transactiona and make the right functionality
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="user"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public string MakeTransaction(Transaction transaction,User user,Account account)
        {
            if (bankAccounts.Contains(account))
            {

                if (transaction.TransactionType == TransactionType.Debit && transaction.transactionAmount <= account.balance)
                {
                    transaction.transactionTime.ToString("d/M/yyyy");
                    user.balance -= transaction.transactionAmount;
                    transaction.newBalance = user.balance;
                    user.transactions.Add(transaction);
                    return "Witdhawal completed succesfully";
                }
                else if (transaction.TransactionType == TransactionType.Credit)
                {
                    transaction.transactionTime.ToString("d/M/yyyy");


                    user.balance += transaction.transactionAmount;
                    transaction.newBalance = user.balance;
                    user.transactions.Add(transaction);
                    return "Desposit completed succesfully";

                }
                else { return "Transaction Failed"; }
            }
            else { return "Account doesnt exist"; }

        }



        public List<Account> BankAccounts { get { return bankAccounts; } }

    }
}
