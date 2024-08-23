namespace Boolean.CSharp.Main.Models;

public class BankTransaction(DateTime date, decimal amount, string description)
{
    public DateTime _date { get; set; } = date;
    public decimal _amount { get; set; } = amount;
    public string _description { get; set; } = description;
}