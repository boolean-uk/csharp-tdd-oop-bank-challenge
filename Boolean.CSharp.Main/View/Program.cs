// See https://aka.ms/new-console-template for more information
using Boolean.CSharp.Main;

Bank bank = new Bank();

Branch branch = new Branch("Sweden", 23423);
PersonalAccount p = new PersonalAccount(branch);
bank.AddAccount(p);
p.Deposit(500);
p.Withdrawl(20);
p.Withdrawl(66);


Transaction t = bank.RequestOverdraft(p, 1000);
Signature s = new Signature(true);

bank.ApproveOverdraft(s,t);
p.Withdrawl(600);

Console.WriteLine(p.PrintReceipt());


Guid d = Guid.NewGuid();

Console.WriteLine(d.ToString());