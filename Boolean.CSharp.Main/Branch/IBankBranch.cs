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
        /// <summary>
        /// Retrieve the location of the IBankBranch as a string
        /// </summary>
        /// <returns>string - Location of the IBankBranch</returns>
        string GetLocation();

        /// <summary>
        /// Retrieve a list of IAccount objects associated with the IBankBranch
        /// </summary>
        /// <returns>List<IAccount> - A list of IAccount objects </returns>
        List<IAccount> GetAccounts();

        /// <summary>
        /// Retrieve a list of Customer objects associated with the IBankBranch
        /// </summary>
        /// <returns>List<Customer> - A list of Customer objects</returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Retrieve a list of Employee objects associated with the IBankBranch
        /// </summary>
        /// <returns> List<IUser> - A list of IUser objects </returns>
        List<IUser> GetEmployees();

        /// <summary>
        /// Attempt to add a Customer object to the IBankBranch
        /// </summary>
        /// <param name="user">Customer - The user to associate with the IBankBranch</param>
        /// <returns>bool - True if the Customer was successfully added to the IBankBranch, otherwise false</returns>
        bool AddUserToBranch(Customer user);

        /// <summary>
        /// Attempt to add a IAccount object to the IBankBranch
        /// </summary>
        /// <param name="account"> IAccount - The IAccount object to associate with the IBankBranch </param>
        /// <returns> bool - True if the IAccount was successfully added to the IBankBranch, otherwise false </returns>
        bool AddAccountToBranch(IAccount account);

        /// <summary>
        /// Register a IOverdraftRequest and distribute it to one of the registered Employee of the IBankBranch
        /// </summary>
        /// <param name="request"> IOverdraftRequest - the request object to be evaluated by an Employee </param>
        void AssignOverdraftRequest(IOverdraftRequest request);

        /// <summary>
        /// Attempt to add a IEmployee object to the IBankBranch
        /// </summary>
        /// <param name="employee"> IEmployee - The IEmplyeee object to associate with the IBankBranch </param>
        /// <returns> bool - True if the IEmployee wwas successfully added to the IBankBranch, otherwise false </returns>
        bool AddEmployeeToBranch(IEmployee employee);
    }
}
