using System.Text;

namespace Boolean.CSharp.Main
{
    public class Customer
    {

        private List<Account> _accounts;

        public List<Account> Accounts { get { return _accounts; } set { _accounts = value; } }

        public Customer() 
        {
            _accounts = new();
        }

        public string CreateSavingsAccount(string name)
        {
            if (Accounts.Where(n => n.Name == name).Count() == 0)
            {
                SavingsAccount savingsAccount = new(name, Branch.Norway);
                _accounts.Add(savingsAccount);
                return $"Savings account {name} has been created";
            }
            return $"Could not create account, {name} already exists";
        }

        public string CreateCurrentAccount(string name)
        {
            if (Accounts.Where(n => n.Name == name).Count() == 0)
            {
                CurrentAccount currentAccount = new(name, Branch.Norway);
                _accounts.Add(currentAccount);
                return $"Current account {name} has been created";
            }
            return $"Could not create account, {name} already exists";
        }

        public string GenerateStatement()
        {
            StringBuilder sb = new();
            foreach(Account account in Accounts) 
            { 
                sb.AppendLine(account.Name);
                sb.Append(account.GenerateStatement());
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public string Deposit(string account, decimal amount) 
        {
            Account depositAccount = _accounts.Find(a => a.Name == account)!;
            return depositAccount.Deposit(amount);
        }

        public string Withdraw(string account, decimal amount) 
        {  
            Account withdrawAccount = _accounts.Find(a => a.Name == account)!;
            return withdrawAccount.Withdraw(amount);
        }

    }
}
