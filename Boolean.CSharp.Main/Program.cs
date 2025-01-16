using System;
using Boolean.CSharp.Main;

namespace start;
class Program
{
    static void Main(string[] args)
    {
        Branch branch = new Branch("Oslo Branch");
        Customer customer = new Customer("Customer1", branch);


        customer.GetCurrentAccount.deposit(1000, new DateTime(2012, 1, 10));
        customer.GetCurrentAccount.deposit(2000, new DateTime(2012, 1, 13));

        customer.GetCurrentAccount.withdraw(500, new DateTime(2012, 1, 14));

        customer.GetCurrentAccount.SetOverDrawAmount(100);

        Console.WriteLine(customer.GetCurrentAccount.overDrawAmount);

        BankStatement.printStatement(customer.GetCurrentAccount);
    }
}