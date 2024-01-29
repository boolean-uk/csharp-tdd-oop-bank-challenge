using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public List<Customer> customers = new List<Customer>();
        private int _bankId;
        private BankLocation _bankLocation;
        public Bank(int bankId, BankLocation bankLocation)
        {
            _bankId = bankId;
            _bankLocation = bankLocation;
        }
        public int BankId { get { return _bankId; } }
        public BankLocation BankLocation { get {  return _bankLocation; } }

        public void createCustomer(string firstName, string lastName)
        {
            Customer customer = new Customer(firstName, lastName);
            customers.Add(customer);
        }
    }
}
