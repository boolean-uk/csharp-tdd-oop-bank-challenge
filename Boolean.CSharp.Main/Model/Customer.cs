using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Model
{
    internal class Customer : IPerson
    {
        public string FirstName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string LastName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string PhoneNumber { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Age { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public float CashOnHand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Customer(string FirstName, string LastName, string PhoneNumber, float CashOnHand) {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.CashOnHand = CashOnHand;
            this.Email = this.FirstName.ToLower() + "." + LastName.ToLower() + "@email.com";
        }

        //pass this as arg
        public bool createBankAccount() { throw new NotImplementedException(); }

        public bool depositMoneyToTransactionalAccount(float amount) { throw new NotImplementedException(); }

        public bool depositMoneyToSavingsAccount(float amount) { throw new NotImplementedException(); }

        public bool withdrawMoneyFromTransactionalAccount(float amount) { throw new NotImplementedException(); }
        public bool withdrawMoneyFromSavingsAccount(float amount) { throw new NotImplementedException(); }

        //pass this as arg
        public void generateBankStatements() { throw new NotImplementedException(); }
    }
}
