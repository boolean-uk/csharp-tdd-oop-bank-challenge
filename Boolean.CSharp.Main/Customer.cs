using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private List<Account> accounts;
        private string name;
        public Customer(string name) 
        {
            this.name = name;
            accounts = new List<Account>();
        }

        public bool createAccount(Account acc)
        {
            bool result = false;

            if (accounts.Contains(acc) == false){
                accounts.Add(acc);
                result = true;
            }

            return result;
        }

        public bool depositAccount(string accName, float amount, string date)
        {
            bool result = false;

            foreach (Account acc in accounts)
            {
                if(acc.getName() ==  accName)
                {
                    result = acc.deposit(amount, date);
                    break;
                }
            }


            return result;
        }

        public bool withdrawAccount(string accName, float amount, string date)
        {
            bool result = false;

            foreach(Account acc in accounts)
            {
                if(acc.getName() == accName)
                {
                    result = acc.withdraw(amount, date);
                    break;
                }
            }


            return result;
        }
        public List<string> accountStatement(string accName)
        {
            List<string> result = new List<string>();

            foreach(Account acc in accounts)
            {
                if (acc.getName() == accName)
                {
                    result = acc.statement();
                }
            }

            return result;
        }

        public string getName()
        {
            return name;
        }
    }
}
