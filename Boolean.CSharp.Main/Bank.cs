using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public string Name { get; } = "Bob's Bank";
        public List<BankBranch> BankBranches { get; set; } = new List<BankBranch>();


        public bool CreateAccount(IPerson person, string accountType, int branchID)
        {
            Random randy = new Random();
            int accountNumber = randy.Next(200);
           
            IAccount account;
            if (accountType == "Savings")
            {
                account = new SavingAccount(accountNumber);
                account.AccountBalance.Add(accountNumber, 0);
            }
            else if (accountType == "Current")
            {
                account = new CurrentAccount(accountNumber);
                account.AccountBalance.Add(accountNumber, 0);
            }
            else
            {
                return false;
            }

            BankBranch branch = GetBranch(branchID);
            branch.AddCustomer(person);
            person.AddAccount(account);

            return true;

        }
        public bool AddBranch(int id)
        {
            foreach (var item in BankBranches)
            {
                if (item.Id.Equals(id))
                {
                    return false;
                }
            }
            BankBranch branch = new BankBranch(id);
            BankBranches.Add(branch);
            return true;
        }

        public BankBranch GetBranch(int id)
        {
            BankBranch branch = new BankBranch(id);
            foreach (var item in BankBranches)
            {
                if (item.Id.Equals(id))
                {
                     branch = item;
                }
            }
            return branch;
        }
        

    }
}
