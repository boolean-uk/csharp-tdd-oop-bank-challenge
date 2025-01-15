// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Console.WriteLine("Hello, World!");

Bank bank = new Bank();

Customer customer = new Customer(1, "Harry", "Potter");
bank.addCustomer(customer);

Branch osloBranch = new Branch("Oslo", "Oslo Address");
bank.addBranch(osloBranch);

// Creating an account associated with the Oslo branch
bank.createAccount(1, "Saving Account", 500.0, "Oslo");
int accountNumberForDeposit = 1;

// Perform multiple deposits
bank.deposit(1, accountNumberForDeposit, 100.0);
bank.deposit(1, accountNumberForDeposit, 100.0);
bank.deposit(1, accountNumberForDeposit, 100.0);
bank.deposit(1, accountNumberForDeposit, 100.0);
bank.deposit(1, accountNumberForDeposit, 100.0);

// Performs a withdrawal
bank.withdraw(1, accountNumberForDeposit, 100.0);

// Performs a withdrawal
bank.withdraw(1, accountNumberForDeposit, 1000.0);

// Prints the bank statement for the account
bank.printBankStatement(1, accountNumberForDeposit);