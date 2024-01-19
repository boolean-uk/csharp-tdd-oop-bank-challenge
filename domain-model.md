```C#
/*As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds.*/

enum AccountSorts {
    CURRENT = 1,
    SAVING = 2,
}

public interface IAccount {
    string AccountName { get; }
    decimal Balance { get; } 
}

public class Account {

}

public void CreateAccount(string accountName, AccountSorts type)
```