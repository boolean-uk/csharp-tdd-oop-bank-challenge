using System.Text;

namespace Boolean.CSharp.Main.Models.Accounts;

public class Account(string name, AccountType type)
{
    public string Name { get; } = name;
    public AccountType AccountType { get; } = type;
    public bool SmsNotification { get; private set; } = false;
    private List<BankTransaction> BankTransactions { get; } = new();
    
    public List<BankTransaction> GetTransactions() => BankTransactions;

    public void PrintTransactions()
    {
        StringBuilder sb = new();
        var currentBalance = 0m;
        sb.AppendLine($"Transaction history for account {Name}:");
        sb.AppendLine($"date    || credit  || debit   || balance || comment");
        foreach (var t in BankTransactions)
        {
            currentBalance += t._amount;
            var date = t._date.ToString("d/M/yy");
            var deposit = t._amount > 0 ? t._amount.ToString() : "0";
            var withdraw = t._amount < 0 ? t._amount.ToString() : "0";
            var desc = t._description;
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
        var overdraft = GetOverdraft();
        if (!(GetBalance() + amount > overdraft)) return false;
        BankTransactions.Add(new BankTransaction(DateTime.Now, amount, description));
        return true;
    }

    private decimal GetOverdraft()
    {
        return Overdraft.ApprovedOverdrafts.GetValueOrDefault(this, 0);
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