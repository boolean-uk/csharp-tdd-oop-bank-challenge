using Boolean.CSharp.Main.AccountType;

namespace Boolean.CSharp.Test
{
    public class Customer
    {
        public List<IAccount> accounts { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public Bank bank { get; set; }

        public Customer(string name, Bank bank) {
            this.CustomerId = Guid.NewGuid();
            this.Name = name;
            this.bank = bank;
        }

        public double Deposit(IAccount account, double amount)
        {
            // TODO
            return account.balance;
        }

        public double Withdraw(IAccount account, double amount)
        {
            // TODO
            return account.balance;
        }
    }
}