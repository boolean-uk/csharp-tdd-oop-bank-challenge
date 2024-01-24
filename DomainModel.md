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
| `abstact User`     | `Account CreateAccount(AccountType accountType)` | Create an account based on AccountType                    | `Child class of IAccount` |
| `Customer : User`  |                                             |                                                                |                     |
| `Manager : User`   | `List<Overdraft> GetOverdraftRequests()`    | Gets overdraft requests from the bank                          | `List<Overdraft>` |
| `Bank`             | `double Deposit(double depositAmount)`      | User adds money into the bank based of what they deposited from their account |      |
|                    | `double Withdrawl(double withdrawlAmount)`  | User removes money from the bank based of what they withdrew from their account |                     |
|                    | `internal List<Overdraft> GetOverdraftRequests() | Returns the overdraft requests sendt to the bank by the user |                     |
| `abstract Account` | `Account(User user, MobilePhone mobile = mobile)` |                                                             |                     |
|                    | `double GetBalance()`                       | Compares the accounts balance based of the transaction history.   | `value`    |                     |
|                    | `Statement GetBankStatement()`              | Returns a statement                                               |                     |
|                    | `bool SetMobile(MobilePhone mobile)`        |                                                                   |                     |
|                    | `double Deposit(Customer customer, double cashAmount)`   | Deposits cash into                                   |                     |
|                    | `double Withdrawl(Customer customer, double cashAmount)` |                                                      |                     |
|                    | `bool RequestOverdraft()`                   |                                                                   |                     |
|                    | `bool SendTransactionSMS(Transaction transaction)`|                                                      |                     |
| `AccountDeposit : Account` | `AccountDeposit(User user, Mobile mobile = mobile)` |                                                   |                     |
| `AccountSavings : Account` | `AccountSavings(User user, Mobile mobile = mobile)` |                                                   |                     |
| `MobilePhone`      |                                             |                                                                   |                     |

| Structs     | Variables                           |
|-------------|-------------------------------------|
| `Overdraft` | `Account` Account                   |
|             | `double` RequestedAmount            |
|             | `bool` IsAccepted                   |
| `Statement` | `double` Amount                     |
|             | `string` Date                       |
|             | `string` Time                       |
|             | `double` balanceAtTimeOfTransaction |

| Enums       | Variables |
|-------------|-----------|
| AccountType | Credit    | 
|             | Debit     |