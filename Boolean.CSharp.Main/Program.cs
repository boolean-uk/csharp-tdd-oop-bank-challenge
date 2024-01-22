using Boolean.CSharp.Main;

Core _core = new Core();
_core.createSavingsAccount("12345678901", new Customer());

BankAccount? account = _core.getAccountByNumber("12345678901");
if (account != null )
{
    account.deposit(10000);
    account.withdraw(5000);
    account.deposit(3500);
    Console.WriteLine(account.generateBankStatement());
    Console.WriteLine($"Balance: {account.checkBalance()}");
}