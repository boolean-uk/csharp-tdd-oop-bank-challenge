using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Account;


namespace Boolean.CSharp.Main.Account
{
    public class User : IUser
    {
        private string _fristName;
        private string _lastName;
        private string _phoneNumber;
        private decimal _balance;
        private List<Transaction> _transactions = new List<Transaction>();
        private AccountType _type;

        public string firstName { get { return _fristName; } set { _fristName = value; } }
        public string phoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        public string lastName { get { return _lastName; } set { _lastName = value; } }
        public decimal balance { get { return _balance; } set { _balance = value; } }
        public List<Transaction> transactions { get { return _transactions; } set { _transactions = value; } }




        public AccountType accountType { get { return _type; } set { _type = value; }}
        public User(string firstName, string lastName,string phone, decimal balance,AccountType type) { 
            _fristName = firstName;
            _lastName = lastName;
            _phoneNumber = phone;
            _balance = balance;
            _type = type;
        }
    }
}
