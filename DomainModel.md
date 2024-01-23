

As a customer,
So I can safely store use my money,
I want to create a current account.

| Classes         | Methods												  | Scenario               | Outputs   |
|-----------------|-------------------------------------------------------|------------------------|-----------|
| `Customer		` | `CreateAccount(Enum accountType, string accountName)` |		 	 			   | void	   |
| `Currentaccount`|													      |						   |		   |

As a customer,
So I can save for a rainy day,
I want to create a savings account.
| Classes         | Methods								                   | Scenario               | Outputs |
|-----------------|--------------------------------------------------------|------------------------|---------|
| `Customer`	  | `CreateAccount(Enum accountType, string accountName))` |						|void     |
| `SavingsAccount`|							                               |						|		  |

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.
| Classes         | Methods                                     | Scenario                  | Outputs								 |
|-----------------|---------------------------------------------|---------------------------|----------------------------------------|
| `BankStatement` | `Statement(Account acc)`					| There are transactions    | print dates, times, ammountsm, balance |
| `Account`       |                                             | There are no transactions | print error message				     |

As a customer,
So I can use my account,
I want to deposit and withdraw funds.
| Classes         | Methods                                     | Scenario					   | Outputs |
|-----------------|---------------------------------------------|------------------------------|---------|
| `Account`		  | `Withdraw(double sum)`						| If there is enough money     | true    |
|                 |						                        | If there is not enough money | false   |
|				  | `Deposit(double sum)`					    |							   | void	 |

# Extensions

As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.
| Classes         | Methods                                     | Scenario               | Outputs 		  |
|-----------------|---------------------------------------------|------------------------|----------------|
| `IAccount`	  | `Balance()`									| 						 | double ammount |
|				  |                                             |						 |				  |

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.
| Classes         | Methods                                     | Scenario               | Outputs     |
|-----------------|---------------------------------------------|------------------------|-------------|
| `Account`		  | `get, set(enum branch)`						|						 | enum branch |
|				  |                                             |						 |			   |


As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.
| Classes         | Methods                                     | Scenario											   | Outputs				  |
|-----------------|---------------------------------------------|------------------------------------------------------|--------------------------|
| `Customer`	  | `RequestOverdraft()`						| insatiate an overdraft class and pass it into a list |Overdraft overdraftRequest|
| `Overdraft`	  |                                             |													   |			      		  |

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.
| Classes         | Methods                                     | Scenario               | Outputs	    |
|-----------------|---------------------------------------------|------------------------|--------------|
| `Manager`		  | `RespondOverdraft(Overdraft od)`			| Aproved				 | double value |
| `Overdraft`	  |                                             | Reject				 | 0			|


As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.