using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Enums;

namespace Boolean.CSharp.Main
{
    public class User
    {
        private Role _userRole;
        private string _username;

        public User(Role userRole, string username)
        {
            _userRole = userRole;
            _username = username;
        }

        public void CreateCurrentAccount(string name)
        {

        }

        public void CreateSavingsAccount(string name)
        {

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

        public Role UserRole { get { return _userRole; } }
        public string Username { get { return _username; } }
    }
}
