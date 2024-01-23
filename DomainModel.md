## Domain Model - Core

| `Classes`   | `Methods`       | `Scenarios`                                             | `Outputs`                                                              |
|-------------|-----------------|---------------------------------------------------------|------------------------------------------------------------------------|
| Transaction | GetTrasaction   | Transactions exist                                      | Returns date, amount and balance at the time of transaction            |
|             |                 | Transactions don't exist                                | Returns that no transaction exists                                     |
| Account     | GetTransactions | Transactions exist                                      | Returns a list of date, amount and balance at the time of transactions |
|             |                 | Transactions don't exists                               | Returns that no transactions have been made                            |
|             | Deposit         |                                                         | Deposits money to the account                                          |
|             | Withdraw        | The account is not empty and has enough funds           | Withdraws money from the account                                       |
|             |                 | The account is not empty and does not have enough funds | Returns a message that the account does not have enough funds          |
|             |                 | The account is empty                                    | Returns a message that the account is empty                            |
| User        | CreateAccount   |                                                         | Creates an account                                                     |
|             | RemoveAccount   | Account exists                                          | Removes an account from a user                                         |
|             |                 | Account does not exist                                  | Returns a message that the account does not exist                      |
|             | GetAccounts     |                                                         | Returns the accounts of the user                                       |
| Bank        | GetUsers        |                                                         | Returns the users of the bank                                          |
|             | AddUser         |                                                         | Adds a user to the bank                                                |
|             | RemoveUser      | User exists                                             | Removes the user from the bank                                         |
|             |                 | User does not exist                                     | Returns a message that the user does not exist                         |