#User Stories Extensions

```
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
```


User Story 1
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

Classes                 Members/Attributes                            Methods                       Scenario                                                       Outputs
'BankAccount'           'List<Transaction> Transactions'             'Deposit(decimal amount)'      Deposits a specified amount into the account.                  True if the deposit is successful, false otherwise.
                                                                     'Withdraw(decimal amount)'     Withdraws a specified amount from the account.                 True if the withdrawal is successful, false otherwise.
                                                                     'GenerateStatement()'          Generates a bank statement for the current account.            Bank statement with transaction details. 
                                                                     'CalculateBalance()'           Calculates account balance based on transaction history.
 

User Story 2
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

Classes                 Members/Attributes                            Methods                       Scenario                                                       Outputs
'Branch'               'List<Account> Accounts'                                                     Manages accounts associated with the branch.
                                     
 
User story 3
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

Classes                 Members/Attributes                            Methods                       Scenario                                                       Outputs
'BankAccount'           'List<Transaction> Transactions'             'Deposit(decimal amount)'      Deposits a specified amount into the account.                  True if the deposit is successful, false otherwise.
                                                                     'Withdraw(decimal amount)'     Withdraws a specified amount from the account.                 True if the withdrawal is successful, false otherwise.
                                                                     'GenerateStatement()'          Generates a bank statement for the current account.            Bank statement with transaction details. 
                                                                     'CalculateBalance()'           Calculates account balance based on transaction history.
                        'bool OverdraftRequested'                    'RequestOverdraft()'           Customer requests an overdraft on their account.               True if the overdraft request is successful, false otherwise.


User story 4
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

Classes                 Members/Attributes                            Methods                       Scenario                                                       Outputs
'Overdraft'            'Account Requesting'                           'Approve()'                   Bank manager approves the overdraft request.                   True if the overdraft request is approved, false otherwise.
                       'bool OverdraftRequested'                      'Reject()'                    Bank manager rejects the overdraft request.                    True if the overdraft request is rejected, false otherwise.


User Story 5
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.

Classes                 Members/Attributes                            Methods                       Scenario                                                        Outputs
'PhoneMessage'                                                        'SendStatement()'	            Sends account statement as a message to the customer's phone.   Message containing the account statement is sent  
                                     
 




