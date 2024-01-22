using Boolean.CSharp.Main;

Customer customer = new Customer();
var account = customer.createAccount(123, accountType.savings);
account.deposit(100f);
account.Transaction.ElementAt(0);
Console.WriteLine("");