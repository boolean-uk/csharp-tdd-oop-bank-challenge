using Boolean.CSharp.Main.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.View
{
    internal class View
    {
        internal void createBankAccount(Customer customer)
        {
            Console.WriteLine($"Bank account for {customer.FirstName} {customer.LastName} is being created!");
        }

        internal IPerson createPerson(bool isCustomer)
        {
            if (isCustomer) {
                Console.WriteLine("A customer is being created!");
                string FirstName = "Test";
                string LastName = "Testsson";
                string PhoneNumber = "1234567890";
                float CashOnHand = 1000.0f;
                return new Customer(FirstName, LastName, PhoneNumber, CashOnHand);
            }
            return null; //for engineer creation later
        }

        internal void doesNotExistWarning()
        {
            throw new NotImplementedException();
        }
    }
}
