using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private List<User> _users;
        private BankLocation _location;

        public Bank(BankLocation location)
        {
            throw new NotImplementedException();
        }

        public List<User> Users { get =>  _users; }
        public BankLocation Location { get => _location; }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool RemoveUser(int ID)
        {
            throw new NotImplementedException();
        }
    }
}