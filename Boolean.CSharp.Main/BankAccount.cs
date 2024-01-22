namespace Boolean.CSharp.Main;

public class BankAccount
{
    private string _accountNumber;
    private List<Tuple<DateOnly, double>> _transactions;
    private string _overdraftStatus = "Not_Allowed";

    public BankAccount(string accountNumber, Customer customer)
    {
        _accountNumber = accountNumber;
        _transactions = new List<Tuple<DateOnly, double>>();
        customer.addAccount(this);
    }

    public string AccountNumber { get { return _accountNumber; } }
    public double checkBalance()
    {
        double balance = 0;
        foreach (var transaction in _transactions)
        {
            balance += transaction.Item2;
        }
        return balance;
    }
    public bool deposit(double amount)
    {
        if (amount > 0)
        {
            _transactions.Add(new Tuple<DateOnly, double>(DateOnly.FromDateTime(DateTime.Now), amount));
            Console.WriteLine($"{amount} deposited");
            return true;
        }
        Console.WriteLine("Amount has to be more than 0");
        return false;
    }
    public bool withdraw(double amount)
    {
        if (amount > 0)
        {
            _transactions.Add(new Tuple<DateOnly, double>(DateOnly.FromDateTime(DateTime.Now), -amount));
            Console.WriteLine($"{amount} withdrawn");
            return true;
        }
        Console.WriteLine("Amount has to be more than 0");
        return false;
    }
    public string generateBankStatement()
    {
        string statement = string.Format("{0,-10} {1,-10} {2, -10} {3, -10}\n", "date", "credit", "debit", "balance");
        double total = 0;
        foreach (var transaction in _transactions)
        {
            total += transaction.Item2;
            if (transaction.Item2 > 0)
            {
                statement += string.Format("{0,-10} {1,-10} {2, -10} {3, -10}\n", transaction.Item1, transaction.Item2, "", total);
            }
            else
            {
                statement += string.Format("{0,-10} {1,-10} {2, -10} {3, -10}\n", transaction.Item1, "", -transaction.Item2, total);
            }
        }
        return statement;
    }
}
