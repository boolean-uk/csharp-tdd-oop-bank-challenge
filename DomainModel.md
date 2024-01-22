```
As a customer,
So I can safely store use my money,
I want to create a current account.

So I can save for a rainy day,
I want to create a savings account.

So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

So I can use my account,
I want to deposit and withdraw funds.

So I have an emergency fund,
I want to be able to request an overdraft on my account.

So I can stay up to date,
I want statements to be sent as messages to my phone.
```

```
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.
```

```
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

So I can safeguard our funds,
I want to approve or reject overdraft requests.
```



| Classes            | Methods                                     | Scenario                                                       | Outputs             |
|--------------------|---------------------------------------------|----------------------------------------------------------------|---------------------|
| `IUser`            | `Account CreateAccount(AccountType)`        | Creates an account                                                               |                     |
| `Customer : IUser` |                                             |                                                                |                     |
| `Manager : IUser`  | `List<Overdraft> GetOverdraftRequests()`    |                                                                |                     |
| `Bank`             | `double AddCash(double depositAmount)`      |                                                                |                     |
|                    | `double RemoveCash(double withdrawlAmount)` |                                                                |                     |
|                    | `GetOverdraftRequests()                     |                                                                |                     |
| `Account`          | `Account(Mobile mobile = mobile)`           |                                                                |                     |
|                    | `double GetBalance()`                       | Compares the accounts balance based of the transaction history.| `value`    |                     |
|                    | `Statement BankStatement GetBankStatement()`|                                                                |                     |
|                    | `bool AddMobile(Mobile mobile)`             |                                                                |                     |
|                    | `double Deposit(Customer, double)`          |                                                                |                     |
|                    | `double Withdrawl(Customer double)`         |                                                                |                     |
|                    | `bool RequestOverdraft()`                   |                                                                |                     |
|                    | `bool SetSendStatementToMobile(bool shouldSendStatement)` |                                                  |                     |
|                    | `private string SendStatement()`            |                                                                |                     |
| `MobilePhone`      |                                             |                                                                |                     |


| Structs     | Variables                           |
|-------------|-------------------------------------|
| `Overdraft` | `Account` Account                   |
|             | `double` RequestedAmount            |
|             | `bool` IsAccepted                   |
| `Statement` | `double` Amount                     |
|             | `string` Date                       |
|             | `string` Time                       |
|             | `double` balanceAtTimeOfTransaction |
