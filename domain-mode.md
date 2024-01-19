
This docucument contains an overview of the bank challange.

### Domain Model
| Classes                   | Properties                     | Methods                                    | Returns                                                                              |
|---------------------------|--------------------------------|--------------------------------------------|--------------------------------------------------------------------------------------|
| Account                   | List<Transaction> transactions | Deposit(int amount) : Transaction          | Adds the amount to the balance.                                                      |
|                           | Branch branch                  | Withdraw(int amount) : Transaction         | Checks if balance > amount, return a Transaction, Otherwise return empty Transaction |
|                           | Signature signature            | PrintReceipt() : Stringbuilder             | Goes through all transactions and returns a Stringbuilder with all Transactions.     |
| PersonalAccount : Account |                                |                                            |                                                                                      |
| SavingsAccount: Account   |                                |                                            |                                                                                      |
| CreditAccount : Account   |                                | OverDraft(Signature signature, int amount) |                                                                                      |
| Transaction               | DateTime date :: Getter        |                                            |                                                                                      |
|                           | int amount :: Getter           |                                            |                                                                                      |
|                           | int balance :: Getter          |                                            |                                                                                      |
|                           | Signature signature            |                                            |                                                                                      |
| BankManager               | Signature signature            | ApproveTransaction(Transaction)            |                                                                                      |
|                           |                                | RejectTransaction(Transaction)             |                                                                                      |
|                           |                                |                                            |                                                                                      |
|                           |                                |                                            |                                                                                      |
| Signature                 | Guid signature                 |                                            |                                                                                      |
|                           | bool isManager                 |                                            |                                                                                      |
| Branch                    | string _address                |                                            |                                                                                      |
|                           | int _sortCode                  |                                            |                                                                                      |
| Bank                      | List<Account> accounts         | AddAccount(Account account) : string       |                                                                                      |
|                           | List<Transaction> overdrafts   | RemoveAccount(Account account) : string    |                                                                                      |
|                           |                                | RequestOverdraft(Account account) : string |                                                                                      |
|                           |                                |                                            |                                                                                      |

### Class Diagram

