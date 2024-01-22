## Domain Model

| `Classes` | `Methods`                        | `Scenario`                                   | `Outputs`                                                            |
|-----------|----------------------------------|----------------------------------------------|----------------------------------------------------------------------|
| User      | GetBalance                       | The user has a transaction history           | Returns the balance based on transaction history                     |
|           |                                  | The user does not have a transaction history | Returns the balance as 0                                             |
|           | RequestOverdraft                 |                                              | Submits a request for the overdraft amount                           |
|           | Location                         |                                              | Stores the location of the user                                      |
| Manager   | ApproveOverdraftRequests(amount) |                                              | Approves all overdrafts in the list where overdraft amount <= amount |
|           | RejectOverdraftRequests(amount)  |                                              | Rejects all overdrafts in the list where overdraft amount >= amount  |
|           | ApproveOverdraftRequests()       |                                              | Approve all overdrafts                                               |
|           | RejectOverdraftRequests()        |                                              | Rejects all overdrafts                                               |
|           | ApproveOverdraftRequests(id)     | Overdraft with id exists                     | Approves the overdraft with the id                                   |
|           |                                  | Overdraft with id does not exist             | Prints a message that id does not exist and returns false            |
|           | RejectOverdraftRequests(id)      | Overdraft with id exists                     | Rejects the overdraft with the id                                    |
|           |                                  | Overdraft with id does not exist             | Prints a message that id does not exist and returns false            |
| Bank      | Location                         |                                              | Stores the location of the bank                                      |
