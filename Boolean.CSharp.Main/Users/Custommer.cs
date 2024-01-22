using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Users
{
    public class Custommer : IUsers
    {
        //Define fields:
        private string _name;
        private int _Id;
        private bool _IsActive = true;
        private Branches _branch;

        private List<IAccount> accounts = new List<IAccount>();

        public string Name { get { return _name; } set { _name = value; } }
        public int Id { get { return _Id; } set { _Id = value; } }
        public bool IsActive { get { return _IsActive; } }

        public Branches Branch { get { return _branch; } set { _branch = value; } }

        /// <summary>
        /// Create new instace of class Account based on the AccountType and store it in accounts.
        /// </summary>
        /// <param name="accType">Account type the user wants to create.</param>
        /// 
        public void makeAccount(AccountType accType)
        {
            switch (accType)
            {
                case AccountType.Current:
                    accounts.Add(new NormalAcc(_branch));
                    Console.WriteLine("Current account created ");
                    break;
                case AccountType.Saving:
                    accounts.Add(new SavingAcc(_branch));
                    Console.WriteLine("Saving account created");
                    break;
                default:
                    Console.WriteLine("Invalid account type");
                    break;
            }
        }

        /// <summary>
        /// Method to get the list of accounts.
        /// </summary>
        /// <returns>List of the user's accounts.</returns>
        public List<IAccount> getAccAccounts() => accounts;

    }
}
