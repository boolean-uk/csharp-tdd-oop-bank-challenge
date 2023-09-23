# Domain Model 

# User Stories 

1.
As a customer,
So I can safely store use my money,
I want to create a current account.

2. 
1. As a customer,
So I can save for a rainy day,
I want to create a savings account.

3.
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

4.
As a customer,
So I can use my account,
I want to deposit and withdraw funds.


| Classes                | Methods                                                | Scenario                                                                                   | Expected Output                                                                         |
|------------------------|--------------------------------------------------------|--------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------|
| `Account`              | `Deposit(decimal amount, DateTime? date = null)`       | `Making a deposit of an amount into an account.`                                           | `The updated balance of the account is returned.`                                       |
|                        | `Withdraw(decimal amount, DateTime? date = null)`      | `Making a withdraw of an amount from an account.`                                          | `The updated balance of the account is returned.`                                       |
|                        | `GenerateStatement()`                                  | `Generating a bank statement with all the transactions made.`                              | `A bank statement with all the transactions made is generated.`                         |
|                        | `CalculateBalance()`                                   | `Calculating the balance of an account.`                                                   | `The balance of the account is returned.`                                               |
| `Program`              | `PrintBankStatement(BankStatement statement)`          | `Printing a bank statement with all the transactions made.`                                | `A bank statement with all the transactions made is printed.`                           |
