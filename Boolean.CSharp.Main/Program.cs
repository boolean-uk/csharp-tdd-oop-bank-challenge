using Boolean.CSharp.Main.Persons;
using Boolean.CSharp.Main;

Bank bank = new Bank();
Customer customer = new Customer(bank, 32, "john");

string accountName = "Deposit account Test";

customer.CreateAccount(accountName);
customer.DepositToAccount(accountName, 1000);
customer.DepositToAccount(accountName, 2000);
customer.WithdrawFromAccount(accountName, 500);

customer.GetAccount(accountName).PrintBankStatement();