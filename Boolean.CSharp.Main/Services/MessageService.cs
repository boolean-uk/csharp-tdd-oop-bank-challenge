using Boolean.CSharp.Main.Classes;

namespace Boolean.CSharp.Main.Services
{
    internal class MessageService
    {
        public void SendStatementToPhone(Account account, string phoneNumber)
        {
            string statement = account.GenerateStatement();

            Console.WriteLine("Sending the following statement via SMS:");
            Console.WriteLine($"To: {phoneNumber}");
            Console.WriteLine(statement);
            Console.WriteLine("Statement sent as SMS.");
        }
    }
}
