#User Stories

```
As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```


User Story 1
As a customer,
So I can safely store use my money,
I want to create a current account.

Classes                 Members/Attributes                           Methods                      Scenario                                                  Outputs

'CurrentAccount'        'List<Transaction> Transactions'             'Deposit(double amount)'     Deposits a specified amount into the current account.     True if the deposit is successful, false otherwise.
                                                                     'Withdraw(double amount)'    Withdraws a specified amount from the current account.    True if the withdrawal is successful, false otherwise.
                                                                     'GenerateStatement()'        Generates a bank statement for the current account.       Bank statement with transaction details. 

##CurrentAccount Inheritrs from BankAccount, but to see it visually i added everything


User Story 2
As a customer,
So I can save for a rainy day,
I want to create a savings account.

Classes                 Members/Attributes                           Methods                      Scenario                                                  Outputs

'SavingsAccount'        'List<Transaction> Transactions'             'Deposit(double amount)'     Deposits a specified amount into the current account.     True if the deposit is successful, false otherwise.
                                                                     'Withdraw(double amount)'    Withdraws a specified amount from the current account.    True if the withdrawal is successful, false otherwise.
                                                                     'GenerateStatement()'        Generates a bank statement for the current account.       Bank statement with transaction details. 

##SavingsAccount Inheritrs from BankAccount, but to see it visually i added everything




User story 3
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.


Classes                 Members/Attributes                           Methods                       Scenario                                                  Outputs

'Transaction'          'DateTime Date, double Amount'               'GetTransactionDate()'         Retrieves the date of the transaction.                    Transaction date (DateTime).
                       'string Type, double Balance'                'GetTransactionAmount()'       Retrieves the amount of the transaction.                  Transaction amount (double).
                                                                    'GetTransactionBalance()'      Retrieves the balance of the transaction.                 Transaction balance (double).



User story 4
As a customer,
So I can use my account,
I want to deposit and withdraw funds.

Classes                 Members/Attributes                            Methods                       Scenario                                                  Outputs
'BankAccount'           'List<Transaction> Transactions'             'Deposit(decimal amount)'      Deposits a specified amount into the account.             True if the deposit is successful, false otherwise.
                                                                     'Withdraw(decimal amount)'     Withdraws a specified amount from the account.            True if the withdrawal is successful, false otherwise.
                                                                     'GenerateStatement()'          Generates a bank statement for the current account.       Bank statement with transaction details. 

 

Brainstorming: Structure idea
                                                                     
 - Accounts
  - CurrentAccount.cs -> CurrentAccount : BankAccount
  - SavingsAccount.cs -> SavingsAccount : BankAccount
  - ABSTRACT BankAccount.cs
- Transactions
  - Transaction.cs
- Interfaces
  - ITransactionable.cs
- Tests
  - CurrentAccountTests.cs
  - SavingsAccountTests.cs
  - BankAccountTests.cs
  - TransactionTests.cs
