using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class User : IAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool SavingsAccount { get; set; } = false;

        public User(string Username, string Password, bool SavingsAccount)
        {
            this.Username = Username;
            this.Password = Password;
            this.SavingsAccount = SavingsAccount;
        }
    }
}