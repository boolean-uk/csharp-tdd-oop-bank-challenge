
# User stories
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







# Domain Model

| Classes             | Methods/Properties                                 | Scenario                                                                                      | Outputs                                      |
|---------------------|----------------------------------------------------|----------------------------------------------------------------------------------------------|----------------------------------------------|
| **Bank**            | `CreateCurrentAccount(CurrentAccount account, Branches b)` | Creates a current account and associates it with a branch.                                   | Returns the created `CurrentAccount`.        |
|                     | `CreateSavingsAccount(SavingsAccount account, Branches b)` | Creates a savings account and associates it with a branch.                                   | Returns the created `SavingsAccount`.        |
|                     | `Deposit(int amount, Account account)`            | Deposits a specified amount into the provided account and updates the balance.               | Updated balance and a new transaction record.|
|                     | `Withdrawal(double amount, Account account)`      | Withdraws a specified amount from the provided account while checking overdraft rules.       | Updated balance and a new transaction record.|
|                     | `ShowBankStatements()`                            | Displays all transactions in reverse chronological order.                                    | Prints transaction details to the console.   |
|                     | `ManageOverdraft(bool newStatus, Account account)`| Enables or disables overdraft capability for a current account.                              | Message indicating success or failure.       |
|                     | `RequestOverdraft(double amount, Account account)`| Handles overdraft requests for current accounts, subject to limits and approval rules.       | Approval or rejection message.               |
|                     | `GetStatementsSize()`                             | Returns the total number of transaction statements.                                          | The size of the `statements` list.           |

| **Account** (Abstract) | `double Balance`                                | Represents the balance of the account.                                                      | Balance value.                              |
|                        | `string AccountId`                              | Unique identifier for the account.                                                          | Account ID.                                 |

| **CurrentAccount**    | `bool Overdraftable`                             | Indicates whether overdraft is enabled for the account.                                      | `true` or `false`.                          |
|                       | `double MaxOverdraft`                            | The maximum overdraft amount allowed.                                                        | Maximum overdraft limit.                    |

| **SavingsAccount**    | Inherits from `Account`.                         | Cannot have an overdraft feature.                                                           | Balance management and transactions only.   |

| **BankStatements**    | `string Date`                                    | The date of the transaction.                                                                | Transaction date as a string.               |
|                       | `double Amount`                                  | The amount involved in the transaction.                                                     | Transaction amount.                         |
|                       | `string Type`                                    | The type of transaction (e.g., deposit or withdrawal).                                       | Transaction type.                           |
|                       | `double Balance`                                 | The account balance after the transaction.                                                  | Updated balance.                            |
|                       | `Account Account`                                | The account associated with the transaction.                                                | Reference to an `Account` object.           |

---

## Notes:
1. **Responsibilities**:
   - `Bank`: Manages accounts, transactions, and bank-specific features like overdrafts.
   - `Account`: Abstract base class for different account types.
   - `CurrentAccount` and `SavingsAccount`: Implement account-specific features like overdrafts and savings behavior.
   - `BankStatements`: Tracks individual transactions with details like date, amount, type, and balance.


