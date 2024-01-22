```
As a customer,
So I can safely store use my money,
I want to create a current account.
```

| Classes       | Members                  | Methods                  | Scenario  | Outputs        |
|---------------|--------------------------|--------------------------|-----------|----------------|
| `BankManager` | `List<Account> Accounts` | `CreateCurrentAccount()` |           | CurrentAccount |  


```
As a customer,
So I can save for a rainy day,
I want to create a savings account.
```

| Classes       | Members                  | Methods                  | Scenario  | Outputs        |
|---------------|--------------------------|--------------------------|-----------|----------------|
| `BankManager` | `List<Account> Accounts` | `CreateSavingsAccount()` |           | Savingsaccount |  

```
As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```

| Classes   | Members                         | Methods                  | Scenario  | Outputs        |
|-----------|---------------------------------|--------------------------|-----------|----------------|
| `Account` | `SavingsAccount savingsAccount` | `CreateSavingsAccount()` |           | Savingsaccount | 


```
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
```