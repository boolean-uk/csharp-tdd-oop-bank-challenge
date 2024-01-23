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
        Manager _manager;

        public Bank(BankLocation location)
        {
            _users = new List<User>();
            _location = location;
            _manager = new Manager("Default");
        }

        public Bank(BankLocation location, Manager manager)
        {
            _users = new List<User>();
            _location = location;
            _manager = manager;
        }

        public List<User> Users { get =>  _users; }
        public BankLocation Location { get => _location; }
        public Manager Manager { get => _manager; }

        public void AddUser(User user)
        {
            user.Location = _location;
            Users.Add(user);
        }

        public User CreateUser(int id, string name)
        {
            User user = new User(id, name, _location);
            AddUser(user);
            return user;
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

        public bool RemoveUser(int Id)
        {
             if (Users.Where(u => u.Id == Id).Count() > 0)
            {       
                _users.Remove(GetUserById(Id));
                return true;
            }

            Console.WriteLine($"User with ID {Id} does not exist");
            return false;
        }

        public User GetUserById(int id)
        {
            return Users.Where(user => user.Id == id).First();
        }

        public void GenerateOverdraftRequest(User user, double amount)
        {
            OverdraftRequest request = new OverdraftRequest(user.Id, amount);
            Manager.AddOverdraftRequest(request);
        }

        public void ApproveAllOverdraftRequests()
        {
            List<OverdraftRequest> approved = Manager.ApproveAllOverdraftRequests();
            UpdateOverdraftRequests(approved);
        }

        public void ApproveOverdraftRequestsAmount(double amount)
        {
            List<OverdraftRequest> approved = Manager.ApproveOverdraftRequestsAmount(amount);
            UpdateOverdraftRequests(approved);
        }

        public void ApproveOverdraftRequestsId(int id)
        {
            List<OverdraftRequest> approved = Manager.ApproveOverdraftRequestsId(id);
            UpdateOverdraftRequests(approved);
        }

        public void RejectAllOverdraftRequests()
        {
            Manager.RejectAllOverdraftRequests();
        }

        public void RejectOverdraftRequestsAmount(double amount)
        {
            Manager.RejectOverdraftRequestsAmount(amount);
        }

        public void RejectOverdraftRequestsId(int id)
        {
            Manager.RejectOverdraftRequestsId(id);
        }

        public void UpdateOverdraftRequests(List<OverdraftRequest> requests)
        {
            foreach (OverdraftRequest request in requests)
            {
                GetUserById(request.Id).OverdraftAmount = request.Amount;
            }
        }
    }
}