using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Users
{
    public class Custommer : IUsers
    {
        //Define fields:
        private string _name;
        private int _Id;
        private bool _IsActive = true;
        private Branches _branch;


        private Dictionary<Guid, IAccount> accounts = new Dictionary<Guid, IAccount>();

        public string Name { get { return _name; } set { _name = value; } }
        public int Id { get { return _Id; } set { _Id = value; } }
        public bool IsActive { get { return _IsActive; } }

        public Branches Branch { get { return _branch; } set { _branch = value; } }

        /// <summary>
        /// Create new instace of class Account based on the AccountType and store it in accounts.
        /// </summary>
        /// <param name="accType">Account type the user wants to create.</param>
        /// 
        public void makeAccount(Enums accType)
        {
            switch (accType)
            {
                case Enums.Current:
                    NormalAcc newAcc1 = new NormalAcc(_branch);

                    accounts.Add(newAcc1._AccId, new NormalAcc(_branch));
                    Console.WriteLine("Current account created ");
                    break;
                case Enums.Saving:
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
        public Dictionary<Guid, IAccount> getAccAccounts() => accounts;


        /// <summary>
        /// Method to deposite the money in the specified account.
        /// </summary>
        /// <param name="acc"> Acount to deposit money</param>
        /// <param name="transaction1">Deposit request</param>
        /// <exception cref="Exception"></exception>
        public void Deposit(Guid acc, Transaction transaction)
        {
            if (accounts.ContainsKey(acc))
            {
                accounts[acc].Deposit(transaction);
            }
            else
            {
                throw new Exception("No account available");

            }
        }

        /// <summary>
        /// The method is used to return the balance of user's specificed account.
        /// </summary>
        /// <param name="acc"> ID of the wanted account</param>
        /// <returns>The account's balance</returns>
        /// <exception cref="Exception"></exception>
        public double getBalance(Guid acc)
        {
            if (accounts.ContainsKey(acc))
            {
                return accounts[acc].getBlance();
            }
            else
            {
                throw new Exception("No account available");

            }
        }

        public void Withdraw(Guid acc, Transaction transaction)
        {
            if (accounts.ContainsKey(acc))
            {
                accounts[acc].Withdraw(transaction);
            }
            else
            {
                throw new Exception("No account available");

            }
        }
    }
}
