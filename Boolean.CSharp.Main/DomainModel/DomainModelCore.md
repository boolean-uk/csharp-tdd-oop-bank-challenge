Domain Models for core

Class                | Attribute                                                 | Method                                      | Output
------------------------------------------------------------------------------------------------------------------------------------------------------
IAccount             |                                                           | deposit(double, DateTime)                   |
                     |                                                           | withdraw(double, DateTime)                  | 
                     |                                                           | printStatement()                            | String 
------------------------------------------------------------------------------------------------------------------------------------------------------
Account              | balance: double                                           | deposit(double, DateTime)                   | 
(Implements IAccount)| transactionList: List Transaction                         | withdraw(double, DateTime)                  | 
                     |                                                           | printStatement()                            | String
------------------------------------------------------------------------------------------------------------------------------------------------------
CurrentAccount       | Inherits from Account                                     |  All methods are inherited                  | 
(Implements IAccount)|                                                           |                                             | 
------------------------------------------------------------------------------------------------------------------------------------------------------
SavingsAccount       | Inherits from Account                                     |  All methods are inherited                  | 
(Implements IAccount)|                                                           |                                             | 
------------------------------------------------------------------------------------------------------------------------------------------------------
Transaction          | date: DateTime                                            |                                             | 
                     | credit: double                                            |                                             | 
                     | debit: double                                             |                                             | 
                     | balanceAtTransactionTime: double                          |                                             | 
------------------------------------------------------------------------------------------------------------------------------------------------------
For User Stories:
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