```C#
Core
enum TransactionsType {
    DEPOSIT,
    WITHDRAW,
}

public interface IAccount {
    //Methods
        string AccountName { get; }
        decimal Balance { get; }
        void Deposit(decimal amout);
        void Withdraw(decimal amout);
        string GenerateStatement(); 
}

public abstarct class Account : IAccount{
    //Members
        private readonly List<Transactions> _transactions = new List<Transactions>();

        public string AccountName { get; private set;}
        public decimal Balance {get; private set;}

    //Methods
        public Account(string accountName); // constructor

        public void Deposit(decimal amount); // Add decimal value to balance if greater than 0
        public void Withdraw(decimal amount); // Removes decimal value from balance if it is lerr or equal to balance
        public string GenerateStatement(); // generate a bank statement based on deposits and withdraws
        private AddTransaction(decimal, TransactionType type); 
        public abstract AccountTypes GetAccountType();
}

public class SavingsAccount : Account {
    public override AccountTypes GetAccountType();
}

public class CurrentAccount : Account {
    public override AccountTypes GetAccountType();
}

public class Transactions {
    //Members
        public decimal Amount { get; }
        public TransactionType Type { get; }
        public decimal Balance { get; }
        public DateTime DateOfTransaction { get; }
        public Account account { get; }

    //Constructor
        public Transactions(decimal amount, TransactionType type, decimal balance, Account account) {
            // set
        }
}
```