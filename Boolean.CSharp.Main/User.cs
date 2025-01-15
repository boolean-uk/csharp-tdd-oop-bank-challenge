using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Abstract;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class User
    {
        private Role _userRole;
        private Guid _userID = new Guid();
        private string _username;

        public User(Role userRole, string username)
        {
            _userRole = userRole;
            _username = username;
        }

        public CurrentAccount CreateCurrentAccount(string name)
        {
            CurrentAccount account = new CurrentAccount(_userID, name);
            BankData.Accounts.Add(account);
            return account;
        }

        public SavingsAccount CreateSavingsAccount(string name)
        {
            SavingsAccount account = new SavingsAccount(_userID, name);
            BankData.Accounts.Add(account);
            return account;
        }

        public string GenerateBankStatement()
        {
            string bankStatement = "";

            return bankStatement;
        }

        public void SendBankStatementToPhone(string number)
        {
            string bankStatement = GenerateBankStatement();
        }

        public Guid UserID { get { return _userID; } }
        public Role UserRole { get { return _userRole; } }
        public string Username { get { return _username; } }
    }
}
