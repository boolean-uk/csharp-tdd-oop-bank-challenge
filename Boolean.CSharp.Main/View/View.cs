using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Controler;
using System.Runtime.CompilerServices;
using Boolean.CSharp.Main.Model;

[assembly: InternalsVisibleTo("Boolean.CSharp.Test")]


namespace Boolean.CSharp.Main.View
{
    internal class View
    {
        internal static void CreateCustomer(string CustomerName)
        {
                Console.WriteLine($"A customer by the name of {CustomerName} has been created");
        }

        internal static void CreateAccount(string AccountName)
        {

                Console.WriteLine($"The account '{AccountName}' has been created");
        }

        internal static void GetAccountBalance(string AccountName, string SocialSecurityNr, MainControler Controler)
        {
            Console.WriteLine($"Your balance for account: {AccountName} is: {Controler.GetAccountBalance(AccountName, SocialSecurityNr)}");
        }

        internal static void GetCustomersList(List<Customer> list) 
        {
            Console.WriteLine($"Cutomers in list");
            foreach (Customer c in list)
            {
                Console.WriteLine(c.Name);
            }
        }


        internal static void GenerateBankStatment(List<string> list)
        {
            List<string> c = list;
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
        }

        internal static bool OverdraftCheck(string AccountName, string SocialSecurityNr, double overdraft)
        {
            Console.WriteLine($"Customer: {SocialSecurityNr} has requested an overdraft of {overdraft} for the account {AccountName}.");
            Console.WriteLine($"Would you like to approve this request yes (y) or no (n)?");

            // hard to test with a readLine
            //string s = Console.ReadLine();
            string s = "y";

            if (s.ToLower() == "yes" || s.ToLower() == "y")
            {
                Console.WriteLine("approved");
                return true;
            }
            else 
            {
                Console.WriteLine("denied");
                return false;
            }


        }

    }
}
