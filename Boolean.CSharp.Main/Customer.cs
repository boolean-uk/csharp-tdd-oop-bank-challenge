using Boolean.CSharp.Main;
using Boolean.CSharp.Main.AccountType;

namespace Boolean.CSharp.Test
{
    public class Customer
    {
        public List<IAccount> accounts { get; set; }
        public Guid customerId { get; set; }
        public string name { get; set; }
        public Branch branch { get; set; }

        public Customer(string name, Branch branch) {
            this.customerId = Guid.NewGuid();
            this.accounts = new List<IAccount>();
            this.name = name;
            this.branch = branch;
        }

        public double Deposit(IAccount account, double amount)
        {
            return account.deposit(amount);
        }

        public double Withdraw(IAccount account, double amount)
        {
            return account.withdraw(amount);
        }

        public bool RequestOverdraftOnAccount(IAccount account)
        {
            if((account is SavingsAccount))
            {
                return false;
            }
            branch.OverdraftRequests.Add((CurrentAccount)account);
            return true;
        }
    }
}