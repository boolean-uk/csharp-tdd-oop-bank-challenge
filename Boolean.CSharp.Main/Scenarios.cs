using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Misc;

namespace Boolean.CSharp.Main
{
    public class Scenarios
    {
        private Bank _bank;
        private int _columnWidth = 25;
        public Branch BankBranch { get; set; } = Branch.Trondheim;

        public Scenarios()
        {
            _bank = new Bank("With some secrets!");
        }

        public void PlayCustomerScenario()
        {
            Console.WriteLine("Welcome to the great 'Some Grand Name', usually called SGN!");
            Console.WriteLine("How can we help you?\n");

            while (true)
            {
                Console.WriteLine(StringHelper.Columnify(
                    ["(1) Create account", "(2) Balance", "(3) Deposit"],
                    _columnWidth, "|"));
                Console.WriteLine(StringHelper.Columnify(
                    ["(4) Withdraw", "(5) Request overdraft", "(6) Account statement"],
                    _columnWidth, "|"));
                Console.WriteLine(StringHelper.Columnify(
                    ["(7) Exit"],
                    _columnWidth, "|"));
                Console.Write(": ");
                string? userInp = Console.ReadLine();
                if (userInp == null)
                {
                    Console.WriteLine("Im sorry, could you repeat that?\n");
                    continue;
                }
                Account? account;
                switch (userInp.ToLower())
                {
                    case "1":
                        CreateAccount();
                        break;
                    case "2":
                        account = GetAccount();
                        if (account == null)
                        {
                            Console.WriteLine("Could not find account, try again!");
                            continue;
                        }
                        Console.WriteLine($"Balance: {account.Balance}");
                        break;
                    case "3":
                        account = GetAccount();
                        if (account == null)
                        {
                            Console.WriteLine("Could not find account, try again!");
                            continue;
                        }
                        HandleDeposit(account);
                        break;
                    case "7":
                        Console.WriteLine("Have a nice day!");
                        break;
                    default:
                        Console.WriteLine("Im sorry, could you repeat that?\n");
                        continue;
                }
            }
        }

        private void CreateAccount()
        {
            Console.WriteLine("So you want a new account, let me hep you with that!");
            while (true)
            {
                Console.WriteLine("What kind of account do you want?");
                Console.WriteLine(StringHelper.Columnify(
                    ["(1) Regular account", "(2) Savings account", "(3) Cancel"],
                    _columnWidth, "|"));
                Console.Write(": ");
                string? userInp = Console.ReadLine();
                if (userInp == null)
                {
                    Console.WriteLine("Im sorry, could you repeat that?\n");
                    continue;
                }
                Guid accountId;
                switch (userInp.ToLower())
                {
                    case "1":
                        Console.WriteLine("A regular account, then I will need a name!");
                        Console.Write(": ");
                        string? name = Console.ReadLine();
                        name = name ?? "";
                        accountId = _bank.CreateAccount(name, BankBranch);
                        Console.WriteLine("The new account has been created!");
                        Console.WriteLine($"It's ID is '{accountId}', remember it. It is important!\n");
                        return;
                    case "2":
                        Console.WriteLine("A savings account, then I will need a name and a withdrawal limit!");
                        Console.Write("(name,limit): ");
                        try
                        {
                            string? args = Console.ReadLine();
                            var argArray = args.Split(",", StringSplitOptions.RemoveEmptyEntries);
                            accountId = _bank.CreateAccount(argArray[0], Double.Parse(argArray[1]), DateTime.Now, BankBranch);
                        } catch
                        {
                            Console.WriteLine("Please format it correctly");
                            continue;
                        }
                        Console.WriteLine("The new account has been created!");
                        Console.WriteLine($"It's ID is '{accountId}', remember it. It is important!\n");
                        return;
                    case "3":
                        Console.WriteLine("Very well!");
                        break;
                    default:
                        Console.WriteLine("Im sorry, could you repeat that?\n");
                        continue;
                }
            }
        }
        
        private void HandleDeposit(Account account)
        {
            while (true)
            {
                Console.WriteLine("How much would you like to deposit?");
                Console.Write("(-1 for cancel): ");
                string? userInp = Console.ReadLine();
                try
                {
                    double value = double.Parse(userInp);
                    if (value == -1)
                    {
                        Console.WriteLine("Very well!");
                        return;
                    }
                    account.Deposit(value);
                    return;
                } catch
                {
                    Console.WriteLine("I do not understand, try again.");
                }
            }

        }
        private Account? GetAccount()
        {
            Console.WriteLine("Please provide an account ID!");
            Console.Write(": ");
            string? input = Console.ReadLine();
            if (input == null) return null;
            Guid accountId = new Guid(input);
            try
            {
                return _bank.GetAccount(accountId);
            } catch
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            Scenarios scenarios = new Scenarios();
            scenarios.PlayCustomerScenario();
        }
    }
}
