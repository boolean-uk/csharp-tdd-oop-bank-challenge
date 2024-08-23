using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Controler;


namespace Boolean.CSharp.Main.View
{
    public class View
    {


        public static void CreateCustomer(string CustomerName, string SocialSecurityNr, MainControler Controler)
        {
            if(Controler.CreateCustomer(CustomerName, SocialSecurityNr))
            {
                Console.WriteLine($"A customer by the name of {CustomerName} has been created");
            }
        }



        public static void CreateAccount(string AccountName, string SocialSecurityNr, MainControler Controler)
        {
            if (Controler.CreateAccount(AccountName, SocialSecurityNr))
            {
                Console.WriteLine($"An account has been created");
            }
        }


        

    }
}
