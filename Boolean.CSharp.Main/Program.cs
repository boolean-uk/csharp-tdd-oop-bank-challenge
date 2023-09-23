using Boolean.CSharp.Main;
using System.Globalization;

var account = new Account("Main Branch");

account.Deposit(1000, new DateTime(2012, 01, 11));
account.Deposit(2000, new DateTime(2012, 01, 13));
account.Withdraw(500, new DateTime(2012, 01, 15));

PrintBankStatement(account.GenerateStatement());

static void PrintBankStatement(BankStatement statement)
{
    Console.WriteLine("Date       || Credit  ||  Debit  || Balance ||");

    var sortedTransactions = statement.Transactions.OrderByDescending(t => t.Date);

    foreach (var transaction in sortedTransactions)
    {
        var date = transaction.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        var credit = transaction.IsDeposit ? transaction.Amount.ToString("F2") : "      ";
        var debit = transaction.IsDeposit ? "     " : transaction.Amount.ToString("F2");
        var balance = transaction.Balance.ToString("F2");

        Console.WriteLine($"{date} || {credit,7} || {debit,7} || {balance,7} ||");
    }
}