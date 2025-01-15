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

        public IAccount CreateAccount(Customer customer, char type)
        {
            if(type == 's')
            {
                SavingsAccount newAccount = new SavingsAccount(customer);
                customer.accounts.Add(newAccount);
                Accounts.Add(newAccount);
                return newAccount;
            }
            else if(type == 'c')
            {
                CurrentAccount newAccount = new CurrentAccount(customer);
                customer.accounts.Add(newAccount);
                Accounts.Add(newAccount);
                return newAccount;

            } else {
                throw new InvalidDataException("Type (char) is not valid");
            }
        }

        /*
        public Customer FindOrCreateCustomer(Customer customer)
        {
            // TODO
            return new Customer("John", this);
        }
        */
    }
}