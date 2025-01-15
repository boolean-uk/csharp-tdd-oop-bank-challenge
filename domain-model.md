## User Stories Core

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


## Domain Model Core

| Classes    | Methods/Properties                  | Senario                              | Outputs          |
|------------|-------------------------------------|--------------------------------------|------------------|
| Bank.cs    | AddAccount(string type)             | Adds a account of a selected type    | Account created  |
| Bank.cs    | GenerateStatements(Account account) | Need to generate a bank statement    | Bank statement   |
| Account.cs | List Transactions                  | A list to keep track of transactions |                  |
| Account.cs | Depoist(decimal amount)             | Deposit a amount into your account   | Amount deposited |
| Account.cs | Withdraw(decimal amount)            | Withdraw an amount from your account | Amount withdrawn |


## User Stories Extension

```
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
```

## Domain Model Extension


| Classes    | Methods/Properties | Senario                                          | Outputs   |
|------------|--------------------|--------------------------------------------------|-----------|
| Enum.cs    | enum Branch        | Add a enum for branches                          |           |
| Account.cs | GetBalance()       | Calculate balance form transaction history       | Balance   |
| Account.cs | RequestOverdraft() | Requests a overdraft of funds you might not have |           |
| Bank.cs    | ApproveOverdraft() | Approves overdraft from accounts                 | Bool      |
| Bank.cs    | SendMessage()      | Sends statements to a phone                      | statement |