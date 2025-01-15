
namespace Boolean.CSharp.Main
{
    public class Customer
    {
        private int id;
        private string firstName;
        private string lastName;
        private Dictionary<int, Account> accounts;
        private int nextAccountNumber;

        public Customer(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.accounts = new Dictionary<int, Account>();
            this.nextAccountNumber = 1; // Start account numbering from 1
        }

        public void addAccount(Account account)
        {
            accounts.Add(nextAccountNumber++, account);
        }

        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getFirstName()
        {
            return firstName;
        }

        public void setFirstName(String firstName)
        {
            this.firstName = firstName;
        }

        public String getLastName()
        {
            return lastName;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public Dictionary<int, Account> getAccounts()
        {
            return accounts;
        }

        public void setAccounts(Dictionary<int, Account> accounts)
        {
            this.accounts = accounts;
        }

        public int getNextAccountNumber()
        {
            return nextAccountNumber;
        }

        public void setNextAccountNumber(int nextAccountNumber)
        {
            this.nextAccountNumber = nextAccountNumber;
        }
        public Account getAccount(int accountNumber)
        {
            return accounts[accountNumber];
        }

    }
}
