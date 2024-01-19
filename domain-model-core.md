```
As a customer,
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
I want to deposit and withdraw funds.
```

| Classes    | Members                  | Methods                                                      | Scenario                                                    | Outputs |
|------------|--------------------------|--------------------------------------------------------------|-------------------------------------------------------------|---------|
| `core`     | List<IAccount> _accounts | `createCurrentAccount(string accountNumber, double balance)` | Account number is unique and balance is positive            | true    |
|            |                          |                                                              | Account number is not unique and/or balance is not positive | false   |
|            | List<IAccount> _accounts | `createSavingsAccount(string accountNumber, double balance)` | Account number is unique and balance is positive            | true    |
|            |                          |                                                              | Account number is not unique and/or balance is not positive | false   |
| `IAccount` | double balance           | `deposit(double amount)`                                     | amount is more than 0                                       | true    |
|            |                          |                                                              | amount is less than 0                                       | false   |
|            | double balance           | `withdraw(double amount)`                                    | amount is more than 0 and the balance is high enough        | true    |
|            |                          |                                                              | amount is less than 0 and/or the balance is to low          | false   |
|            |                          | `checkBalance()`                                             |                                                             | double  |
|            |                          | `generateBankStatement()`                                    |                                                             | string  |