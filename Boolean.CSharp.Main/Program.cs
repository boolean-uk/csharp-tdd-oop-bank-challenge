
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enum;

/*
savings.deposit(500);
savings.deposit(200);
savings.withdraw(100);

Console.WriteLine("");

savings.bankStatement();
*/

Bank bank = new Bank("DNB", 10000, new Branch("Bergen"), new Branch("Oslo"));

Branch Oslo = new Branch("Oslo");
Savings savings = new Savings(Oslo);

bank.createAccount(savings);

savings.deposit(500);
savings.deposit(200);
savings.withdraw(100);

Console.WriteLine(" \n CURRENTTTTT \n");

Current current = new Current(Oslo);

bank.createAccount(current);

current.deposit(1000);
current.deposit(1000);
current.withdraw(2000);

current.requestOverdraft(5000);

bank.decideOverdraft(current._requests.First(), Role.MANAGER, true);

current.deposit(500);

// current.bankStatement();

current.phoneMessage();
