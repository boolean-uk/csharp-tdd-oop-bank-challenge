using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Boolean.CSharp.Main.Model;
using Boolean.CSharp.Main.View;

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
                View.View.CreateAccount(AccountName);
                return c.CreateAccount(AccountName); 
            }
        }

        internal bool CreateCustomer(string CustomerName, string SocialSecurityNr)
        {
            try
            {
                Customer c = new Customer(CustomerName, SocialSecurityNr);
                management.AddCustomer(c);
                View.View.CreateCustomer(CustomerName);
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
                if (Convert.ToDouble(a!.GetBalance()) - value < 0)
                {
                    if (OverdraftCheck(AccountName, SocialSecurityNr, (Convert.ToDouble(a.GetBalance()) - value)))
                    {
                        a!.WithdrawFunds(value);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    a!.WithdrawFunds(value);
                    return true;
                }
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

        internal bool GenerateAccountStatment(string AccountName, string SocialSecurityNr)
        {
            Customer? c = management.GetCustomer().FirstOrDefault(propa => propa.CustomerId == SocialSecurityNr);
            IAccount? a = c!.Accounts.FirstOrDefault(propa => propa.GetAccountName() == AccountName);
            View.View.GenerateBankStatment(a!.GenerateBankStatment());
            return true;
        }

        internal bool OverdraftCheck(string AccountName, string SocialSecurityNr, double overdraft)
        {
            if (View.View.OverdraftCheck(AccountName, SocialSecurityNr, overdraft))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        internal void GetCustomersList()
        {
            View.View.GetCustomersList(GetCustomers());
        }



    }
}
