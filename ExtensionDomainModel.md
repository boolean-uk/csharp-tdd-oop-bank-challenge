# Extension 
## Derived from new user stories
1. I want account balances to be calculated based on transaction history instead of stored in memory.
2. I want accounts to be associated with specific branches.
3. I want to be able to request an overdraft on my account.
4. I want to approve or reject overdraft requests.
5. I want statements to be sent as messages to my phone.

## Classes
| Class | Properties | Notes |
|---|---|---|
| Account | `int AccountNumber`, `List<Transaction> Transactions`, `Branch AssociatedBranch`, `int phoneNumber` |
| AccountManager | `Dictionary<int, Accounts.Account> Accounts` |
| CurrentAccount : Account | `bool IsOverdraftRequested`, `bool IsOverdraft`, `double OverdraftAmount` |
| OverdraftRequest | `int AccountID`, `double Amount` |
| OverdraftManager | `Dictionary<int, OverdraftRequest> Requests`, `AccountManager _accountManager` |


## Functionality
| User story | Class | Method | Scenario | Output |
|---|---|---|---|---|
|   | AccountManager | `int AddCurrent(Branch branch, string phoneNumber)`, `int AddSavings(Branch branch, string phoneNumber)` | | Creates new `CurrentAccount`/`SavingsAccount` and adds it to `Accounts`. Returns `Account.AccountNumber` |
| 1 | Account | `GetBalanceAfterTransaction(Transaction transaction)` | | Balance afther `transaction.Date` |
| 2 | Branch  | `enum` |
| 3 | CurrentAccount | `RequestOverdraft(double amount, OverdraftManager overdraftManager)` | | `overdraftManager.CreateRequest(AccountNumber, amount);` |
| 3 | OverdraftManager | `CreateRequest(int accountID, double amount)` | `AccountManager.Accounts` has key `accountID` | Adds new request to `Requests` |
|   |                  |                                               | `AccountManager.Accounts` does not have key `accountID` | Throw error |
| 4 | OverdraftManager | `ApproveRequest(int accountID, double amount)` | `Requests` has key `accountID` | Sets the `OverdraftLimit` of `OverdraftAccount` in `AccountManager.Accounts` to `amount` and deletes the request |
|   |                  |                                                  | `Requests` does not have key `accountID` | Throw error |
| 4 | OverdraftManager | `RejectRequest(int accountID)`  | `Requests` has key `accountID` | deltes the request |
|   |                  |                                                  | `Requests` does not have key `accountID` | Throw error |
| 5 | BankStatment | `void sendStatmentMessage(string statment)` | | Sends a message that includes `statment` to `phoneNumber` |