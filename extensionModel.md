```
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.
```
| Classes         | Methods                                     | Scenario               | Outputs                     |
|-----------------|---------------------------------------------|------------------------|-----------------------------|
| `Account`       | `getBalance()`                              | any                    | decimal balance, now generated based on transaction history instead of getting balance value. |

```
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.
```
| Classes         | Methods                                     | Scenario               | Outputs                     |
|-----------------|---------------------------------------------|------------------------|-----------------------------|
| `Account`       | `Account(..., AccountBranches ab)`                | any                    | void                        |

```
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.
```
| Classes         | Methods                                     | Scenario               | Outputs                     |
|-----------------|---------------------------------------------|------------------------|-----------------------------|
| `Account`	      | `withdraw(decimal amount)`                  | If account doesn't exist | false, prints "Invalid account" |
|                 |                                             | If amount > balance      | false, creates a new overdraft request, prints $"Balance too low to withdraw {amount}. Overdraft request created." |
|                 |                                             | Else	                   | true                            |

```
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.
```
| Classes         | Methods                                     | Scenario               | Outputs                     |
|-----------------|---------------------------------------------|------------------------|-----------------------------|
| `Manage`	      | `handleOverdraft(Overdraft o, bool approve)`| If approve             | true, prints "Overdraft approved" |
|                 |                                             | Else	                 | fals,e prints "Overdraft denied"  |

```
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
```
| Classes         | Methods                                     | Scenario               | Outputs                     |
|-----------------|---------------------------------------------|------------------------|-----------------------------|
| `Customer`      | `sendStatement(Transaction t)`              | Any                    | void, sends an SMS with the transaction to customer phone |
| `Customer`      | `sendAllStatements()`                       | Any                    | void, sends an SMS with statements to customer phone |
| `Account`	      | `withdraw(double amount)`                   | Any                    | void, sends an SMS with the new transaction to customer phone |