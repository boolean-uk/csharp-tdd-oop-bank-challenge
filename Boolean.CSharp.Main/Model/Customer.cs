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
        internal int ID { get; set; } //ID delegated by bank

        internal Customer(string FirstName, string LastName, string PhoneNumber, float CashOnHand) {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.PhoneNumber = PhoneNumber;
            this.CashOnHand = CashOnHand;
            this.Email = this.FirstName.ToLower() + "." + LastName.ToLower() + "@email.com";
            this.ID = -1;
        }


    }
}
