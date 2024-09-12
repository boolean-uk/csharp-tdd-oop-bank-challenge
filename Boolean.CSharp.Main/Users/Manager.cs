using Boolean.CSharp.Main.CustomerAccounts;
using Boolean.CSharp.Main.ManagerAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Manager : User, iManagerAccount
    {
        public Manager(string name, string surname, string email, ManagerCurrentAccount account1, ManagerSavingsAccount account2)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.account1 = account1;
            this.account2 = account2;
        }

        public ManagerAccount.ManagerAccount account1 { get; set; }
        public ManagerAccount.ManagerAccount account2 { get; set; }
    }
}
