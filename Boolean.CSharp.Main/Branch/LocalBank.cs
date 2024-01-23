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
        private List<IEmployee> _employees = new List<IEmployee>();
        private string _location;

        public LocalBank(string location)
        {

            this._location = location;

        }

        /// <inheritdoc />
        public bool AddAccountToBranch(IAccount account)
        {
            int val1 = _accounts.Count;
            _accounts.Add(account);
            int val2 = _accounts.Count;
            return val2 > val1;
        }

        /// <inheritdoc />
        public bool AddEmployeeToBranch(IEmployee employee)
        {
            int val1 = _employees.Count;
            _employees.Add(employee);
            int val2 = _employees.Count;
            return val2 > val1;
        }

        /// <inheritdoc />
        public bool AddUserToBranch(Customer user)
        {
            int val1 = _customers.Count;
            _customers.Add(user);
            int val2 = _customers.Count;
            return val2 > val1;
        }

        /// <inheritdoc />
        public void AssignOverdraftRequest(IOverdraftRequest request)
        {
            int randomValue = new Random().Next(0, _employees.Count);
            IEmployee employee = _employees[randomValue];
            employee.AddOverdraftRequest(request);

        }

        /// <inheritdoc />
        public List<IAccount> GetAccounts()
        {
            return new List<IAccount>(this._accounts);
        }

        /// <inheritdoc />
        public List<Customer> GetCustomers()
        {
            return new List<Customer>(_customers);
        }

        /// <inheritdoc />
        public List<IUser> GetEmployees()
        {
            return new List<IUser>(_employees);
        }

        /// <inheritdoc />
        public string GetLocation()
        {
            return _location;
        }
    }
}
