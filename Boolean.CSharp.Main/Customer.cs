using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private string _ID;
        private List<IAccount> _accounts = new List<IAccount>();

        public Customer()
        {
            _ID = Guid.NewGuid().ToString();

        }

        public IAccount addAccount(AccountType type, string branch)
        {
            IAccount account = Account.createAccount(type, branch);
            _accounts.Add(account);

            return account;
        }

        public bool requestOvedraft(string ID, float amount)
        {
            // find account
            var account = _accounts.FirstOrDefault(x => x.ID == ID);

            if (account is not GeneralAccount)
            {
                return false;
            }

            if (account.getBalance() >= amount ) 
            {
                Console.WriteLine("Your requested amount does not exceed account balance!");
                return false;
            }
            else
            {
                GeneralAccount generalAccount = (GeneralAccount)account;

                bool res = Manager.handleOverdraftRequest(_ID, generalAccount, amount);

                if (res)
                {
                    generalAccount.acceptOverdraft(amount, TransactionType.WITHDRAW);
                    return res;
                }

                return res;
            }
        }


        public List<IAccount> ListAccounts()
        {
            return _accounts;
        }

    }
}
