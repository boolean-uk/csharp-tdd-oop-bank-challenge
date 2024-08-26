using Boolean.CSharp.Main.Accounts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Bank
    {
       public string Name { get; set; }
       public double emergencyFund { get; set; }
       public List<Branch> branches = new List<Branch>();
       public Bank(string name, double emergencyFund, Branch? one, Branch? two) 
       {
            this.Name = name;
            this.emergencyFund = emergencyFund;
            this.branches.Add(one);
            this.branches.Add(two);
       }

        public bool createAccount(Account account)
        {

            if (!branches.Any(b => b.branchName == account.branch.branchName))
            {
                Console.WriteLine($"{this.Name} does not have a {account.branch.branchName} branch!");
                return false; 
            }

            Branch branch = branches.Find(b => b.branchName == account.branch.branchName);

            branch.AddAccount(account);

            return true;
        }

        /*
        public bool answerOverdraft(Account account, double amount)
        {

            if (!branches.Any(b => b.branchName == account.branch.branchName))
            {
                Console.WriteLine("Account not found!");
                return false; 
            }

            if (account.getBalance() > amount)
            {
                Console.WriteLine("Your balance is to high to ask for an overdraft!");
                return false;
            }

            if (account.getBalance() - amount < 0 && this.emergencyFund > amount)
            {
                this.emergencyFund -= amount;
                
            }

            return true;
        }
        */
    }
}
