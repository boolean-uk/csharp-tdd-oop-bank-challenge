using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Payloads;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class BankingApp
    {
        private bool running = true;
        public CustomerList customerList = new CustomerList();
        public AccountList accountList = new AccountList();

        public BankingApp()
        {
            customerList.OpenCustomerFile();
            accountList.LoadExistingAccounts();
            while (running)
            {
                Console.Clear();
                Welcome();
                Console.WriteLine("Enter choice:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "E":
                    case "e":
                        Console.Clear();
                        CredentialCheck();
                        break;
                    case "n":
                    case "N":
                        Console.Clear();
                        NewClient();
                        break;
                    case "Q":
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        Stop();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Try again...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            } 
        }

        private void Logo()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("             XXX    XXXXXX              ");
            Console.WriteLine("           XX   XX   XX   XX            ");
            Console.WriteLine("           XX   XX   XX    XX           ");
            Console.WriteLine("           XX        XX   XX            ");
            Console.WriteLine("             XXX     XXXXX              ");
            Console.WriteLine("                XX   XX   XX            ");
            Console.WriteLine("           XX   XX   XX    XX           ");
            Console.WriteLine("           XX   XX   XX   XX            ");
            Console.WriteLine("             XXX    XXXXXX              ");
            Console.WriteLine("----------------------------------------");
        }

        private void Welcome()
        {
            Logo();
            accountList.LoadExistingAccounts();
            Console.WriteLine("\nWelcome to Seguro Bank");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("E: Enter Credentials");
            Console.WriteLine("N: New Client");
            Console.WriteLine("Q: Quit");
            Console.WriteLine("----------------------------------------");
        }

        public void NewClient()
        {
            //OpenCustomerFile();
            Console.WriteLine("To create a new user, enter the following information:");
            Console.WriteLine("New username (firstname + lastname):");
            var TestNewUsername = Console.ReadLine();
            if (TestNewUsername.Length == 0 | TestNewUsername.Contains(",") ) //add that username cannot contain comma! 
            {
                Console.WriteLine("Username cannot be empty and cannot contain a comma. Try again:");
                TestNewUsername = Console.ReadLine();
            }
            var NewUsername = TestNewUsername.Trim(); //no spaces are stored

            Console.WriteLine("User address:");
            var TestNewAddress = Console.ReadLine();
            if (TestNewAddress.Length == 0 | TestNewAddress.Contains(",") )
            {
                Console.WriteLine("Address cannot be empty and cannot contain a comma. Try again:");
                TestNewUsername = Console.ReadLine();
            }
            var NewAddress = TestNewAddress;

            //Password creator & Customer registration:
            var PasswordCompleted = false;
            string NewPassword;
            string Password_1;
            string Password_2;
            int registrationattempts = 3;
            while (PasswordCompleted == false && registrationattempts > 0) 
            {
                Console.WriteLine("New password (minimum 4 characters):");
                registrationattempts--;
                Password_1 = GetHiddenPassword();
                if (Password_1.Length < 4 | Password_1.Length == 0)
                {
                    Console.WriteLine("Password must be at least 4 characters long. Try again.");
                    //Password_1 = GetHiddenPassword();
                }
                else if (Password_1.Length >= 4)
                {
                    Console.WriteLine("Verify password (passwords must match):");
                    Password_2 = GetHiddenPassword();
                    if (Password_1 == Password_2)
                    {
                        NewPassword = Password_1.Trim();
                        //Store new username + password as new customer
                        Customer newcustomer = new Customer(name: NewUsername, address: NewAddress, password: NewPassword);
                        //Add new customer to customerlist - check if user already exists:
                        customerList.AddNewCustomer(newcustomer);
                        PasswordCompleted = true;
                    }
                    else
                    {
                        Console.WriteLine("Passwords don't match. Re-enter new password.");
                    }
                }
            }
            if (registrationattempts == 0)
            {
                Console.Clear();
                Console.WriteLine("Registration failed.");
                Thread.Sleep(2000);
                Welcome();
            }
        }

        public static string GetHiddenPassword()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter) break;
                if (key.Key == ConsoleKey.Backspace && input.Length > 0) input.Remove(input.Length - 1, 1);
                else if (key.Key != ConsoleKey.Backspace) input.Append(key.KeyChar);
            }
            return input.ToString();
        }

        private void CredentialCheck()
        {
            Console.Clear();
            bool credentialCheckCompleted = false;
            int passwordAttempts = 3;
            string ProvidedUsername;
            string ProvidedPassword;

            while (credentialCheckCompleted == false && passwordAttempts > 0)
            {
                Console.WriteLine("Enter Username:");
                ProvidedUsername = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                ProvidedPassword = GetHiddenPassword();

                if (customerList.CheckPassword(ProvidedUsername, ProvidedPassword) == false)
                {
                    Console.WriteLine("This combination is not correct");
                    passwordAttempts--;
                    Console.WriteLine("Remaining attemps = "+ passwordAttempts);
                }
                else
                {
                    credentialCheckCompleted = true;
                    Console.WriteLine("Credentials accepted, welcome!");
                    PersonalAccount(ProvidedUsername);
                }
            }

            if (passwordAttempts == 0) 
            {
                Console.Clear();
                Console.WriteLine("Too many attempts. Security has been alerted. Goodbye.");
                Thread.Sleep(3000);
                Stop(); 
            }

        }

        private void PersonalAccount(string ProvidedUsername)
        {
            accountList.LoadExistingAccounts();    
            Console.Clear();
            Logo();
            Console.WriteLine("Welcome, " + ProvidedUsername);
            Console.WriteLine("This is your personal account page");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("A: Access your accounts and balances");
            Console.WriteLine("C: Create New Checking Account (max 1)");
            Console.WriteLine("S: Create New Savings Account (max 1)");
            Console.WriteLine("L: Log out");
            Console.WriteLine("Q: Quit and Exit Application");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Enter choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "A":
                case "a":
                    Console.Clear();
                    ViewAccounts(ProvidedUsername);
                    break;
                case "C":
                case "c":
                    Console.Clear();
                    CreateCheckingAccount(ProvidedUsername);
                    break;
                case "S":
                case "s":
                    Console.Clear();
                    CreateSavingsAccount(ProvidedUsername);
                    break;
                case "L": 
                case "l":
                    Console.Clear();
                    Welcome();
                    break;
                case "Q":
                case "q":
                    Console.Clear();
                    Console.WriteLine("Goodbye");
                    Stop();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Try again...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }
        }

        private void ViewAccounts(string ProvidedUsername)
        {
            accountList.LoadExistingAccounts();
            Console.Clear();
            if (accountList.CustomerHasAnyAccount(ProvidedUsername) == true)
            {
                Console.WriteLine("Your accounts:");
                accountList.ViewCustomerAccounts(ProvidedUsername);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("C: Checking Account");
                Console.WriteLine("S: Savings Account");
                Console.WriteLine("B: Back");
                Console.WriteLine("Q: Quit and Exit");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Enter choice:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "C":
                    case "c":
                        CheckingMenu(ProvidedUsername);
                        break;
                    case "S":
                    case "s":
                        SavingsMenu(ProvidedUsername);
                        break;
                    case "B":
                    case "b":
                        PersonalAccount(ProvidedUsername);
                        break;
                    case "Q":
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        Stop();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Try again...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
            else
            { 
            Console.WriteLine("There are no accounts registered for this customer.");
            Thread.Sleep(2500);
            Console.Clear();
            PersonalAccount(ProvidedUsername);       
            }
        }

        private void CheckingMenu(string ProvidedUsername)
        {
            accountList.LoadExistingAccounts();
            Console.Clear();
            if (accountList.AccessCheckingAccount(ProvidedUsername) == false)
            {
                Console.Clear();
                PersonalAccount(ProvidedUsername);
            }

            string AccountNumber = accountList.GetCheckingAccountNr(ProvidedUsername);
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("D: Deposit");
            Console.WriteLine("W: Withdraw");
            Console.WriteLine("T: Transaction History");
            Console.WriteLine("O: Overdraft Settings");
            Console.WriteLine("B: Back");
            Console.WriteLine("Q: Quit and Exit");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Enter choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "D":
                case "d":
                    DepositMenu(AccountNumber);
                    CheckingMenu(ProvidedUsername);
                    break;
                case "W":
                case "w":
                    WithdrawMenu(AccountNumber);
                    CheckingMenu(ProvidedUsername);
                    break;
                case "T":
                case "t":
                    accountList.ViewTransactionHistory(AccountNumber);
                    CheckingMenu(ProvidedUsername);
                    break;
                case "O":
                case "o":
                    OverdraftSettings(AccountNumber, ProvidedUsername);
                    CheckingMenu(ProvidedUsername);
                    break;
                case "B":
                case "b":
                    ViewAccounts(ProvidedUsername);
                    break;
                case "Q":
                case "q":
                    Console.Clear();
                    Console.WriteLine("Goodbye");
                    Stop();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Try again...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }

        }

        private void OverdraftSettings(string AccountNumber, string ProvidedUsername)
        {
            accountList.LoadExistingAccounts();
            Console.Clear();
            var currentaccount = accountList.allaccounts.Where(x => x.accountNumber == AccountNumber).FirstOrDefault();
            var floor = currentaccount.allowOverdraft;
            var accountType = currentaccount.accountType;
            Console.WriteLine("Overdraft Settings");
            Console.WriteLine("Checking Account: " + AccountNumber);
            Console.WriteLine("Your current allowed overdraft is: " + floor);
            Console.WriteLine("You can set up your own overdraft up to -1000.");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("E: Edit Overdraft");
            Console.WriteLine("B: Back");
            Console.WriteLine("Q: Quit and Exit");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Enter choice:");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "E":
                case "e":
                    Console.WriteLine("Enter New Overdraft Amount:");
                    string newfloor = Console.ReadLine();
                    accountList.ActivateOverdraft(currentaccount.accountNumber, newfloor, currentaccount.accountType);
                    CheckingMenu(ProvidedUsername);
                    break;
                case "B":
                case "b":
                    CheckingMenu(ProvidedUsername);
                    break;
                case "Q":
                case "q":
                    Console.Clear();
                    Console.WriteLine("Goodbye");
                    Stop();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Try again...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }
        }

        private void SavingsMenu(string ProvidedUsername)
        {
            accountList.LoadExistingAccounts();
            Console.Clear();
            if (accountList.AccessSavingsAccount(ProvidedUsername) == true)
            {
                string SavingsAccountNumber = accountList.GetSavingsAccountNr(ProvidedUsername);
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("D: Deposit");
                Console.WriteLine("W: Withdraw");
                Console.WriteLine("T: Transaction history");
                Console.WriteLine("B: Back");
                Console.WriteLine("Q: Quit and Exit");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Enter choice:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "D":
                    case "d":
                        DepositMenu(SavingsAccountNumber);
                        SavingsMenu(ProvidedUsername);
                        break;
                    case "W":
                    case "w":
                        WithdrawMenu(SavingsAccountNumber);
                        SavingsMenu(ProvidedUsername);
                        break;
                    case "T":
                    case "t":
                        accountList.ViewTransactionHistory(SavingsAccountNumber);
                        SavingsMenu(ProvidedUsername);
                        break;
                    case "B":
                    case "b":
                        ViewAccounts(ProvidedUsername);
                        break;
                    case "Q":
                    case "q":
                        Console.Clear();
                        Console.WriteLine("Goodbye");
                        Stop();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Try again...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }

            else
            {
                Console.Clear();
                PersonalAccount(ProvidedUsername);
            }



        }

        private void DepositMenu(string AccountNumber)
        {
            accountList.LoadExistingAccounts();
            Console.WriteLine("Enter the amount to deposit:");
            string deposit = Console.ReadLine();
            accountList.DepositAmount(AccountNumber, deposit);
        }

        private void WithdrawMenu(string AccountNumber) 
        {
            accountList.LoadExistingAccounts();
            Console.WriteLine("Enter the amount to withdraw:");
            string withdraw = Console.ReadLine();
            accountList.WithdrawAmount(AccountNumber, withdraw);
        }
        
        private void CreateCheckingAccount(string ProvidedUsername)
        {
            accountList.LoadExistingAccounts();
            if (accountList.CustomerHasCheckingAccount(ProvidedUsername) == false)
            {
                string accountNumber = AccountNumberGenerator();
                string accountType = "checking";
                float startBalanceFloat = 0;
                Console.WriteLine("Your new Checking Account will be created with the following details:");
                Thread.Sleep(1000);
                Console.WriteLine("Generated Accountnumber: " + accountNumber);
                Console.WriteLine("Account Type: " + accountType);
                Console.WriteLine("Username: " + ProvidedUsername);
                Console.WriteLine("Starting Balance: " + startBalanceFloat);
                CheckingAccount newCheckingAccount = new CheckingAccount(accountNumber, ProvidedUsername, startBalanceFloat, accountType);
                accountList.AddNewAccount(newCheckingAccount);
                PersonalAccount(ProvidedUsername);
            } else
            { 
                Console.WriteLine("You already have a checking account!");
                Thread.Sleep(2000);
                PersonalAccount(ProvidedUsername);
            }

        }

        private void CreateSavingsAccount(string ProvidedUsername) 
        {
            accountList.LoadExistingAccounts();
            if (accountList.CustomerHasSavingsAccount(ProvidedUsername) == false)
            {
                string accountNumber = AccountNumberGenerator();
                string accountType = "savings";
                Console.WriteLine("Your new Savings Account will be created with the following details:");
                Thread.Sleep(1000);
                Console.WriteLine("Generated Accountnumber: " + accountNumber);
                Console.WriteLine("Account Type: " + accountType);
                Console.WriteLine("Username: " + ProvidedUsername);
                Console.WriteLine("Opening a Savings Account requires a deposit. \nPlease enter the amount (numbers only):");
                var deposit = float.TryParse(Console.ReadLine(), out float result);
                float startBalanceFloat = result;
                Console.WriteLine("Starting Balance: " + startBalanceFloat);
                SavingsAccount newSavingsAccount = new SavingsAccount(accountNumber, ProvidedUsername, startBalanceFloat, accountType);
                accountList.AddNewAccount(newSavingsAccount);
                PersonalAccount(ProvidedUsername);
            }
            else
            {
                Console.WriteLine("You already have a savings account!");
                Thread.Sleep(2000);
                PersonalAccount(ProvidedUsername);
            }
        }

        public string AccountNumberGenerator()
        {
            accountList.LoadExistingAccounts();
            var rnd = new Random();
            var stringbuilder = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                int randInt = rnd.Next(1, 9);
                stringbuilder.Append(randInt);
            }
            return stringbuilder.ToString();
        }

        private void Stop()
        {
            running = false;
            accountList.LoadExistingAccounts();
            accountList.WriteAccountstoFile();
        }
    }
}
