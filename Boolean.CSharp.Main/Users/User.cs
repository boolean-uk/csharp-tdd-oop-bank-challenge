using Boolean.CSharp.Main.CustomerAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class User 
    {
        private string _name;
        private string _surname;
        private string _email;


        public string name { get { return _name; } set { _name = value; } }
        public string surname { get { return _surname; } set { _surname = value; } }
        public string email { get { return _email; } set { _email = value; } }
    }
}
