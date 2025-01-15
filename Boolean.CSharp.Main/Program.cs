// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Communication;
using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;

Bank bank = new Bank();

Customer customer = new Customer("John");

bank.AddCustomer(customer);

IAccount account = customer.CreateAccount(AccountType.Current, Branch.Oslo, "John's Current Account");

//account.Deposit(1000);
//account.Withdraw(500);
//account.Deposit(2000);

ConsoleCommunicator consoleCommunicator = new ConsoleCommunicator();
//SMSCommunicator smsCommunicator = new SMSCommunicator();

//account.sendBankStatement(consoleCommunicator);

//Small console app to test the bank account and have it interactive

Console.WriteLine("Welcome to the bank");

Role role;
Console.WriteLine("Are you a customer or a manager?");
Console.WriteLine("1. Customer");
Console.WriteLine("2. Manager");
string roleInput = Console.ReadLine();
if (roleInput == "1")
{
    role = Role.Customer;
}
else
{
    role = Role.Manager;
}

Console.WriteLine("What is your name?");
string name = Console.ReadLine();
Customer newCustomer = new Customer(name);
bank.AddCustomer(newCustomer);
Console.Clear();
Console.WriteLine("Hello " + name + "! You are logged in as a " + role.ToString());

bool isRunning = true;
while (isRunning)
{
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("---------------------------");
    Console.WriteLine("1. Create account");
    Console.WriteLine("2. Select account");
    Console.WriteLine("3. Exit");

    string input = Console.ReadLine();

    if (input == "1")
    {
        Console.Clear();
        Console.WriteLine("Creating account");
        Console.WriteLine("Do you wish to create a current or a savings account?");
        Console.WriteLine("1. Current account");
        Console.WriteLine("2. Savings account");
        string accountTypeInput = Console.ReadLine();
        AccountType accountType;
        if (accountTypeInput == "1")
        {
            accountType = AccountType.Current;
        }
        else
        {
            accountType = AccountType.Savings;
        }
        Console.Clear();
        Console.WriteLine("Creating " + account.ToString() + " account");
        Console.WriteLine("What branch do you want to create the account in?");
        Console.WriteLine("1. Oslo");
        Console.WriteLine("2. Trondheim");
        string branchInput = Console.ReadLine();
        Branch branch;
        if (branchInput == "1")
        {
            branch = Branch.Oslo;
        }
        else
        {
            branch = Branch.Trondheim;
        }

        Console.Clear();
        Console.WriteLine("Creating " + account.ToString() + " account in " + branch.ToString());
        string accountName = null;
        while (accountName == null)
        {
            Console.WriteLine("What is the name of the account?");
            accountName = Console.ReadLine();
        }
        newCustomer.CreateAccount(accountType, branch, accountName);
        accountName = null;
        Console.Clear();
        Console.WriteLine("Account created successfuly!");
        System.Threading.Thread.Sleep(1000);
    } else if (input == "2")
    {
        if (customer.Accounts.Count == 0)
        {
            Console.WriteLine("You have no accounts");
            System.Threading.Thread.Sleep(1000);
            continue;
        }
        else
        {
            Console.Clear();
            if(newCustomer.Accounts.Count == 0)
            {
                Console.WriteLine("You have no accounts");
                System.Threading.Thread.Sleep(1000);
                continue;
            }
            Console.WriteLine("Select account");
            Console.WriteLine("---------------------------");
            for (int i = 0; i < newCustomer.Accounts.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + newCustomer.Accounts[i].AccountName);
            }
            string accountInput = Console.ReadLine();
            int accountIndex = int.Parse(accountInput) - 1;
            IAccount selectedAccount = newCustomer.Accounts[accountIndex];
            Console.Clear();
            Console.WriteLine("Selected account: " + selectedAccount.AccountName);
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("---------------------------");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Request overdraft");
            Console.WriteLine("4. Get balance");
            Console.WriteLine("5. Create bank statement");
            string accountActionInput = Console.ReadLine();
            if (accountActionInput == "1")
            {
                Console.Clear();
                Console.WriteLine("How much would you like to deposit?");
                string depositInput = Console.ReadLine();
                decimal depositAmount = decimal.Parse(depositInput);
                selectedAccount.Deposit(depositAmount);
                Console.Clear();
                Console.WriteLine("Deposit successful!");
                System.Threading.Thread.Sleep(1000);
            }
            else if (accountActionInput == "2")
            {
                Console.Clear();
                Console.WriteLine("How much would you like to withdraw?");
                string withdrawInput = Console.ReadLine();
                decimal withdrawAmount = decimal.Parse(withdrawInput);
                selectedAccount.Withdraw(withdrawAmount);
                Console.Clear();
                Console.WriteLine("Withdrawal successful!");
                System.Threading.Thread.Sleep(1000);
            }
            else if (accountActionInput == "3")
            {
                Console.Clear();
                Console.WriteLine("How much would you like to request?");
                string requestInput = Console.ReadLine();
                decimal requestAmount = decimal.Parse(requestInput);
                selectedAccount.RequestOverdraft(requestAmount);
                Console.Clear();
                Console.WriteLine("Request successful!");
                System.Threading.Thread.Sleep(1000);
            }
            else if (accountActionInput == "4")
            {
                Console.Clear();
                Console.WriteLine("Balance: " + selectedAccount.GetBalance());
                System.Threading.Thread.Sleep(1000);
            }
            else if (accountActionInput == "5")
            {
                Console.Clear();
                selectedAccount.sendBankStatement(consoleCommunicator);
                Console.WriteLine("Bank statement created!");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
    else { isRunning = false; }
}