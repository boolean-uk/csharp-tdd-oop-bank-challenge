namespace Boolean.CSharp.Main
{
    public class Bank
    {
        private List<Customer> customers;
        private List<Branch> branches;

        public Bank()
        {
            this.customers = new List<Customer>();
            this.branches = new List<Branch>();
            // Initialize with a default branch
            this.branches.Add(new Branch("Default Branch", "Default Address"));
        }

        public void addCustomer(Customer customer)
        {
            this.customers.Add(customer);
        }

        public void addBranch(Branch branch)
        {
            this.branches.Add(branch);
        }

        private Branch findBranchByName(string branchName)
        {
            foreach (Branch branch in branches)
            {
                if (branch.getName().Equals(branchName, StringComparison.OrdinalIgnoreCase))
                {
                    return branch;
                }
            }
            return null;
        }

        public bool createAccount(int customerId, string accountType, double initialAmount, string branchName)
        {
            Customer customer = findCustomerById(customerId);
            Branch branch = findBranchByName(branchName);
            if (customer != null && branch != null)
            {
                Account newAccount = new Account(accountType, initialAmount, branch);
                customer.addAccount(newAccount); // Add to customer's account list
                branch.addAccount(newAccount); // Add to branch's account list
                return true;
            }
            return false;
        }

        public bool deposit(int customerId, int accountNumber, double amount)
        {
            Customer customer = findCustomerById(customerId);
            if (customer != null)
            {
                Account account = customer.getAccount(accountNumber);
                if (account != null)
                {
                    Transaction transaction = new Transaction(DateTime.Now, amount, account.calculateBalance() + amount, "Credit");
                    account.addTransaction(transaction);
                    return true;
                }
            }
            return false;
        }

        public bool withdraw(int customerId, int accountNumber, double amount)
        {
            Customer customer = findCustomerById(customerId);
            if (customer == null)
            {
                return false;
            }
            Account account = customer.getAccount(accountNumber);
            double currentBalance = account.calculateBalance();
            if (currentBalance >= amount)
            {
                Transaction transaction = new Transaction(DateTime.Now, amount, currentBalance - amount, "Debit");
                account.addTransaction(transaction);
                return true;
            }
            return false;
        }

        public void printBankStatement(int customerId, int accountNumber)
        {
            Customer customer = findCustomerById(customerId);
            if (customer != null)
            {
                Account account = customer.getAccount(accountNumber);
                if (account != null)
                {
                    foreach (Transaction transaction in account.getTransactionHistory())
                    {
                        Console.WriteLine(
                                "Date: " + transaction.getData().Day + "/" +
                                        transaction.getData().Month + "/" +
                                        transaction.getData().Year + "\nTime: " +
                                        transaction.getData().Hour + ":" +
                                        transaction.getData().Minute + ":" +
                                        transaction.getData().Second + "\n" +
                                        transaction.getDebitOrCredit() + ": " + transaction.getAmount() + "\n" +
                                        "Balance: " + transaction.getCurrentBalance() + "\n"
                        );
                    }
                    Console.WriteLine("Current Balance: " + account.calculateBalance());
                }
            }
        }

        public Customer findCustomerById(int customerId)
        {
            foreach (Customer customer in customers)
            {
                if (customer.getId() == customerId)
                {
                    return customer;
                }
            }
            return null;
        }
    }
}
