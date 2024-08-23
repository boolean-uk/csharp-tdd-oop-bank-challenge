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
        WestBranch branch = new(new Manager());
        bank.AddBranch(branch);

        Customer c = new("Eyvind Malde", 123456789, "88887777", new DateTime(2000, 6, 26));
        branch.NewCustomer(c);

        var acc = c.CreateAccount("Spending", AccountType.Spending);

        acc.Deposit(100);

        acc.PrintTransactions();

        acc.PrintTransactions();

        acc.PrintTransactions();
    }
}