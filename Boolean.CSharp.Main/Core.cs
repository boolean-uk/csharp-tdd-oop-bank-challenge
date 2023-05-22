using Boolean.CSharp.Main;
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
        public void CreateUser(string name, string password, List<IAccount> AccountsList)
        {
            createUser(name, password, AccountsList);
        }
        private void createUser(string name, string password, List<IAccount> AccountsList)
        {
            _userList.Add(new Customer(name, password, AccountsList));
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
                                var balance =+ amount;
                                accountname.Transactions.Add(new Transaction(TransactionType.Credit, DateTime.Now, amount, balance));
                            }
                            else if (a.Transactions.Count != 0)
                            {
                                var balance = accountname.Transactions.Last().Balance + amount;
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
                                var balance =- amount;
                                accountname.Transactions.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, balance));
                            }
                            else if (a.Transactions.Count != 0)
                            {
                                var balance = accountname.Transactions.Last().Balance - amount;
                                accountname.Transactions.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, balance));
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

        public List<IUser> UserList { get { return _userList; } set { _userList = value; } }
    }
}
