# 1. Extract domain models from user stories

```
1.
As a customer,
So I can safely store use my money,
I want to create a current account.
```
| Classes						| Methods                                     | Scenario  | Outputs |
|-------------------------------|---------------------------------------------|-----------|---------|
| `Customer : CurrentAccount`	| `CurrentAccount(decimal balance)`	  	      |           |         |
|                               |                                             |           |         |


```
2.
As a customer,
So I can save for a rainy day,
I want to create a savings account.
```
| Classes						| Methods                                     | Scenario  | Outputs |
|-------------------------------|---------------------------------------------|-----------|---------|
| `Customer : SavingsAccount`	| `SavingsAccount(decimal balance)`	  	      |           |         |
|                               |                                             |           |         |


```
3.
As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
```
| Classes						| Methods                                     | Scenario  | Outputs          |
|-------------------------------|---------------------------------------------|-----------|------------------|
| `Customer : Account`	        | `printBankStatement`	  	                  |           | list<Transaction |
|                               |                                             |           |                  |


```
4.
As a customer,
So I can use my account,
I want to deposit and withdraw funds.
```
| Classes						| Methods                                     | Scenario             | Outputs |
|-------------------------------|---------------------------------------------|----------------------|---------|
| `Customer : Account`	        | `deposit(decimal amount)`	  	              | amount>0             | true    |
| `Customer : Account`          | `deposit(decimal amount)`                   | Balance - amount >=0 | true    |


```
5.
As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.
```
| Classes						| Methods                                     | Scenario  | Outputs          |
|-------------------------------|---------------------------------------------|-----------|------------------|
| `Engineer : EngineerAccount`	| `deposit(decimal amount)`	  	              |           |                  |
|                               | `withdraw(decimal amount)`	              |           |                  |


```
6.
As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.
```
| Classes						| Methods                                     | Scenario  | Outputs          |
|-------------------------------|---------------------------------------------|-----------|------------------|
| `Manager : ManagerAccount`	| `addBranch(string branch)`	  	          | Current   |  void            |
|                               | `addBranch(string branch)`	              | Savings   |  void            |



```
7.
As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.
```
| Classes         | Methods                                                          | Scenario               | Outputs |
|-----------------|------------------------------------------------------------------|------------------------|---------|
| `Extension`	  | `requestFound(User user1,User user2,Account account,int amount`	 | If user1 is Customer   | true    |
|                 |                                                                  | If user1 != Customer   | false   |


```
8.
As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.
```
| Classes         | Methods                                                           | Scenario               | Outputs |
|-----------------|-------------------------------------------------------------------|------------------------|---------|
| `Extension`	  | `foundManage(User user,Account account,KeyValuePair<User,int> Kvp`| If user is Manager     | true    |
|                 |                                                                   | If kvp.Value<500       | true    |

```
9.
As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.
```
| Classes         | Methods                                     | Scenario   | Outputs |
|-----------------|---------------------------------------------|------------|---------|
| `Core`		  | `send (string message`   					|            |         |
|                 |                                             |            |         |