using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Boolean.CSharp.Main.Users
{
    /// <summary>
    /// Class Engineer inheritates from the interface IUser.
    /// The ID of the engineer should be 0XXX
    /// </summary>
    public class Engineer : IUsers
    {
        private string _name;
        private int _Id;
        private bool _IsActive = true;
        public string Name { get { return _name; } set { _name = value; } }
        public int Id { get { return _Id; } set { _Id = value; } }
        public bool IsActive { get { return _IsActive; } }

        public double getBalanceOfCustommerAcc(Custommer custommer, Guid accID)
        {
            // Accessing the custommer account specified by a specific ID.
            IAccount account = custommer.getAccAccounts()[accID];

            // Accessing transactions of that account: 
            List<Transaction> transactions = account.getOverview();

            // If no transactions have been made, jsut return the balance of the account.
            if (transactions.Count != 0)
            {
                // Get the balance from the most previous transatction.
                double accBalance = transactions[transactions.Count - 1].NewBalance;
                return accBalance;
            }
            else
            {
                return account.getBlance();
            }
        }
    }
}
