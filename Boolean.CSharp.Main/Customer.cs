using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Interfaces;

namespace Boolean.CSharp.Main
{
    public class Customer : IUser
    {   
        public string Username { get; set; }
        public string Password { get; set; }
        public List<IAccount> AccountList { get; set; } = new List<IAccount>();

        

        public Customer(string Username, string Password, List<IAccount> AccountList)
        {
            this.Username = Username;
            this.Password = Password;
            this.AccountList = AccountList;
        }
    }
    
}
