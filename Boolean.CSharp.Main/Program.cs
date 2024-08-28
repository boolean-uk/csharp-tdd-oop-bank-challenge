using Boolean.CSharp.Test;

SavingsAccount savingsAccount = new(500);
savingsAccount.Deposit(543);
savingsAccount.Withdraw(200);

//run
Console.WriteLine(savingsAccount.GetStatement());