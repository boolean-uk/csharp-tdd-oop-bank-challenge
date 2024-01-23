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

| Classes   | Members                          | Methods    | Scenario                          | Outputs     |
|-----------|----------------------------------|------------|-----------------------------------|-------------|
| `Account` | `List<Transaction> Transactions` | `Deposit`  |                                   | Transaction | 
|           |                                  | `Withdraw` | Amount *is* more than balance     | Console.out |
|           |                                  |            | Amount *is not* more than balance | Transaction |


```
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
```

| Classes   | Members                           | Methods                | Scenario  | Outputs     |
|-----------|-----------------------------------|------------------------|-----------|-------------|
| `Account` | `List<ITransaction> transactions` | `PrintBankStatement()` |           | Console.out | 


```
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.
```

| Classes         | Members                           | Methods              | Scenario  | Outputs |
|-----------------|-----------------------------------|----------------------|-----------|---------|
| `BankStatement` | `List<ITransaction> Transactions` | `CalculateBalance`   |           | int     | 

```
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.
```

| Classes         | Members                | Methods   | Scenario  | Outputs |
|-----------------|------------------------|-----------|-----------|---------|
| `BankStatement` | `Branch AccountBranch` | `Get()`   |           | Branch  | 
|                 |                        | `Set()`   |           | Branch  |

      
```
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.
```


```
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.
```

```
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
```