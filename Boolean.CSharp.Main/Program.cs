namespace Boolean.CSharp.Main;

class Program
{
    private static UserManager userManager = new UserManager();
    private static Account currentAccount;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to Gringotts Wizarding Bank");
            Console.WriteLine("1. Register for Vault 713 ");
            Console.WriteLine("2. Login, you muggle");
            Console.WriteLine("3. Deposit golden Galleons");
            Console.WriteLine("4. Withdraw golden Galleons");
            Console.WriteLine("5. Print Statement, Dobby is free");
            Console.WriteLine("6. Exit bank and sod off");
            Console.Write("Enter your choice, Potterhead: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    userManager.Register();
                    break;
                case "2":
                    var user = userManager.Login();
                    if (user != null)
                    {
                        Console.WriteLine("Choose account type: ");
                        Console.WriteLine("1. Current Account");
                        Console.WriteLine("2. Savings Account");
                        var accountType = Console.ReadLine();

                        Console.WriteLine("Choose your branch: ");
                        DisplayBranches();
                        AllEnums.Branches selectedBranch;
                        bool isValidBranch = Enum.TryParse(Console.ReadLine(), out selectedBranch);

                        if (!isValidBranch)
                        {
                            Console.WriteLine("Invalid branch choice.");
                            break;
                        }

                        if (accountType == "1")
                        {
                            currentAccount = new CurrentAccount(selectedBranch, user);
                        }
                        else if (accountType == "2")
                        {
                            currentAccount = new SavingsAccount(selectedBranch, user);
                        }
                        else
                        {
                            Console.WriteLine("Invalid account type choice.");
                        }
                    }
                    break;
                case "3":
                    Deposit();
                    break;
                case "4":
                    Withdraw();
                    break;
                case "5":
                    PrintStatement();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
    private static void DisplayBranches()
    {
        var branches = Enum.GetValues(typeof(AllEnums.Branches)).Cast<AllEnums.Branches>().ToList();
        for (int i = 0; i < branches.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {branches[i]}");
        }
    }
    private static void Deposit()
    {
        if (currentAccount == null)
        {
            Console.WriteLine("Please log in first, then make a deposit.");
            return;
        }

        Console.Write("Enter amount to deposit: ");
        double amount = double.Parse(Console.ReadLine());
        currentAccount.Deposit(amount, DateTime.Now);
        Console.WriteLine("Amount deposited successfully!");
    }

    private static void Withdraw()
    {
        if (currentAccount == null)
        {
            Console.WriteLine("Please log in first, then make a withdraw");
            return;
        }

        Console.Write("Enter amount to withdraw: ");
        double amount = double.Parse(Console.ReadLine());
        currentAccount.Withdraw(amount, DateTime.Now);
        Console.WriteLine("Amount withdrawn successfully!");
    }

    private static void PrintStatement()
    {
        if (currentAccount == null)
        {
            Console.WriteLine("Please log in first.");
            return;
        }

        Console.WriteLine(currentAccount.PrintStatement());
    }
}