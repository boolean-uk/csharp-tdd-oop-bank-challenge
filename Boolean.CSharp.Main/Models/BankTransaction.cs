namespace Boolean.CSharp.Main.Models;

public class BankTransaction(DateTime date, decimal amount, string description)
{
    public DateTime Date { get; } = date;
    public decimal Amount { get; } = amount;
    public string Description { get; } = description;
}