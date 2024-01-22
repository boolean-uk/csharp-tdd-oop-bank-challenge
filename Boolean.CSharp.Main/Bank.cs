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
            _users = new List<User>();
            _location = location;
        }

        public List<User> Users { get =>  _users; }
        public BankLocation Location { get => _location; }

        public void AddUser(User user)
        {
            user.Location = _location;
            Users.Add(user);
        }

        public bool RemoveUser(User user)
        {
            if (!Users.Contains(user))
            {
                Console.WriteLine("User does not exist");
                return false;
            }

            _users.Remove(user);
            return true;
        }

        public bool RemoveUser(int ID)
        {
            foreach (User user in Users)
            {
                if (user.ID == ID)
                {
                    _users.Remove(user);
                    return true;
                }
            }

            Console.WriteLine($"User with ID {ID} does not exist");
            return false;
        }
    }
}