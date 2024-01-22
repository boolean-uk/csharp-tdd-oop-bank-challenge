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
        

        private Dictionary<string,IAccount> accounts = new Dictionary<string,IAccount>();

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
                    NormalAcc newAcc1 = new NormalAcc(_branch);

                    accounts.Add(newAcc1._AccId,new NormalAcc(_branch));
                    Console.WriteLine("Current account created ");
                    break;
                case AccountType.Saving:
                    SavingAcc newAcc2 = new SavingAcc(_branch);
                    accounts.Add(newAcc2._AccId, new SavingAcc(_branch));
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
        public Dictionary<string, IAccount> getAccAccounts() => accounts;

    }
}
