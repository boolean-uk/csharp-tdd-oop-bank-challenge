using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountTypes;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Transactions;


namespace Boolean.CSharp.Main
{
    public class Core
    {
        private List<IUser> _userList = new List<IUser>();

        #region CreateAccount()
        public void CreateUser(string name, string password, List<IAccount> AccountsList, List<OverdraftRequest> OverdraftRequests)
        {
            createUser(name, password, AccountsList, OverdraftRequests);
        }
        private void createUser(string name, string password, List<IAccount> AccountsList, List<OverdraftRequest> OverdraftRequests)
        {
            _userList.Add(new Customer(name, password, AccountsList, OverdraftRequests));
        }
        #endregion

        #region CreateBankAccount()
        public void CreateBankAccount(IUser user, AccountType type, BankBranchType branch)
        {
            createBankAccount(user, type, branch);
        }
        private void createBankAccount(IUser user, AccountType type, BankBranchType branch)
        {
            if (type == AccountType.Current)
            {
                user.AccountsList.Add(new CurrentAccount(type, branch, new List<Transaction>()));
            }
            else if (type == AccountType.Savings)
            {
                user.AccountsList.Add(new SavingsAccount(type, branch, new List<Transaction>()));
            }
        }
        #endregion

        #region DepositAmount()
        public void DepositAmount(IUser user, int amount, IAccount accountname)
        {
            depositAmount(user, amount, accountname);
        }
        private void depositAmount(IUser user, int amount, IAccount accountname)
        {
            foreach (IUser x in UserList)
            {
                if (x == user)
                {
                    foreach (IAccount a in user.AccountsList)
                    {
                        if (a == accountname)
                        {
                            if (a.Transactions.Count == 0)
                            {
                                int balance =+ amount;
                                accountname.Transactions.Add(new Transaction(TransactionType.Credit, DateTime.Now, amount, balance));
                            }
                            else if (a.Transactions.Count != 0)
                            {
                                int balance = accountname.Transactions.Last().Balance + amount;
                                accountname.Transactions.Add(new Transaction(TransactionType.Credit, DateTime.Now, amount, balance));
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region WithdrawAmount()
        public void WithdrawAmount(IUser user, int amount, IAccount accountname)
        {
            withdrawAmount(user, amount, accountname);
        }
        private void withdrawAmount(IUser user, int amount, IAccount accountname)
        {
            foreach (IUser x in UserList)
            {
                if (x == user)
                {
                    foreach (IAccount a in user.AccountsList)
                    {
                        if (a == accountname)
                        {
                            if (a.Transactions.Count == 0)
                            {
                                int balance =- amount;
                                accountname.Transactions.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, balance));
                            }
                            else if (a.Transactions.Count != 0)
                            {
                                if ((accountname.Transactions.Last().Balance - amount) > 0)
                                {
                                    int balance = accountname.Transactions.Last().Balance - amount;
                                    accountname.Transactions.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, balance));
                                } 
                                else if ((accountname.Transactions.Last().Balance - amount) < 0)
                                {
                                    int balance = accountname.Transactions.Last().Balance - amount;
                                    int overdraft = amount - accountname.Transactions.Last().Balance;
                                    var date = DateTime.Now;
                                    OverdraftRequest(user, accountname, date, amount, overdraft, balance);
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region BankStatement()
        public void BankStatement(IUser user, IAccount accountname)
        {
            foreach (IUser x in UserList)
            {
                if (x == user)
                {
                    foreach (IAccount a in user.AccountsList)
                    {
                        if (a == accountname)
                        {
                            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}", "Date", "Credit", "Debit", "Balance");
                            Console.WriteLine("----------------------------------------------------");
                            foreach (Transaction t in accountname.Transactions)
                            {
                                if (t.Type == TransactionType.Debit)
                                {
                                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}", $"{t.Date.ToShortDateString()}", "", $"{t.Amount}", $"{t.Balance}");
                                }
                                else if (t.Type == TransactionType.Credit)
                                {
                                    Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}", $"{t.Date.ToShortDateString()}", $"{t.Amount}", "", $"{t.Balance}");
                                }
                            }
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("{0,10}    {1,10}    {2,10}    {3,10}", "", "", "", $"{accountname.Transactions.Last().Balance}");
                        }
                    }
                }
            }
        }
        #endregion

        #region OverdraftRequest()
        public void OverdraftRequest(IUser user, IAccount accountname, DateTime date, int amount, int overdraft, int balance)
        {
            user.OverdraftRequests.Add(new OverdraftRequest(user, accountname, date, amount, overdraft, balance));
        }
        #endregion

        #region ApproveOverdraft()
        public void ApproveOverdraft(IUser user, int id)
        {
            var accountname = user.OverdraftRequests[id].Accountname;

            foreach (IUser x in UserList)
            {
                if (x == user)
                {
                    foreach (IAccount a in user.AccountsList)
                    {
                        if (a == accountname)
                        {
                            int balance = user.OverdraftRequests[id].Balance + user.OverdraftRequests[id].Overdraft;
                            accountname.Transactions.Add(new Transaction(TransactionType.Overdraft, DateTime.Now, user.OverdraftRequests[id].Overdraft, balance));
                            WithdrawAmount(user, user.OverdraftRequests[id].Amount, user.OverdraftRequests[id].Accountname);
                        }
                    }
                }
            }
        }
        #endregion

        public List<IUser> UserList { get { return _userList; } set { _userList = value; } }
    }
}
