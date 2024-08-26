
using Boolean.CSharp.Main;
using Boolean.CSharp.Main.Accounts;

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

Current current = new Current(Oslo);

bank.createAccount(current);
