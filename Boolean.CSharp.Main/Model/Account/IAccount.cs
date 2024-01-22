using System.Text;

namespace Boolean.CSharp.Main;

public interface IAccount
{
    
    List<Transaction> Transactions {get; }
    Branch Branch {get; }
    Signature Signature {get; }

    Guid Id {get; }

    Transaction Deposit(int amount);

    Transaction Deposit(Transaction transaction);
    Transaction Withdrawl(int amount);
    int GetBalance();
    StringBuilder PrintReceipt();
}
