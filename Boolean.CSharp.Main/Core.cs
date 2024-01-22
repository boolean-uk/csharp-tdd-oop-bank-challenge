using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Boolean.CSharp.Main.Interfaces;


namespace Boolean.CSharp.Main
{
    public class Core
    {
        public List<IUser> userList = new List<IUser>();

        

        public void CreateUser(string name, string password, List<IAccount> AccountsList)
        {
            createUser(name, password, AccountsList);
        }
        private void createUser(string name, string password, List<IAccount> AccountsList)
        {
            userList.Add(new Customer(name, password, AccountsList));
        }
        public void creatBankAcc(IUser user, AccountType type)
        {
            if (type == AccountType.Current)
            {
                user.AccountList.Add(new CurrentAcc(type, new List<Transaction>()));
            }
            if (type == AccountType.Saving)
            {
                user.AccountList.Add(new SavingAcc(type, new List<Transaction>()));
            }
        }

        public void CreateUserAcc(string name, string password, List<IAccount> AccountList)
        {
            createUserAcc(name,password,AccountList);
        }

        private void createUserAcc(string name, string password, List<IAccount> accountList)
        {
            userList.Add(new Customer(name, password, accountList));
        }

        public void BankStatement(IUser user, IAccount account)
        {
            foreach (IUser x in userList)
            {
                if (x == user)
                {
                    foreach (IAccount y in user.AccountList)
                    {
                        if(y == account)
                        {
                            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}", "Date", "Credit", "Debit", "Balance");
                            foreach(Transaction t in account.Transactions)
                                if (t.TransactionType == TransactionType.Debit)
                                {
                                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}", $"{t.DateTime.ToShortDateString()}", "", $"{t.Amount}", $"{t.Balance}");
                                }
                            else if(t.TransactionType == TransactionType.Credit) {
                                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}", $"{t.DateTime.ToShortDateString()}", $"{t.Amount}", "", $"{t.Balance}");
                                }
                            Console.WriteLine("{0,10}    {1,10}    {2,10}    {3,10}", "", "", "", $"{account.Transactions.Last().Balance}");
                        }
                        

                    }
                }
            }
        }

        public void DepositAmount(IUser user, int amount, IAccount accountname)
        {
            depositAmount(user, amount, accountname);
        }
        public void depositAmount(IUser user, int amount, IAccount account)
        {
            foreach(IUser x in userList)
            {
                if(x == user) { 
                    foreach (IAccount y in user.AccountList) { if(y == account)
                            if (y.Transactions.Count == 0) {

                                int balance = +amount;
                                account.Transactions.Add(new Transaction(TransactionType.Credit, DateTime.Now, amount, balance));
                            }
                    else if (y.Transactions.Count != 0)
                            {
                                int balance =account.Transactions.Last().Balance + amount;
                                account.Transactions.Add(new Transaction(TransactionType.Credit, DateTime.Now, amount, balance));
                            }
                    }
                }
            }

        }
        public void WithdrawAmount(IUser user, int amount, IAccount accountname)
        {
            withdrawAmount(user, amount, accountname);
        }
        public void withdrawAmount(IUser user, int amount, IAccount account)
        {
            foreach(IUser x in userList)
            {
                if (x == user) {
                    foreach(IAccount y in user.AccountList)
                    {
                        if(y == account)
                        {
                            if (y.Transactions.Count == 0) { 
                                int balance = -amount;
                                account.Transactions.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, balance));
                            }
                            else if (y.Transactions.Count != 0)
                            {
                                if((account.Transactions.Last().Balance - amount)>0 )
                                {
                                    int balance = account.Transactions.Last().Balance - amount;
                                    account.Transactions.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, balance));
                                }
                                
                            }
                        }
                    }
                }
            }
        }

    }
}
