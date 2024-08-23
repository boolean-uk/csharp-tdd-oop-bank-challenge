using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class Customer : IPerson
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public int Age { get; private set; }
        public float CashOnHand { get; private set; }
        public int ID { get; set; } //ID delegated by bank

        public Customer(string FirstName, string LastName, string PhoneNumber, float CashOnHand) {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.CashOnHand = CashOnHand;
            this.Email = this.FirstName.ToLower() + "." + LastName.ToLower() + "@email.com";
            this.ID = -1;
        }

        ////pass this as arg, when creating a bank acount the customer is given a unique id
        //public bool createBankAccount() 
        //{


        //    //call controller and pass relevant args
        //    //should return a new id for the user which we can set later
        //    //this.ID = functionReturn;
            


        //    return false;
        //}

        //public bool depositMoneyToTransactionalAccount(float amount) { throw new NotImplementedException(); }

        //public bool depositMoneyToSavingsAccount(float amount) { throw new NotImplementedException(); }

        //public bool withdrawMoneyFromTransactionalAccount(float amount) { throw new NotImplementedException(); }
        //public bool withdrawMoneyFromSavingsAccount(float amount) { throw new NotImplementedException(); }

        ////pass this as arg
        //public void generateBankStatements() { throw new NotImplementedException(); }


    }
}
