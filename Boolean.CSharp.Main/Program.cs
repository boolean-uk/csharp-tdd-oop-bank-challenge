// See https://aka.ms/new-console-template for more information

using Boolean.CSharp.Main.Models;
using Boolean.CSharp.Main.Models.Accounts;

namespace Boolean.CSharp.Main;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("asdsadasdasdasd");
        Bank bank = new("Sparebanken");

        Customer c = new("Eyvind Malde", 123456789, "88887777", new DateTime(2000, 6, 26), Branch.Vest);
        bank.NewCustomer(c);

        var acc = c.CreateAccount("Spending", AccountType.Spending);

        acc.Deposit(100);

        acc.PrintTransactions();

        acc.PrintTransactions();

        acc.PrintTransactions();
    }
}