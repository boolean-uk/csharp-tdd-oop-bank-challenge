﻿using System;
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
        internal static void CreateCustomer(string CustomerName, string SocialSecurityNr, MainControler Controler)
        {
            if(Controler.CreateCustomer(CustomerName, SocialSecurityNr))
            {
                Console.WriteLine($"A customer by the name of {CustomerName} has been created");
            }
        }

        internal static void CreateAccount(string AccountName, string SocialSecurityNr, MainControler Controler)
        {
            if (Controler.CreateAccount(AccountName, SocialSecurityNr))
            {
                Console.WriteLine($"An account has been created");
            }
        }

        internal static void GetAccountBalance(string AccountName, string SocialSecurityNr, MainControler Controler)
        {
            Console.WriteLine($"Your balance for account: {AccountName} is: {Controler.GetAccountBalance(AccountName, SocialSecurityNr)}");
        }

        internal static void GetCustomersList(MainControler Controler) 
        {
            Console.WriteLine($"Cutomers in list");
            foreach (Customer c in Controler.GetCustomers())
            {
                Console.WriteLine(c.Name);
            }
        }

        internal static void AddFunds(string AccountName, string SocialSecurityNr, MainControler Controler, double i) 
        {
            Controler.AddFundToAccount(i, AccountName, SocialSecurityNr);
        }

        internal static void WithdrawFunds(string AccountName, string SocialSecurityNr, MainControler Controler, double i)
        {
            Controler.WithdrawFundsFromAccount(i, AccountName, SocialSecurityNr);
        }

        internal static void GenerateBankStatment(string AccountName, string SocialSecurityNr, MainControler Controler)
        {
            List<string> c = Controler.GenerateAccountStatment(AccountName, SocialSecurityNr);
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }
        }

    }
}
