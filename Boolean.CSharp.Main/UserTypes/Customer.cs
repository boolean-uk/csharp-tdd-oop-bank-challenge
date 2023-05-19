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
        public List<List<Transaction>> AccountsList { get; set; } = new List<List<Transaction>>();

        public Customer(string Username, string Password, List<List<Transaction>> AccountsList)
        {
            this.Username = Username;
            this.Password = Password;
            this.AccountsList = AccountsList;
        }
    }
}