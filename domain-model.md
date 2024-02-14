```
As a customer,
So I can safely store and use my money,
I want to create a current account.
```

```
As a customer,
So I can save for a rainy day,
I want to create a savings account.
```

```
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
```

```
As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```

| Classes  | Methods                     | Function                                           | Scenario                 | Output                |
|----------|-----------------------------|----------------------------------------------------|--------------------------|-----------------------|
| Bank     | createCustomer(string name) | Creates a customer in the bank                     | Creates customer         | Customer              |
| Customer | createChecking(string name) | Creates an account in the bank                     | Creates account          | Checking Account      |
| Customer | createSavings(string name)  | Creates a savings account in the bank              | Creates account          | Savings Account       |
| Account  | showHistory()               | Generate bank statements with various information. | Generates bank statement | Strings/Stringbuilder |
| Account  | deposit(double amount)      | Deposit money into the account                     | Deposits money           | double                |
| Account  | withdraw(double amount)     | Withdraws money from the account                   | Withdraws money          | double                |
|          |                             |                                                    | Not enough money         | error                 |
