using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Branch
{
    public class LocalBank : IBankBranch
    {
        private List<IAccount> _accounts;
        private List<Customer> _customers;
        private List<IUser> _employees;
        private string _location;

        public LocalBank(string location)
        {

            this._location = location;

        }

        public bool AddAccountToBranch(IAccount account)
        {
            throw new NotImplementedException();
        }

        public bool AddEmployeeToBranch(IEmployee employee)
        {
            throw new NotImplementedException();
        }

        public bool AddUserToBranch(Customer user)
        {
            throw new NotImplementedException();
        }

        public List<IAccount> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public List<IUser> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public string GetLocation()
        {
            throw new NotImplementedException();
        }
    }
}
