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



| Classes         | Methods																| Scenario								| Outputs					|
|-----------------|---------------------------------------------------------------------|---------------------------------------|---------------------------|
| `Bank`		  | `CalculateBalance(int bankID)`										|										| double					|
|				  |																		|										|							|
|				  |	`AddAccount(string user, string bankType, string branch)`			| Branch does not exist										| string					|
| 				  |																		|										|							|
|				  |	`Withdraw(int bankId, double amount)`								|										| int						|
| 				  |																		|										|							|
| `Account`       | `PrintBankStateMents()`												|										| string					|