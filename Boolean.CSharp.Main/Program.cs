// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Communication;
using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;

Bank bank = new Bank();

Customer customer = new Customer("John");

bank.AddCustomer(customer);

IAccount account = customer.CreateAccount(AccountType.Current, Branch.Oslo, "John's Current Account");

account.Deposit(1000);
account.Withdraw(500);
account.Deposit(2000);

ConsoleCommunicator consoleCommunicator = new ConsoleCommunicator();
//SMSCommunicator smsCommunicator = new SMSCommunicator();

account.sendBankStatement(consoleCommunicator);


