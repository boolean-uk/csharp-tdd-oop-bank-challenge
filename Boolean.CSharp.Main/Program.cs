using Boolean.CSharp.Main;

Customer customer = new Customer();
var account = customer.createAccount(123, AccountType.savings);
account.deposit(100f);
account.deposit(100f);
account.withdraw(50f);
account.printStatement();
Console.WriteLine("");