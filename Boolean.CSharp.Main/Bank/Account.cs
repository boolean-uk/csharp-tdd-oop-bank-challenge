namespace Boolean.CSharp.Main.Bank
{
    public abstract class Account
    {
        private List<Account> _myAccounts = new List<Account>();
        private string _accountType = "";

        public bool CreateAccount(Account account)
        {
            _accountType = account.AccountType;
            if (account.AccountType == "Current")
            {
                _myAccounts.Add(account);
                return true;
            }
            if (account.AccountType == "Savings")
            {
                _myAccounts.Add(account);
                return true;
            }
            return false;
        }

        public string AccountType { get { return _accountType; } set { _accountType = value; } }
        public List<Account> MyAccounts { get { return _myAccounts; } }
        
    }
}
