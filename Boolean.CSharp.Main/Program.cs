// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main.Acounts;
using Boolean.CSharp.Main.Extensions;
Console.WriteLine("Hello, World!");

Bank bank = new Bank("DNB", 10000);
Person avgjoe = new Person("Flier", Boolean.CSharp.Main.Role.CUSTOMER, null);
Person manager = new Person("Big Dawg", Boolean.CSharp.Main.Role.MANAGER, bank);
SavingsAccount savings = new SavingsAccount();
avgjoe.addAccount(savings);


savings.Deposit(1000);
savings.Deposit(2000);
savings.Deposit(2000);
savings.RequestOverdraft(6000);

manager.answerOverdraft(savings.OverdraftRequests.First());
Console.WriteLine(bank.moneyLeftInFund());
Console.WriteLine(savings.printStatement());

savings.RequestOverdraft(10000);
manager.answerOverdraft(savings.OverdraftRequests.First());
Console.WriteLine(bank.moneyLeftInFund());
Console.WriteLine(savings.printStatement());
