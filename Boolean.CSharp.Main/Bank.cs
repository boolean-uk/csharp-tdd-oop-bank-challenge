using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        List<Customer> customerList;

        public Bank()
        {
            customerList = new List<Customer>();
        }

        public bool addCustomer(Customer cust)
        {
            bool result = false;
            if (customerList.Contains(cust) == false) 
            {
                customerList.Add(cust);
                result = true;
            }
            return result;
        }

        public bool addAccountToCustomer(string custName, Account acc)
        {
            bool result = false;
            foreach (Customer cust in customerList)
            {
                if(cust.getName() == custName)
                {
                    result = cust.createAccount(acc);
                    break;
                }
            }

            return result;
        }

        public bool depositMoney(string custName, string accName, float amount, string date)
        {
            bool result = false;

            foreach(Customer cust in customerList)
            {
                if(cust.getName() == custName)
                {
                    result = cust.depositAccount(accName,amount,date);
                    break;
                }
            }

            return result;
        }

        public bool withdrawMoney(string custName, string accName, float amount, string date)
        {
            bool result = false;

            foreach(Customer cust in customerList)
            {
                if (cust.getName() == custName)
                {
                    result = cust.withdrawAccount(accName, amount, date);
                    break;
                }
            }

            return result;
        }

        public List<string> printStatement(string custName, string accName)
        {
            List<string> result = new List<string>();

            foreach(Customer cust in customerList)
            {
                if(cust.getName() == custName)
                {
                    result = cust.accountStatement(accName);
                    break;
                }
            }

            return result;
        }

    }
}
