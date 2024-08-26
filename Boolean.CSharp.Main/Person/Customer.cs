using Boolean.CSharp.Main.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.Person
{
    public class Customer
    {
        private List<BankAccount> _bankAccounts;
        private string _firstName;
        private string _lastName;
        private int _phoneNumber;

        public Customer(string firstname, string lastname, int phonenumber)
        {
            this._firstName = firstname;
            this._lastName = lastname;
            this._phoneNumber = phonenumber;
            this._bankAccounts = new List<BankAccount>();
        }

        public BankAccount FindBankAccount(int accountnumber)
        {
            throw new NotImplementedException();
        }

        public void AddBankAccount(BankAccount b)
        {
            throw new NotImplementedException();
        }
        
        public List<BankAccount> BankAccounts { get => this._bankAccounts; set => this._bankAccounts = value; }

        public string FirstName { get => this._firstName; set => this._firstName = value; }
        public string LastName { get => this._lastName; set => this._lastName = value; }
        public int PhoneNumber { get => this._phoneNumber; set => this._phoneNumber = value; }
    }
}
