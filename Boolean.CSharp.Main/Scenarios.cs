using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.Accounts;
using Boolean.CSharp.Main.Enums;
using Boolean.CSharp.Main.Exceptions;
using Boolean.CSharp.Main.Misc;

namespace Boolean.CSharp.Main
{
    public class Scenarios
    {
        private Bank _bank;
        private int _columnWidth = 30;
        private double _startingCapital = 25000;
        private List<int> _overdraftIds = [];
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
                Console.WriteLine($"\nYou currently have {_startingCapital} at hand.\n");
                Console.WriteLine(StringHelper.Columnify(
                    ["(1) Create account", "(2) Balance", "(3) Deposit"],
                    _columnWidth, "|"));
                Console.WriteLine(StringHelper.Columnify(
                    ["(4) Withdraw", "(5) Request overdraft", "(6) Account statement"],
                    _columnWidth, "|"));
                Console.WriteLine(StringHelper.Columnify(
                    ["(7) Overdraft status", "(8) Manager View", "(9) Exit"],
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
                        _startingCapital -= HandleDeposit(account);
                        break;
                    case "4":
                        account = GetAccount();
                        if (account == null)
                        {
                            Console.WriteLine("Could not find account, try again!");
                            continue;
                        }
                        _startingCapital -= HandleWithdraw(account);
                        break;
                    case "5":
                        account = GetAccount();
                        if (account == null)
                        {
                            Console.WriteLine("Could not find account, try again!");
                            continue;
                        }
                        int overdraftId = HandleRequestOverdraft(account);
                        if (overdraftId >= 0)
                        {
                            _overdraftIds.Add(overdraftId);
                        }
                        break;
                    case "6":
                        account = GetAccount();
                        if (account == null)
                        {
                            Console.WriteLine("Could not find account, try again!");
                            continue;
                        }
                        Console.WriteLine();
                        account.WriteStatement(new ConsoleWriter());
                        break;
                    case "7":
                        HandleOverdraftStatus();
                        break;
                    case "8":
                        DoManagerScenario();
                        break;
                    case "9":
                        Console.WriteLine("Have a nice day!");
                        return;
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
        
        private double HandleDeposit(Account account)
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
                        return 0;
                    }
                    AccountTransaction transaction = account.Deposit(value);
                    return transaction.Amount;
                } catch
                {
                    Console.WriteLine("I do not understand, try again.");
                }
            }
        }

        private double HandleWithdraw(Account account)
        {
            while (true)
            {
                Console.WriteLine($"Your account balance is: {account.Balance}");
                Console.WriteLine("How much would you like to withdraw?");
                Console.Write("(-1 for cancel): ");
                string? userInp = Console.ReadLine();
                try
                {
                    double value = double.Parse(userInp);
                    if (value == -1)
                    {
                        Console.WriteLine("Very well!");
                        return 0;
                    }
                    AccountTransaction transaction = account.Withdraw(value);
                    return transaction.Amount;
                } catch (InsufficientFundsException)
                {
                    Console.WriteLine("You do not have that much money on the account! Try again!");
                } catch (LimitExceededException)
                {
                    Console.WriteLine($"You have a withdrawal limit of: {((SavingsAccount) account).WithdrawalLimit}!");
                } catch
                {
                    Console.WriteLine("I do not understand, try again.");
                }
            }
        }

        public int HandleRequestOverdraft(Account account)
        {
            while (true)
            {
                Console.WriteLine($"Your account balance is: {account.Balance}");
                Console.WriteLine("How much would you like to request?");
                Console.Write("(-1 for cancel): ");
                string? userInp = Console.ReadLine();
                try
                {
                    double value = double.Parse(userInp);
                    if (value == -1)
                    {
                        Console.WriteLine("Very well!");
                        return -1;
                    }
                    int overdraftId = _bank.RequestOverdraft(account.AccountId, value);
                    Console.WriteLine("You have submitted a request!");
                    return overdraftId;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("You have that much on your account! Try again!");
                }
                catch
                {
                    Console.WriteLine("I do not understand, try again.");
                }
            }
        }

        private void HandleOverdraftStatus()
        {
            while (true)
            {
                Console.WriteLine("Your overdraft IDs: " + string.Join(", ", _overdraftIds));
                Console.Write("(id / -1 to cancel): ");
                try
                {
                    string userInp = Console.ReadLine() ?? string.Empty;
                    if (userInp == "-1")
                    {
                        Console.WriteLine("Very well!");
                        return;
                    }
                    int overdraftid = int.Parse(userInp);
                    var status = _bank.GetOverdraftStatus(overdraftid);
                    Console.WriteLine($"The status of overdraft '{1}' is '{status.Item2}'");
                    return;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Please provide a valid id!");
                }
                catch
                {
                    Console.WriteLine("I do not understand, try again.");
                }
            }
        }

        private void DoManagerScenario()
        {
            Console.WriteLine("\nWelcome manager!");
            while (true)
            {
                Console.WriteLine(StringHelper.Columnify(
                    ["(1) List overdraft requests", "(2) Handle overdraft request", "(3) Exit"],
                    _columnWidth, "|"));
                Console.Write(": ");
                string? userInp = Console.ReadLine();
                if (userInp == null)
                {
                    Console.WriteLine("Im sorry, could you repeat that?\n");
                    continue;
                }
                switch (userInp.ToLower())
                {
                    case "1":
                        Console.WriteLine($"OverdraftId - AccountId - Requested amount - Available amount");
                        foreach (var pair in _bank.OverdraftRequests)
                        {
                            Account account = _bank.GetAccount(pair.Value.Item1);
                            Console.WriteLine($"{pair.Key} - {account.AccountId} - {pair.Value.Item2} - {account.Balance}");
                        }
                        break;
                    case "2":
                        double loan = HandleOverdraftRequest();
                        _startingCapital += loan;
                        break;
                    case "3":
                        Console.WriteLine("Have a nice day!");
                        return;
                    default:
                        Console.WriteLine("Im sorry, could you repeat that?\n");
                        continue;
                }
            }
        }

        private double HandleOverdraftRequest()
        {
            while (true)
            {
                Console.WriteLine("What overdraft would you like to accept/decline?");
                Console.Write("(id,true / false): ");
                string? userInp = Console.ReadLine();
                try
                {
                    var argArr = userInp.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    int overdraftId = int.Parse(argArr[0]);
                    bool status = bool.Parse(argArr[1]);
                    if (overdraftId == -1)
                    {
                        Console.WriteLine("Very well!");
                        return 0;
                    }
                    var request = _bank.GetOverdraftRequests(overdraftId);
                    _bank.HandleOverdraftRequest(overdraftId, status);
                    Console.WriteLine($"You have {(status ? "accepted" : "declined")} the request!");
                    return status ? request.Item2 : 0;
                }
                catch
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
            try
            {
                Guid accountId = new Guid(input);
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
