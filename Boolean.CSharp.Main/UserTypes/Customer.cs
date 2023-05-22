using Boolean.CSharp.Main.AccountTypes;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public List<IAccount> AccountsList { get; set; } = new List<IAccount>();
        public List<OverdraftRequest> OverdraftRequests { get; set; } = new List<OverdraftRequest>();


        public Customer(string Username, string Password, List<IAccount> AccountsList, List<OverdraftRequest> OverdraftRequests)
        {
            this.Username = Username;
            this.Password = Password;
            this.AccountsList = AccountsList;
            this.OverdraftRequests = OverdraftRequests;
        }
    }
}