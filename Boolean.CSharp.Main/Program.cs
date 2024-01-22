using Boolean.CSharp.Main;

Core _core = new Core();
_core.createSavingsAccount("12345678901");

BankAccount? account = _core.getAccountByNumber("12345678901");
if (account != null )
{
    account.deposit(10000);
    account.withdraw(5000);
    account.deposit(3500);
    Console.WriteLine(account.generateBankStatement());
    Console.WriteLine($"Balance: {account.checkBalance()}");
}

Extension extension = new Extension();

Manager manager = new Manager();
extension.createBank("DNB", "1234", manager);
extension.Bank.createBankBranch("Innlandet");
extension.Bank.GetBankBranch("Innlandet").createCustomer("Gudbrand", "123456");
extension.Bank.GetBankBranch("Innlandet").GetCustomerByNr("123456").createCurrentAccount("1");
extension.Bank.GetBankBranch("Innlandet").GetCustomerByNr("123456").getAccountByNumber("12341234561").deposit(10000);