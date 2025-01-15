using Boolean.CSharp.Main.AccountType;

namespace Boolean.CSharp.Test
{
    public class Customer
    {
        public List<IAccount> accounts { get; set; }
        public Guid customerId { get; set; }
        public string name { get; set; }
        public Bank bank { get; set; }

        public Customer(string name, Bank bank) {
            this.customerId = Guid.NewGuid();
            this.accounts = new List<IAccount>();
            this.name = name;
            this.bank = bank;
        }

        public double Deposit(IAccount account, double amount)
        {
            return account.deposit(amount);
        }

        public double Withdraw(IAccount account, double amount)
        {
            return account.withdraw(amount);
        }
    }
}