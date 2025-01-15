using Boolean.CSharp.Main.AccountType;

namespace Boolean.CSharp.Test
{
    public class Bank
    {
        public List<Customer> CustomerList { get; set; }
        public List<IAccount> Accounts { get; set; }

        public Bank()
        {
            CustomerList = new List<Customer>();
            Accounts = new List<IAccount>();
        }

        public IAccount CreateAccount(Customer customer, string type)
        {
            // TODO
            return new SavingsAccount(new Customer("John"));
        }

        public Customer FindOrCreateCustomer(Customer customer)
        {
            // TODO
            return new Customer("John");
        }
    }
}