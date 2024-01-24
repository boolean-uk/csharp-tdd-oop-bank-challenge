using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Accounts.Constants;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Users
{
    /// <summary>
    /// Class Custommer inheritates from the interface IUser.
    /// The ID of the engineer should b 1XXX
    /// </summary>
    public class Custommer : IUsers
    {
        //Define fields:
        private string _name;
        private int _Id;
        private bool _IsActive = true;
        private Branches _branch;
        private Manager _accManager = new Manager();


        private Dictionary<Guid, IAccount> accounts = new Dictionary<Guid, IAccount>();
        // private List<Transaction> overdraftRequest = new List<Transaction>();

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

        /// <summary>
        /// Method to perform transaction based on the type of request. Can either deposit, withdraw or send an overdraft request
        /// </summary>
        /// <param name="acc"> Acount to deposit money</param>
        /// <param name="transaction1">Deposit request</param>
        /// <exception cref="Exception"></exception>


        public void PerformTransaction(Guid acc, Transaction request)
        {
            if (accounts.ContainsKey(acc))
            {
                switch (request.Type)
                {
                    case TransactionType.Deposit:
                        accounts[acc].Deposit(request);
                        break;

                    case TransactionType.Withdraw:
                        accounts[acc].Withdraw(request);
                        break;

                    case TransactionType.Overdraft:
                        accounts[acc].RequestOverdraft(request, _accManager);
                        break;


                }
            }
            else
            {
                throw new Exception("No account available");

            }
        }

        /// <summary>
        /// This method the a list of all overdraft requests in the specific account.
        /// </summary>
        /// <param name="acc"> Account of interest</param>
        /// <returns></returns>
        public List<Transaction> getRequest(Guid acc)
        {
            return accounts[acc].getRequest();
        }

    }
}
