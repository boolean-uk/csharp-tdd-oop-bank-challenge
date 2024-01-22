namespace Boolean.CSharp.Main
{
    public class Customer
    {

        private List<Account> _accounts;

        public List<Account> Accounts { get { return _accounts; } set { _accounts = value; } }

        public Customer() { }

        public string CreateSavingsAccount(string name)
        {
            throw new NotImplementedException();
        }

        public string CreateCurrentAccount(string name)
        {
            throw new NotImplementedException();
        }

        public string GenerateStatement()
        {
            throw new NotImplementedException();
        }

        public string Deposit(string account, decimal amount) 
        { 
            throw new NotImplementedException(); 
        }

        public string Withdraw(string account, decimal amount) 
        {  
            throw new NotImplementedException(); 
        }
    }
}
