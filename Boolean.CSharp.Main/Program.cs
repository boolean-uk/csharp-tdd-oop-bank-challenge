// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
Customer customer = new Customer();


Console.WriteLine("Hello, World!");
List<string> history = new List<string>();

customer.CreateAccount("123");


Account account = customer.MyBankAccounts["123"];
account.DepositMoney(1000d);

account.WithdrawMoney(500d);

account.DepositMoney(250d);


history = account.GetTransactionHistory();
