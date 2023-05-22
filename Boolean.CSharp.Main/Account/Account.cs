using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.Account
{
    public class Account : IUser
    {
        //private int _id;
        private decimal _balance;
       
        private string _fristName;
        private string _lastName;
        private string _phoneNumber;
        
        private AccountType _type;
        public IUser _user;

        

        public Account(string firstName, string lastName, string phone, decimal balance, AccountType type) {
            _type = type;
            _fristName = firstName;
            _lastName = lastName;
            _phoneNumber = phone;
            _balance = balance;
            
            
        
        }
        public string firstName { get { return _fristName; } set { _fristName = value; } }
        public string phoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        public string lastName { get { return _lastName; } set { _lastName = value; } }
        public decimal balance { get { return _balance; } set { _balance = value; } }

        public AccountType accountType { get { return _type; } set { _type = value; } }




    }
}
