
## User Stories: 

1. As a customer,
So I can safely store use my money,
I want to create a current account.

2. As a customer,
So I can save for a rainy day,
I want to create a savings account.

3. As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

4. As a customer,
So I can use my account,
I want to deposit and withdraw funds.

## Extended User Stories: 

5. As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

6. As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

7. As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

8. As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

9. As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.

## Developers User Stories: 
*stories to ensure that all requirements are fulfilled*

10. As a developer,
So that object-oriented principles are demonstrated, 
I want to utilze Encapsulation, and Polymorphism

11. As a developer,
So that I can demonstrate usage of Inheritence in my solution,
I want to utilze Inheritence


# Domain model

| User Story Id | Class            | Method/Property             | Scenario                                                                                                  | Output                                                                                |
|---------------|------------------|-----------------------------|-----------------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------|
| 1             |  Bank         | AddAccount            |  User wants to create a account to put money into                                                           | A Personal account is created that can contain currency                                                           |
| 7             |  Bank | RequestOverdraft | User wants to request their account to be able to overdraft when their balance is too low for a purchase | request is collected and awaited to be handled by staff |
| 7, 8             |  Bank | listOverdraftRequests | Staff wants to know all unhandled overdraft requests | a list of overdraft requests is returned and presented |
| 7, 8           |  Bank | ApproveOverdraftRequest | Staff provides a accountID, to accept overdraft request | account will now to be able to overdraw to the requested amount  |
| 10              | Bank | AccountDictionary            | allows for polymorphism  | allows for all accounts subclass instances to be stored in one single container |
|              | |             |  | |
| 1             |  CurrentAccount | inherit from Account | differentiate between Current and Saving account types |  |
| 7             |  CurrentAccount | Overdraft (prop, from IOverdraftable interface) | User does not have any money, but like to buy something anyway. | If Overdraft is setup, money will be withdrawn from that amount until limit is reached |
| 7             |  CurrentAccount | Overdraft (prop) | Only CurrentAccount may request and use Overdraft... | other AccountTypes does not have it |
|              | |             |  | |
| 7,10             |  IOverdraftable | interface | defined contract required for a account to be able to overdraft | |
|              | |             |  | |
| 2             |  SavingsAccount | inherit from Account | differentiate between Current and Saving account types | SavingsAccount does not support overdrafting... (by my design)  |
|              | |             |  | |
| 11             | Account  |  Abstract class  | Will be inherited by CurrentAccount class and SavingsAccount class | |
| 3             |  Account | AccountID (prop:int)             | To differenciate and reference account | A Personal account is created that can contain currency |
| 4             |  Account |  Withdraw | User wants to withdraw money from the acconut | money is withdrawn, given requested amount is present |
| 4             |  Account |  Withdraw | User tries to withdraw more money than they have | no money is withdrawn |
| 4             |  Account |  Deposit | User wants to deposit money to the acconut | money is inserted into the account |
| 4             |  Account |  Deposit | User tries to deposit a negative sum | no money is deposited |
| 4             |  Account |  Records (prop:Dictionary<Date,Record>) | Records are kept per Account | a account stores all its transaction in Records |
| 5             |  Account |  GetBalance (prop) | User request to see account balance | the current balance is calculated based on the records and returned |
| 6             |  Account |  Branch (prop) | Accounts belongs to a certain Branch | the branch of which a account belongs to is definied in the account |
| 9             |  Account | RequestStatement | User wants a summary of all the transactions over a specific period of time | a list of Records is returned |
| 9             |  Account | PresentStatements | User wants to see the Statemnt for a given time period | The statement is presented in a terminal (substitute for sms) |
|              | |             |  | |
| 3             | Record |  Constructor           | A record contains  all bank transactions for a account  | purpose to store records  with info regarding transactions, their dates, amounts, balance at the time of transaction |
| 3             | Record |  TransactionDate (prop:DateTime)           | user wants to know what date a transaction occured  | Date is stored in the record |
| 3             | Record |  From (prop:AccountID)           | user wants to know where the transaction came from | From is stored in the record |
| 3             | Record |  To (prop:AccountID)           | user wants to know where the transaction ended up | To stored in the record |
| 3             | Record |  BalanceAtTransaction           | user wants to know where the transaction ended up | To stored in the record |
|              | |             |  | |


<!-- | 7, 8           |  Bank | HandleOverdraftRequest | loop through all requests, lets the staff answer individually |   | -->
<!--|              | |             |  | |-->
<!--|              | |             |  | |-->