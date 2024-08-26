// Arrange
using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Interfaces;
using System.Xml.Linq;

Bank bank = new Bank();
bank.bankName = "Min Bank 1";


Bank.accounts = new List<IAccount>();
Bank.requestQueue = new List<Request>();
Bank.requestQueue.Clear();
RegularAccount account = new RegularAccount();
string receiver = "Alan Wake";
account.Create("Regular", receiver);
Bank.accounts.Add(account);
decimal amountToIncrease = 100m;

// Act
Bank.requestQueue.Clear();
Console.WriteLine($"Account hash before RequestOverdraft: {account.GetHashCode()}");

account.RequestOverdraft(receiver, "can't pay bills", amountToIncrease);
Console.WriteLine($"Overdrafted status after request: {account.overdrafted}");
Console.WriteLine($"Request Queue Count after request: {Bank.requestQueue.Count()}");

// Print the contents of the request queue for verification
foreach (var req in Bank.requestQueue)
{
    Console.WriteLine($"Request in queue: {req.name}, {req.amount}");
}

// Handle the request
bank.handleRequest(receiver, true);

Console.WriteLine($"Overdrafted status after handle: {account.overdrafted}");
Console.WriteLine($"Request Queue Count after handle: {Bank.requestQueue.Count()}");

// Verify the account reference again
Console.WriteLine($"Account hash after HandleRequest: {account.GetHashCode()}");

RegularAccount accountAfter = Bank.accounts?.OfType<RegularAccount>().FirstOrDefault(x => x.AccountHolderName == receiver);
Console.WriteLine("Regetting account" + account.AccountHolderName);
Console.WriteLine("Status after everything = " + accountAfter.overdrafted);

