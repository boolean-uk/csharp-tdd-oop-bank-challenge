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

        private int _balance { get; set; }

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

        #region CreateCurrentAccount()
        public void CreateCurrentAccount(IUser user)
        {
            createCurrentAccount(user);
        }
        private void createCurrentAccount(IUser user)
        {
            user.AccountsList.Add(CurrentAccount);
        }
        #endregion

        #region CreateSavingsAccount()
        public void CreateSavingsAccount(IUser user)
        {
            createSavingsAccount(user);
        }
        private void createSavingsAccount(IUser user)
        {
            user.AccountsList.Add(SavingsAccount);
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
                            accountname.Add(new Transaction(TransactionType.Credit, DateTime.Now, amount, _balance + amount));
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
                            accountname.Add(new Transaction(TransactionType.Debit, DateTime.Now, amount, _balance - amount));
                        }
                    }
                }
            }
        }
        #endregion

        #region GetBalance()
        public int GetBalance(IUser user, List<Transaction> accountname)
        { 
            return getBalance(user, accountname);
        }

        private int getBalance(IUser user, List<Transaction> accountname)
        {
            foreach (IUser x in UserList)
            {
                if (x == user)
                {
                    foreach (List<Transaction> a in user.AccountsList)
                    {
                        if (a == accountname)
                        { 
                            foreach (Transaction t in accountname)
                            {
                                if (t.Type == TransactionType.Credit)
                                {
                                    _balance += t.Amount;
                                }
                                else if (t.Type == TransactionType.Debit)
                                {
                                    _balance -= t.Amount;
                                }
                            }
                        }
                    }
                }
            }
            return _balance;
        }
        #endregion

        public List<IUser> UserList { get { return _userList; } set { _userList = value; } }
        public List<Transaction> CurrentAccount { get { return _currentAccount; } set { _currentAccount = value; } }
        public List<Transaction> SavingsAccount { get { return _savingsAccount; } set { _savingsAccount = value; } }

    }
}
