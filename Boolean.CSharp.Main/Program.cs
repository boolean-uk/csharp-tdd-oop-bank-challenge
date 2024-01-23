// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Bank;
using Boolean.CSharp.Main.Interfaces;

Console.WriteLine("Hello, World!");

string firstname = "clark";
string lastname = "julie";
string dob = "jan 1, 2009";
DateTime _dob = DateTime.Parse(dob);
Customer customer = new Customer(firstname, lastname, _dob);
Bank bank = new Bank();
Guid guid = new Guid();
bool createAccount = bank.CreateSavingsAccount(customer, out guid);

bank.Deposit(guid, 2000, customer);
ITransaction account = bank.accountDirectory[customer][guid]._transactions.First();
//Console.WriteLine($"amount: {account._amount}, balance: {account._balance}, date: {account._dateTime.ToString()}");
Account a = bank.accountDirectory[customer][guid];
a.TransactionStatement();