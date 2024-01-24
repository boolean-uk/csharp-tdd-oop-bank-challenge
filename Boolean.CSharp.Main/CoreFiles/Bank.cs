using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.CoreFiles
{
    public class Bank
    {
        List<Account> _accounts = new List<Account>();
        public string _phoneNumber { get; protected set; } = "";

        public Bank(string phoneNumber = "") { _phoneNumber = phoneNumber; }

        public Account CreateAccount(User user, AccountType accountType, MobilePhone mobilePhone)
        {
            Account newAccount;

            switch (accountType)
            {
                case AccountType.Current:
                    newAccount = new AccountCurrent(this, user, (mobilePhone != null) ? mobilePhone : null);
                    _accounts.Add(newAccount);
                    return newAccount;
                case AccountType.Savings:
                    newAccount = new AccountSavings(this, user, (mobilePhone != null) ? mobilePhone : null);
                    _accounts.Add(newAccount);
                    return newAccount;

                default:
                    return null;
            }
        }

        public List<Account> GetAccountTransactions(Account account)
        {
            throw new NotImplementedException();
        }

        internal bool SendMessage(string recieverPhoneNumber, string message)
        {
            if(message == null || recieverPhoneNumber == "") 
                return false;

            SMSsender smsSender = new SMSsender();
            smsSender.SendMessage(_phoneNumber, recieverPhoneNumber, message);

            return true;
        }

        public List<Overdraft> GetOverdraftRequests()
        {
            List<Overdraft> result = new List<Overdraft>();
            foreach (var account in _accounts)
            {
                foreach(var pendingOverdraft in account.Overdrafts)
                {
                    result.Add(pendingOverdraft);
                }
            }

            return result;
        }
    }
}
