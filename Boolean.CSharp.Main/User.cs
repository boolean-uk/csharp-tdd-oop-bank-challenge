using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class User
    {
        private string _name;
        private Role _role;
        private List<Account> _accounts;

        public User(string name, Role role)
        {
            _name = name;
            _role = role;
        }

        public string Name { get { return _name; } }
        public Role Role { get { return _role; } }
    }
}