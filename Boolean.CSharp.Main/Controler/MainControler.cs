using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Boolean.CSharp.Main.Model;

namespace Boolean.CSharp.Main.Controler
{
    public class MainControler
    {
        private Managment management;
        internal MainControler() { 
            this.management = new Managment();
        }

        internal bool CreateAccount(string AccountName, string SocialSecurityNr)
        {
            Customer? c = management.GetCustomer().FirstOrDefault(propa => propa.CustomerId == SocialSecurityNr);
            if (c == null)
            {
                return false;
            }
            else
            {
                return c.CreateAccount(AccountName); 
            }
        }

        internal bool CreateCustomer(string CustomerName, string SocialSecurityNr)
        {
            try
            {
                Customer c = new Customer(CustomerName, SocialSecurityNr);
                management.AddCustomer(c);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        internal bool AddFundToAccount(double value, string AccountName, string SocialSecurityNr)
        {
            try
            {
                Customer? c = management.GetCustomer().FirstOrDefault(c => c.CustomerId.Equals(SocialSecurityNr));
                IAccount? a = c!.Accounts.FirstOrDefault(propa => propa.GetAccountName() == AccountName);
                a!.DepositFunds(value);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        internal bool WithdrawFundsFromAccount(double value, string AccountName, string SocialSecurityNr)
        {
            try
            {
                Customer? c = management.GetCustomer().FirstOrDefault(c => c.CustomerId.Equals(SocialSecurityNr));
                IAccount? a = c!.Accounts.FirstOrDefault(propa => propa.GetAccountName() == AccountName);
                a!.WithdrawFunds(value);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        internal List<Customer> GetCustomers() { 
            return management.GetCustomer();
        }

        internal string GetAccountBalance(string AccountName, string SocialSecurityNr)
        {
            Customer? c = management.GetCustomer().FirstOrDefault(propa => propa.CustomerId == SocialSecurityNr);
            IAccount? a = c!.Accounts.FirstOrDefault(propa => propa.GetAccountName() == AccountName);
            return a!.GetBalance();
        }

        internal List<string> GenerateAccountStatment(string AccountName, string SocialSecurityNr)
        {
            Customer? c = management.GetCustomer().FirstOrDefault(propa => propa.CustomerId == SocialSecurityNr);
            IAccount? a = c!.Accounts.FirstOrDefault(propa => propa.GetAccountName() == AccountName);
            return a!.GenerateBankStatment();
        }
    }
}
