using Boolean.CSharp.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Core
    {
        private List<IUser> _userList = new List<IUser>();
        private List<Transaction> _currentAccount = new List<Transaction>();
        private List<Transaction> _savingsAccount = new List<Transaction>();

        #region CreateAccount()
        public void CreateUser(string name, string password, List<List<Transaction>> AccountsList)
        {
            createUser(name, password, AccountsList);
        }
        private void createUser(string name, string password, List<List<Transaction>> AccountsList)
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
                user.AccountsList.Add(CurrentAccount);
            }
            else if (type == AccountType.Savings)
            {
                user.AccountsList.Add(SavingsAccount);
            }
        }
        #endregion

        #region DepositAmount()
        public void DepositAmount(IUser user, int amount, List<Transaction> accountname)
        {
            depositAmount(user, amount, accountname);
        }
        private void depositAmount(IUser user, int amount, List<Transaction> accountname)
        {
            foreach (IUser x in UserList)
            {
                if (x == user)
                {
                    foreach (List<Transaction> a in user.AccountsList)
                    {
                        if (a == accountname)
                        {
                            if (a.Count == 0)
                            {
                                var balance =+ amount;
                                accountname.Add(new Transaction(TransactionType.Credit, DateTime.Now, amount, balance));
                            }
                            else if (a.Count != 0)
                            {
                                var balance = accountname.Last().Balance + amount;
                                accountname.Add(new Transaction(TransactionType.Credit, DateTime.Now, amount, balance));
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region WithdrawAmount()
        public void WithdrawAmount(IUser user, int amount, List<Transaction> accountname)
        {
            withdrawAmount(user, amount, accountname);
        }
        private void withdrawAmount(IUser user, int amount, List<Transaction> accountname)
        {
            foreach (IUser x in UserList)
            {
                if (x == user)
                {
                    foreach (List<Transaction> a in user.AccountsList)
                    {
                        if (a == accountname)
                        {
                            if (a.Count == 0)
                            {
                                var balance =- amount;
                                accountname.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, balance));
                            }
                            else if (a.Count != 0)
                            {
                                var balance = accountname.Last().Balance - amount;
                                accountname.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, balance));
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region BankStatement()
        public void BankStatement(IUser user, List<Transaction> accountname)
        {
            foreach (IUser x in UserList)
            {
                if (x == user)
                {
                    foreach (List<Transaction> a in user.AccountsList)
                    {
                        if (a == accountname)
                        {
                            Console.WriteLine("{0,10} || {1,10} || {2,10} || {3,10}", "Date", "Credit", "Debit", "Balance");
                            Console.WriteLine("----------------------------------------------------");
                            foreach (Transaction t in accountname)
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
                            Console.WriteLine("{0,10}    {1,10}    {2,10}    {3,10}", "", "", "", $"{accountname.Last().Balance}");
                        }
                    }
                }
            }
        }
        #endregion

        public List<IUser> UserList { get { return _userList; } set { _userList = value; } }
        public List<Transaction> CurrentAccount { get { return _currentAccount; } set { _currentAccount = value; } }
        public List<Transaction> SavingsAccount { get { return _savingsAccount; } set { _savingsAccount = value; } }

    }
}
