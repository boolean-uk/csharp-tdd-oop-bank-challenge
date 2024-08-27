using System.Text;

namespace Boolean.CSharp.Main.Models.Accounts;

public abstract class Account(Customer customer, string name, AccountType type)
{
    public string Name { get; } = name;
    public AccountType AccountType { get; } = type;
    public bool SmsNotification { get; private set; } = false;
    public List<BankTransaction> BankTransactions { get; } = new();
    
    public List<BankTransaction> GetTransactions() => BankTransactions;

    public void PrintTransactions()
    {
        StringBuilder sb = new();
        var currentBalance = 0m;
        sb.AppendLine($"Transaction history for account {Name}:");
        sb.AppendLine($"date    || credit  || debit   || balance || comment");
        foreach (var t in BankTransactions)
        {
            currentBalance += t.Amount;
            var date = t.Date.ToString("d/M/yy");
            var deposit = t.Amount > 0 ? t.Amount.ToString() : "0";
            var withdraw = t.Amount < 0 ? t.Amount.ToString() : "0";
            var desc = t.Description;
            sb.AppendLine($"{date.PadRight(7)} || {deposit.PadRight(7)} || {withdraw.PadRight(7)} || {currentBalance.ToString().PadRight(7)} || {desc}");
        }
        Console.WriteLine(sb.ToString());
    }

    public bool Deposit(decimal amount, string description = "")
    {
        BankTransactions.Add(new BankTransaction(DateTime.Now, amount, description));
        return true;
    }

    public bool Withdraw(decimal amount, string description = "")
    {
        if (amount > 0) amount *= -1;
        BankTransaction bt = new(DateTime.Now, amount, description);
        var newBalance = GetBalance() + amount;
        if (!(newBalance >= 0))
        {
            Overdraft.NewOverdraftRequest(customer, this, bt, newBalance);
            return false;
        }
        BankTransactions.Add(bt);
        return true;
    }

    public decimal GetBalance()
    {
        return BankTransactions.Sum(x => x.Amount);
    }

    public void ToggleSmsNotification()
    {
        SmsNotification = !SmsNotification;
    }
}

public enum AccountType
{
    Spending,
    Saving,
    Credit
}