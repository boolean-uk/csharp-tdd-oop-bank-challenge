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

        Account acc = c.CreateAccount("Spending", AccountType.Spending);

        var temp = acc.Deposit(100);

        acc.PrintTransactions();

        temp = acc.Deposit(200);
        temp = acc.Deposit(300);

        acc.PrintTransactions();

        temp = acc.Withdraw(500);

        acc.PrintTransactions();
    }
}