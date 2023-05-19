using Boolean.CSharp.Main.CustomerAccounts;
using Boolean.CSharp.Main.EngineerAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Engineer : User, iEngineerAccount
    {
        public Engineer(string name, string surname, string email, EngineerAccount.EngineerCurrentAccount account1, EngineerAccount.EngineerSavingsAccount account2)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.account1 = (EngineerCurrentAccount)account1;
            this.account2 = (EngineerSavingsAccount)account2;
        }

        public EngineerAccount.EngineerAccount account1 { get ; set ; }
        public EngineerAccount.EngineerAccount account2 { get ; set ; }
    }
}
