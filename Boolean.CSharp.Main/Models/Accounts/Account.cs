using System.Text;

namespace Boolean.CSharp.Main.Models.Accounts;

public class Account(string name, AccountType type)
{
    public string Name { get; } = name;
    public AccountType AccountType { get; } = type;
    public bool SmsNotification { get; set; } = false;
    private List<BankTransaction> BankTransactions { get; set; } = new();
    
    public List<BankTransaction> GetTransactions() => BankTransactions;

    public void PrintTransactions()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Transaction history for account {Name}:");
        sb.AppendLine($"date       || credit    || debit     || balance || comment");
        foreach (var t in BankTransactions)
        {
            var balance = GetBalance();
            sb.AppendLine($"{t._date:d/M/yy} || {(t._amount > 0 ? t._amount : 0)} || {(t._amount < 0 ? 0 : t._amount)} || {balance} || {t._description}");
        }
    }

    public decimal Deposit(decimal amount, string description = "")
    {
        BankTransactions.Add(new BankTransaction(DateTime.Now, amount, description));
        return GetBalance();
    }

    public decimal Withdraw(decimal amount, string description = "")
    {
        if (amount > 0) amount *= -1;
        BankTransactions.Add(new BankTransaction(DateTime.Now, amount, description));
        return GetBalance();
    }

    public decimal GetBalance()
    {
        return BankTransactions.Sum(x => x._amount);
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