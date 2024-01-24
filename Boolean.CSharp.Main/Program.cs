// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Accounts.Constants;
using Boolean.CSharp.Main.Users;
using NUnit.Framework;

Console.WriteLine("Hello, World!");

BankApplication bankApp = new BankApplication();

// Initialize a custmmer
 Custommer custommer1 = new Custommer()
{
    Name = "Kanthee",
    Branch = Branches.Bergen,
    Id = 1111
};
bankApp.Add(custommer1);

// Making a current account
custommer1.makeAccount(Enums.Current);

// Making 3 transactions:
double amount1 = 999.0;
TransactionType type1 = TransactionType.Deposit;
String mark1 = "Saving1 01/01/24";

double amount2 = 555.0;
TransactionType type2 = TransactionType.Withdraw;
String mark2 = "Deposit1 01/01/24";

double amount3 = 5556.0;
TransactionType type3 = TransactionType.Deposit;
String mark3 = "Saving2 01/01/24";


Guid acc = custommer1.getAccAccounts().Keys.First();

//Adding the transactions:
Transaction transaction1 = new Transaction() { Amount = amount1, Type = type1, Mark = mark1 };
custommer1.PerformTransaction(acc, transaction1);
Transaction transaction2 = new Transaction() { Amount = amount2, Type = type2, Mark = mark2 };
custommer1.PerformTransaction(acc, transaction2);
Transaction transaction3 = new Transaction() { Amount = amount3, Type = type3, Mark = mark3 };
custommer1.PerformTransaction(acc, transaction3);



IAccount accc = custommer1.getAccAccounts()[acc];
// Write the statement to the console:
accc.writeStatement();


//Testing adding request:
double amount4 = 100000.00;
TransactionType type4 = TransactionType.Overdraft;
String mark4 = "Request some money for my son! PLEASE!";
Transaction request4 = new Transaction() { Amount = amount4, Mark = mark4, Type = type4 };

double amount5 = 100000.00;
TransactionType type5 = TransactionType.Overdraft;
String mark5 = "Request some money for my MOM! PLEASE!";
Transaction request5 = new Transaction() { Amount = amount5, Mark = mark5, Type = type5 };


Guid acc1 = custommer1.getAccAccounts().Keys.First();
custommer1.PerformTransaction(acc1, request4);
custommer1.PerformTransaction(acc1, request5);
Account account1 = (Account)custommer1.getAccAccounts()[acc1];

// Testing review request:
//account1._accountManager.reviewRequest();

// Sending the statement the my phone:
Message message = new Message(account1);
message.Send();