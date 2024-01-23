using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Transactions;
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
        private List<IAccount> _accounts = new List<IAccount>();
        private List<Customer> _customers = new List<Customer>();
        private List<IUser> _employees = new List<IUser>();
        private string _location;

        public LocalBank(string location)
        {

            this._location = location;

        }

        public bool AddAccountToBranch(IAccount account)
        {
            int val1 = _accounts.Count;
            _accounts.Add(account);
            int val2 = _accounts.Count;
            return val2 > val1;
        }

        public bool AddEmployeeToBranch(IEmployee employee)
        {
            int val1 = _employees.Count;
            _employees.Add(employee);
            int val2 = _employees.Count;
            return val2 > val1;
        }

        public bool AddUserToBranch(Customer user)
        {
            int val1 = _customers.Count;
            _customers.Add(user);
            int val2 = _customers.Count;
            return val2 > val1;
        }

        public void AssignOverdraftRequest(IOverdraftRequest request)
        {
            throw new NotImplementedException();
        }

        public List<IAccount> GetAccounts()
        {
            return new List<IAccount>(this._accounts);
        }

        public List<Customer> GetCustomers()
        {
            return new List<Customer>(_customers);
        }

        public List<IUser> GetEmployees()
        {
            return new List<IUser>(_employees);
        }

        public string GetLocation()
        {
            return _location;
        }
    }
}
