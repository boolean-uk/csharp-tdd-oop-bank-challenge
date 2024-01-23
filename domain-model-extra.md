```C#
Core
public enum TransactionsType {
    DEPOSIT,
    WITHDRAW,
}

public enum AccountType {
    CURRENT = 1,
    SAVINGS = 2,
}

public interface IAccount {
    //Methods
        string AccountName { get; }
        void Deposit(decimal amout);
        void Withdraw(decimal amout);
        string GenerateStatement(); 
        decimal CalculateAccountBalance();
}

public class OverdraftRequest {
    //Members
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
}

public class Bank {
    //Members
        private List<OverdraftRequests> _overdraftRequests = List<OverdraftRequest>();
    
    //Methods
        public void RequestOverdraft(IAccount account, decimal amcount);
        public void ApproveOverdraft(int _id);
}

public class Branch {
    //Members
        public string BranchName { get; private set; }

    //Methods
        public Branch(string BranchName){ // Constructor
            //Set
        } 
}

public abstarct class Account : IAccount{
    //Members
        private readonly List<Transactions> _transactions = new List<Transactions>();
        public string AccountName { get; private set;}
        

    //Methods
        public Account(string accountName, decimal startingBalance); // constructor

        public void Deposit(decimal amount); // Add decimal value to balance if greater than 0
        public void Withdraw(decimal amount); // Removes decimal value from balance if it is lerr or equal to balance
        public string GenerateStatement(); // generate a bank statement based on deposits and withdraws
        private void AddTransaction(decimal, TransactionType type); 
        public abstract AccountType GetAccountType();
        public decimal CalculateAccountBalance();
}

public class SavingsAccount : Account {
    public override AccountType GetAccountType();
}

public class CurrentAccount : Account {
    public override AccountType GetAccountType();
}

public class Transactions {
    //Members
        public decimal Amount { get; }
        public TransactionType Type { get; }
        public DateTime DateOfTransaction { get; }
        public Account account { get; }

    //Constructor
        public Transactions(decimal amount, TransactionType type, Account account) {
            // set
        }
}
```