using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public List<User> Users { get; set; }
        public BankLocation Location { get; set; }
        public Manager Manager { get; set; }

        public Bank(BankLocation location)
        {
            Users = new List<User>();
            Location = location;
            Manager = new Manager("Default");
        }

        public Bank(BankLocation location, Manager manager)
        {
            Users = new List<User>();
            Location = location;
            Manager = manager;
        }

        public void AddUser(User user)
        {
            user.Location = Location;
            Users.Add(user);
        }

        public User CreateUser(int id, string name)
        {
            User user = new User(id, name, Location);
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

            Users.Remove(user);
            return true;
        }

        public bool RemoveUser(int Id)
        {
             if (Users.Where(u => u.Id == Id).Count() > 0)
            {       
                Users.Remove(GetUserById(Id));
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