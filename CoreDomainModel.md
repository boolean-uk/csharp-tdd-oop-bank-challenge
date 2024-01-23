# Core
## Requirements
1. You must create domain models from the user stories provided and include them in the repository
2. You must create class diagrams from your domain models
3. You must use a test-driven development approach to complete this challenge, demonstrate this by committing your work after writing a test and after writing source code to pass it
4. You must demonstrate object-oriented principles. You need not include every concept, but you should strive to include as many as possible
5. You can decide whether to use composition, inheritance, or a combination of both, but at least one must be present

## Derived from user stories
1. I want to create a current account.
2. I want to create a savings account.
3. I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
4. I want to deposit and withdraw funds.

## Classes
| Class | Properties |
|---|---|
| Transaction | `DateTime Date`, `double Amount`, `TransactionType Type` |
| Account | `int AccountNumber`, `double Balance`, `List<Transaction> Transactions`|
| CurrentAccount : Account | |
| SavingsAccount : Account| |
| BankStatement | `Account account` |

## Functionality
| User story | Class | Method | Scenario | Output |
|---|---|---|---|---|
| 1 | CurrentAccount | Constructor | | `CurrentAccount` object with initial details |
| 2 | SavingsAccount | Constructor | | `SavingsAccount` object with initial details |
| 3 | BankStatement  | `DisplauStatement(int accountNumber)` | There exists a account with  `AccountNumber == accountNumber`| A bank statment with the format in Acceptance Criteria |
| 4 | Account | `Deposit(double amount)` | | Updated account balance and add a transaction to `Transactions` |
| 4 | Account | `Withdraw(double amount)` | `Balace >= amount` | Update account balance and add a transaction to `Transactions` |
|   |         | | `Balace < amount` | throw exeption |