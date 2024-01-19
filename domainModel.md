```
As a customer,
So I can safely store use my money,
I want to create a current account.
```
| Classes         | Methods                                     | Scenario               | Outputs                     |
|-----------------|---------------------------------------------|------------------------|-----------------------------|
| `Bank`	      | `createAccount(Customer c, AccountType t)`  | If account was created | Account                     |
|                 |                                             | Else	                 | null, prints error message  |

```
As a customer,
So I can save for a rainy day,
I want to create a savings account.
```
| Classes         | Methods                                     | Scenario               | Outputs                     |
|-----------------|---------------------------------------------|------------------------|-----------------------------|
| `Bank`	      | `createAccount(Customer c, AccountType t)`  | If account was created | Account                     |
|                 |                                             | Else	                 | null, prints error message  |

```
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
```
| Classes         | Methods                                     | Scenario               | Outputs                     |
|-----------------|---------------------------------------------|------------------------|-----------------------------|
| `Account`       | `generateStatement()`                       | any                    | string bankstatement        |

```
As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```
| Classes         | Methods                                     | Scenario                 | Outputs                         |
|-----------------|---------------------------------------------|--------------------------|---------------------------------|
| `Account`	      | `deposit(double amount)`                    | If account doesn't exist | false, prints "Invalid account" |
|                 |                                             | If amount <= 0	       | false, prints "Invalid amount to deposit, must be greater than 0"     |
|                 |                                             | Else           	       | true                            |
| `Account`	      | `withdraw(double amount)`                   | If account doesn't exist | false, prints "Invalid account" |
|                 |                                             | If amount > balance      | false, prints $"Balance too low to withdraw {amount}" |
|                 |                                             | Else	                   | true                            |