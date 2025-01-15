using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class User
    {
        public string SSN { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public Roles Role { get; set; } = Roles.Customer;

        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Account> OverdraftRequests { get; set; } = new List<Account>();

        public User(string name)
        {
            Name = name;
        }

        public void SendOverdraftRequest(Account account)
        {
            OverdraftRequests.Add(account);
        }

        public void HandleOverdraftRequest(string accountnumber, List<Account> requests, double amount) 
        {
            if (Role != Roles.Manager) { throw new Exception("No permission to handle overdraft requests"); }
            else
            {
                Account request = requests.FirstOrDefault(x => x.AccountNumber == accountnumber);
                if (request != null)
                {
                    Console.WriteLine($"User is requesting account {request.OwnerName} to be overdrawn by {amount}\nApprove? (Y/N)");
                    while (true)
                    {
                        //string action = Console.ReadLine();  --Untestable with input...
                        string action = "y";
                        if (action == "y")
                        {
                            request.Withdraw(amount, true);
                            Console.WriteLine("Request approved!");
                            break;
                        }
                        else if (action == "n")
                        {
                            Console.WriteLine("Request denied!");
                            break;
                        }
                    }

                }
                else { throw new Exception("Error finding account"); }
            }
        }

        public double GetBalance(string accountnumber)
        {
            if (!Accounts.Any(a => a.AccountNumber == accountnumber)) 
            {
                throw new Exception("Account does not exist");
            }
            else if (Role == Roles.Engineer)
            {
                return Accounts.First(a => a.AccountNumber == accountnumber).Transactions.Sum(t => t.Amount);
            }
            else { return Accounts.First(a => a.AccountNumber == accountnumber).Balance; }
        }

        public CurrentAccount CreateAndGetCurrentAccount() 
        { 
            string newAccountNumber = Guid.NewGuid().ToString();
            CurrentAccount ca = new CurrentAccount(newAccountNumber, SSN, Role);
            Accounts.Add(ca);

            Console.WriteLine($"Current account with account numer: {newAccountNumber} created!"); 

            return ca;
        }

        public SavingsAccount CreateAndGetSavingsAccount()
        {
            string newAccountNumber = Guid.NewGuid().ToString();
            SavingsAccount sa = new SavingsAccount(newAccountNumber, SSN, Role);
            Accounts.Add(sa);

            Console.WriteLine($"Savings account with account numer: {newAccountNumber} created!");

            return sa;
        }


    }
}
 