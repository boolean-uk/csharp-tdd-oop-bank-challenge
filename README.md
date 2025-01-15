# Domain model

## Classes

### Transaction

| Method      | Params               | Action | Returns |
|-------------|----------------------|--------|---------|
| Transaction | decimal balance, TransactionType type, DateTime? date |        | Transaction        |


### Account (abstract class)
| Method   | Params         | Action                       | Returns |
|----------|----------------|------------------------------|---------|
| Account  | Role owner |                              |         |
| Withdraw | decimal amount | Withdraws money from account | bool    |
| Deposit  | decimal amount | Deposits money into account  | bool    |
| CalculateBalance|  | Calculate the balance  | void    |
| ToString |                | Returns an account statement | string        |

### SavingAccount
| Method   | Params         | Action                       | Returns |
|----------|----------------|------------------------------|---------|
| SavingAccount  | Role owner  |  Extends account class                            |   Account      |

### CurrentAccount
| Method   | Params         | Action                       | Returns |
|----------|----------------|------------------------------|---------|
| CurrentAccount  | Role owner  |  Extends account class                            | Account        |
| OverdraftLimit  | decimal amount  |  How much the account can overdraft                            | decimal        |

### OverdraftRequest
| Method           | Params                                     | Action                                               | Returns |
|------------------|--------------------------------------------|------------------------------------------------------|---------|
| OverdraftRequest | ref IOverdraftable account |                                                      | OverdraftRequest    |
| Overdraft			| decimal amount                             | Requests an overdraft to account | bool |
| Approve          |                              | Approves the request | void    |
| Reject          |                              | Rejects the request | void    |

### MessageProvider
Message API is to be determined

| Method | Params                           | Action                      | Returns    |
|--------|----------------------------------|-----------------------------|------------|
| Message       | string message                                 | Constructs a new message object                             |  Message          |
| SendMessage   |  | Send a message to recipient | Task<bool> |


### IOverdraftable (interface)

| Method/variable | Params | Action      | Return  |
|-----------------|--------|-------------|---------|
| OverdraftLimit  |        | Get and set | decimal |

### IMessage (interface)

| Method/variable | Params | Action      | Return  |
|-----------------|--------|-------------|---------|
| Message  |        | Get and set | string |

### IBalanceRequest (interface)

| Method/variable | Params | Action      | Return  |
|-----------------|--------|-------------|---------|
| Balance |        | Get and set | decimal |




### Enums (enum)

| EnumType | Return |
|----------|--------|
| Role| Role |
| TransactionType | TransactionType|
| Branch  | Branch|

### Class diagram
![classDiagram.png](puml/classDiagram.png)

