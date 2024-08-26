using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Classes
{
    public class Bank
    {
        public Bank() { }

        public static List<IAccount> accounts { get; set; } = new List<IAccount>();

        public static List<Request> requestQueue { get; set; } = new List<Request>();

        public string bankName { get; set; }

        public bool handleRequest(string name, bool decision)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            Request request = Bank.requestQueue?.FirstOrDefault(x => x.name == name);
            if (request == null)
            {
                Console.WriteLine("Request not found for name: " + name);
                return false;
            }

            RegularAccount account = Bank.accounts?.OfType<RegularAccount>().FirstOrDefault(x => x.AccountHolderName == name);
            if (account == null)
            {
                Console.WriteLine("Account not found for name: " + name);
                return false;
            }

            if (decision)
            {
                account.overdrafted = true;
                account.overdraftedAmount = request.amount;
                // Immediately print to verify it was set
                Console.WriteLine("Overdraft status set to true for account: " + account.overdrafted);
            }
            else
            {
                Console.WriteLine("Request rejected for name: " + name);
            }

            Bank.requestQueue.Remove(request);

            Console.WriteLine($"Final overdraft status: {account.overdrafted}");
            Console.WriteLine($"Request queue count after handling: {Bank.requestQueue.Count()}");

            return true;
        }
    }
}
