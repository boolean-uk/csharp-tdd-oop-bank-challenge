using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Person : Iperson
    {
        public string ssn { get; set; } = "not set";
        public Bank bank { get; set; }
        public Account? CurrentAccount { get; set; } 
        public Account? SavingsAccount { get; set; }   
        public List<Account> accounts { get; set; } = new List<Account>();

        public Person(string Ssn, Bank Bank)
        {
            ssn= Ssn;
            bank = Bank;
        }
        public void GetRequestResponse()
        {

            List<Request> approvedRequests = new List<Request>();
            bank.approvedRequests.ForEach(req =>
            {
                if (req.ssn == ssn)
                {
                    approvedRequests.Add(req);
                }
            });
            this.accounts.ForEach(account =>
            {
                approvedRequests.ForEach(req =>
                {
                    if (req.accountID == account.accountID)
                    {
                        account.overdraft = req.amount;
                    }
                });
            });

        }
        public string ActivateSmsStatements()
        {
            throw new NotImplementedException();
        }

        public void CreateCurrentAccount()
        {
            CurrentAccount= new Account("Current" ,this);
            accounts.Add(CurrentAccount);
        }
        public Iaccount? GetCurrentAccount()
        {
            return CurrentAccount;
        }
        public void CreateSavingsAccount()
        {
            SavingsAccount= new Account("Savings", this);
            accounts.Add(SavingsAccount);
        }
        public Iaccount? GetSavingsAccount()
        {
            return SavingsAccount;
        }



    }
}
