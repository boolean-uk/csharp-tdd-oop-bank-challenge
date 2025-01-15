using System;
using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Services;

namespace Boolean.CSharp.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a bank
            Console.WriteLine("Creating a bank...");
            Bank bank = new Bank("Experis Bank", "Bergen Branch");

            // Create a customer with branch information
            Console.WriteLine("\nCreating a customer with branch information...");
            Customer customer = new Customer("Jone", "Hjorteland", "jonehjorteland@experis.no", "Vestre Strømkaien 13, 5008 Bergen", bank);

            // Create a savings account for the customer in the bank's branch
            Console.WriteLine("\nCreating a savings account for the customer...");
            customer.CreateAccount("Savings");

            // Create a current account for the customer in the bank's branch
            Console.WriteLine("\nCreating a current account for the customer...");
            customer.CreateAccount("Current");

            // Get the savings and current account
            Account savingsAccount = customer.Accounts.Find(a => a.AccountType == "Savings");
            Account currentAccount = customer.Accounts.Find(a => a.AccountType == "Current");

            // Perform 5 random deposits and withdrawals on the savings account
            Random rand = new Random();
            int n = 5;
            Console.WriteLine("\nPerforming random deposits and withdrawals on the savings account...");
            for (int i = 0; i < n; i++)
            {
                decimal depositAmount = (decimal)(rand.NextDouble() * 1000); // Random deposit amount
                decimal withdrawAmount = (decimal)((decimal)rand.NextDouble() * depositAmount); // Random withdrawal amount (no more than the deposit amount)

                // Deposit and withdraw on savings account
                savingsAccount.Deposit(depositAmount);
                savingsAccount.Withdraw(withdrawAmount);
            }

            // Perform 5 random deposits and withdrawals on the current account
            Console.WriteLine("\nPerforming random deposits and withdrawals on the current account...");
            for (int i = 0; i < n; i++)
            {
                decimal depositAmount = (decimal)(rand.NextDouble() * 1000); // Random deposit amount
                decimal withdrawAmount = (decimal)((decimal)rand.NextDouble() * depositAmount); // Random withdrawal amount (no more than the deposit amount)

                // Deposit and withdraw on current account
                currentAccount.Deposit(depositAmount);
                currentAccount.Withdraw(withdrawAmount);
            }

            // Display account details for both savings and current accounts
            Console.WriteLine("\nDisplaying account details for both savings and current accounts...");
            savingsAccount.DisplayAccountDetails();
            currentAccount.DisplayAccountDetails();

            // Generate bank statements for both savings and current accounts
            Console.WriteLine("\nGenerating bank statements for both savings and current accounts...");
            savingsAccount.GenerateStatement();
            currentAccount.GenerateStatement();

            // Balance calculated from transaction history
            Console.WriteLine("\nBalances calculated from transaction history:");
            Console.WriteLine($"Savings Account Balance: {savingsAccount.GetBalance():C}");
            Console.WriteLine($"Current Account Balance: {currentAccount.GetBalance():C}");

            // Request an overdraft
            Console.WriteLine("\nRequesting an overdraft...");
            OverdraftRequest overdraftRequest = savingsAccount.RequestOverdraft(2000M);
            Console.WriteLine($"Overdraft requested for {overdraftRequest.GetAmount():C} on {savingsAccount.AccountType} account.");

            // Approve or reject overdraft
            Console.WriteLine("\nManager processes overdraft request...");
            Manager manager = new Manager("John", "Smith", "john.smith@experis.no", "Vestre Strømkaien 13", bank);
            manager.ProcessOverdraftRequest(overdraftRequest, true); // Overdraft approved

            // Display account details and transaction after overdraft
            Console.WriteLine("\nDisplaying account details and transaction after overdraft...");
            savingsAccount.DisplayAccountDetails();
            savingsAccount.GenerateStatement();

            // Demonstrate withdrawing using overdraft
            Console.WriteLine("\nAttempting to withdraw beyond balance after overdraft approval...");
            try
            {
                savingsAccount.Withdraw(savingsAccount.GetBalance() + 1500m); // Withdraw more than the balance, within overdraft limit
                Console.WriteLine("Withdrawal successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Withdrawal failed: {ex.Message}");
            }

            // Verify balance after overdraft withdrawal
            Console.WriteLine($"\nSavings Account Balance after overdraft withdrawal: {savingsAccount.GetBalance():C}");
            savingsAccount.GenerateStatement();

            // Send the statement to the customer's phone
            MessageService messageService = new MessageService();
            messageService.SendStatementToPhone(savingsAccount, "123-456-7890");
        }
    }
}
