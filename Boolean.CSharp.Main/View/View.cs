using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Controler;
using System.Runtime.CompilerServices;

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
            Console.WriteLine($"Your balance is: {Controler.GetAccountBalance(SocialSecurityNr, AccountName)}");
        }



        

    }
}
