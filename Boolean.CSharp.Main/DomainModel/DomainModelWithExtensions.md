Domain Models

Class                | Attribute                                                 | Method                                      | Output
------------------------------------------------------------------------------------------------------------------------------------------------------
IAccount             |                                                           | Deposit(double, DateTime)                   |
                     |                                                           | Withdraw(double, DateTime)                  | 
                     |                                                           | PrintStatement()                            | String 
                     |                                                           | GetBalance()                                | Double 
                     |                                                           | Branch()                                    | The branches
------------------------------------------------------------------------------------------------------------------------------------------------------
Account              | branch with Branches                                      | Deposit(double, DateTime)                   | 
(Implements IAccount)| transactionList: List Transaction                         | Withdraw(double, DateTime)                  | 
                     |                                                           | PrintStatement()                            | String
                     |                                                           | GetBalance()                                | Double
                     |                                                           | Branch()                                    | The branches
------------------------------------------------------------------------------------------------------------------------------------------------------
CurrentAccount       | Inherits attributes and methods from Account              |  All methods are inherited                  | 
(Implements IAccount)|                                                           |                                             | 
------------------------------------------------------------------------------------------------------------------------------------------------------
SavingsAccount       | Inherits attributes and methods from Account              |  All methods are inherited                  | 
(Implements IAccount)|                                                           |                                             | 
------------------------------------------------------------------------------------------------------------------------------------------------------
Transaction          | date: DateTime                                            |                                             | 
                     | credit: double                                            |                                             | 
                     | debit: double                                             |                                             | 
------------------------------------------------------------------------------------------------------------------------------------------------------

The extension stories
Extension 1
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

Extension 2
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

Extension 3
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

Extension 4
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

Extension 5
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.