## User Stories

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

## Domain Model

| **Classes** | **Members** | **Methods** | **Scenario** | **Outputs** |
|:--:|:--:|:--:|:--:|:--:|
| `Account` | `List<Transaction> TransactionHistory` | `GetBalance(User user)` | Store and view balance in savings account | `int?` |
| `Account` | `List<Transaction> TransactionHistory` | `Deposit(int amount, User user)` | Deposit money in savings account | `true` |
| `Account` | `List<Transaction> TransactionHistory` | `Withdraw(int amount, User user)` | Withdraw money in savings account | `true` |
| `Account` | `List<Transaction> TransactionHistory` | `GetBankStatement(User user)` | Withdraw money in savings account | `true` |
| `Account` | `Branch Branch` | `GetBranch(User user)` | Get branch of account | `Branch?` |
| `Account` | `string Overdraft` | `SetOverdraft(int amount, User user)` | Set overdraft as manager | `true` |
| `Account` | `string Overdraft` | `SetOverdraft(int amount, User user)` | Attempt to set overdraft | `false` |
| `SmsController` |  | `SendBankStatement(string phoneNumber, User user)` | Get bank statement and send to phone | `false` |
