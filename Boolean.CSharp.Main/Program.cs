

using Boolean.CSharp.Main;

Account account = new CurrentAccount();
account.Deposit(1000, TransactionType.Deposit);
account.Deposit(2000, TransactionType.Deposit);
account.Withdraw(500, TransactionType.Withdraw);

foreach (var i in account.Transactions)
{
    Console.WriteLine($"{i.TransactionType} {i.Amount} - New Balance: {i.Balance}");
}

Console.WriteLine();

account.GenerateBankStatement();



