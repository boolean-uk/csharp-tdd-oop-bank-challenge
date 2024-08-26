using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enum;
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

        public bool decideOverdraft(Overdraft overdraft, Role role, bool accept)
        {

            
            if (role != Role.MANAGER)
            {
                Console.WriteLine($"Only the manager can decide on an overdraft!");
                return false;
            }

            if (emergencyFund < overdraft.amount)
            {
                Console.WriteLine($"Emergencyfund is to low to gice an overdraft!");
                return false;
            }

                Account account = overdraft.Account;

            if (!accept)
            {
                account._requests.Remove(overdraft);
                Console.WriteLine("Overdraft request declined by the manager!");
                return false;
            }

                overdraft.answer = Answer.ACCEPTED;
                account._transactions.Add(overdraft.transactions);

            if (account.getBalance() > 0)
            {
                
                emergencyFund -= (account.getBalance() + overdraft.amount);
            } 
            else 
            {
                emergencyFund -= overdraft.amount;
            }

                account._requests.Remove(overdraft);

                Console.WriteLine("Overdraft approved by the manager!");
                Console.WriteLine("You owe the bank: " + account.getBalance());

                return true;
        }
    }
}
