Domain Models

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
