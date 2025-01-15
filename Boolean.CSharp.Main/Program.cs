// Arrange
using Boolean.CSharp.Main.Classes;
using Boolean.CSharp.Main.Interfaces;
using System.Xml.Linq;

Bank bank = new Bank();
bank.bankName = "Min Bank 1";


Bank.accounts = new List<IAccount>();
Bank.requestQueue = new List<Request>();
Bank.requestQueue.Clear();
Statement state = new Statement();
RegularAccount account = new RegularAccount();
SavingsAccount savingsAccount = new SavingsAccount();
string person1 = "Alan Wake";
account.Create("Regular", person1);
Bank.accounts.Add(account);
string person2 = "John Johnson";
savingsAccount.Create("Savings", person2);
Bank.accounts.Add(savingsAccount);

foreach (var item in Bank.accounts)
{
    Console.WriteLine(item.AccountHolderName);
}


// Act
var person1Account = Bank.accounts.OfType<RegularAccount>().FirstOrDefault(x => x.AccountHolderName == person1);
account.deposit(500, person1);
account.withdraw(300, person1);
account.deposit(150, person1);
Console.Write(state.PrintFormatted(person1Account.transactionList));
