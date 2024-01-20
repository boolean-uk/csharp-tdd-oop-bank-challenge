using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Manager 
    {
        private static List<Customer> _users= new List<Customer>();

        public static List<Customer> Users { get { return _users;  } }
        public Manager()
        {
        }

        public void registerCustomer(Customer user)
        {
            _users.Add(user);
        }

        public static bool handleOverdraftRequest(string ID, GeneralAccount account, float amount)
        {
            Console.WriteLine($"User ID = {ID} is requesting an overdraft.");
            Console.WriteLine($"Amount = {amount}, account balance = {account.getBalance()}");

            Console.WriteLine("Accept overdraft? (Y/N)");
            string input = Console.ReadLine();

            if ( input == "Y" ) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
