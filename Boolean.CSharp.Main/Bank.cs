using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public List<Person> customers { get; set; } = new List<Person>();
        public List<Person> managers { get; set; } = new List<Person>();
        public List<Request> requests { get; set; } = new List<Request>();  
        public List<Request> approvedRequests { get; set; } = new List<Request>();

        public List<Request> UpdateRequests()
        {
            //brute force adding all customer requests to list.
            customers.ForEach(
                c => c.accounts.ForEach(
                    a => a.requests.ForEach(
                        r => requests.Add(r))));
            return requests;
        }
        public List<Request> GetRequests()
        {
            return requests;
        }
        public void AddCustomer(string ssn) 
        {
            Customer customer = new Customer(ssn, this); 
            customers.Add(customer);    
        }
        public void AddManager(string ssn)
        {
            Manager manager= new Manager(ssn, this);
            managers.Add(manager);
        }

    }
}

