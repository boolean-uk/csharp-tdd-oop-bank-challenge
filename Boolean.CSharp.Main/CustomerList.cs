using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Payloads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class CustomerList
    {
        public List<Customer> customers = new List<Customer>();

        public void OpenCustomerFile()
        {
            string mypath = @"C:\Csharp\csharp-tdd-oop-bank-challenge\customers.txt";
            // create the file if it doesn't exist
            if (!File.Exists(mypath))
            {
                string[] createText = { "Username, Address, Password" };
                File.WriteAllLines(mypath, createText, Encoding.UTF8);
            }
            string[] readText = File.ReadAllLines(mypath, Encoding.UTF8);
            foreach (string s in readText)
            {
                if (s.Length > 0)
                {
                    string[] CustomerInfo = s.Split(',');
                    var NewUsername = CustomerInfo[0];
                    var NewAddress = CustomerInfo[1];
                    var NewPassword = CustomerInfo[2];
                    Customer customer = new Customer(name: NewUsername, address: NewAddress, password: NewPassword);
                    AddExistingCustomer(customer);
                }
            }
            Console.WriteLine("Loaded Customer File");
        }

        public void AddNewCustomer(Customer newcustomer)
        {
            if (!customers.Exists(x => x.Name == newcustomer.Name))
            {
                this.customers.Add(newcustomer);
                string createText = '\n' + newcustomer.Name + ',' + newcustomer.Address + ',' + newcustomer.Password;
                File.AppendAllText(@"C:\Csharp\csharp-tdd-oop-bank-challenge\customers.txt", createText, Encoding.UTF8);
                Console.WriteLine("\nSuccess! You are now a registered client with the Seguro Bank. Make sure to keep you account information safe!");
                Thread.Sleep(2500); 
                Console.WriteLine("\nPress Enter to return to the main menu, where you can enter your credentials and access your account.");
                string exit = Console.ReadLine();
                switch (exit) { default: break; }  
                Console.Clear();
            }
            else
            {
                Console.WriteLine("\nCustomer already exists.");
                Console.WriteLine("Returning to main menu.");
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        public void AddExistingCustomer(Customer newcustomer)
        {
            if (!customers.Exists(x => x.Name == newcustomer.Name))
            {
                this.customers.Add(newcustomer);
            }
        }

        public bool CheckCustomerName(string username)
        {
            if (!customers.Exists(x => x.Name == username))
            { return false; }
            return true;
        }

        public bool CheckPassword(string username, string password)
        {
            if (CheckCustomerName(username) == true)
            {
                var selectCustomer = customers.Where(customer => customer.Name == username).First();
                var listedPassword = selectCustomer.Password;
                return listedPassword == password;
            } return false;
        }

    }
}
