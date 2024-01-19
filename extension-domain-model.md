# Extension Domain Model 

# User Stories 

1.
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

2.
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

3.
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

4.
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

5.
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.


| Classes                | Methods                                                | Scenario                                                                                   | Expected Output                                                                         |
|------------------------|--------------------------------------------------------|--------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------|
| `Account`              | `SendStatementToPhone()`                               | `Sending a statement via text message to a phone number.`                                  | `A statement is sent via text message to the phone number provided.`                    |
| `CurrentAccount`       | `RequestOverdraft(decimal amount)`                     | `Making an overdraft request.`                                                             | `The overdraft is applied to balance.`                                                  |
| `CurrentAccount`       | `ApproveOverdraftRequests()`                           | `Approving or rejecting an overdraft request.`                                             | `The overdraft request is either approved or not.`                                      |
| `SavingaAccount`       | `CalculateInterest()`                                  | `Calculating interest and adding it to balance.`                                           | `The interest is applied to balance.`                                                   |
