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
    public interface IBankBranch
    {
        string GetLocation();

        List<IAccount> GetAccounts();

        List<Customer> GetCustomers();

        List<IUser> GetEmployees();

        bool AddUserToBranch(Customer user);

        bool AddAccountToBranch(IAccount account);

        void AssignOverdraftRequest(IOverdraftRequest request);

        bool AddEmployeeToBranch(IEmployee employee);
    }
}
