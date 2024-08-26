| Class			| method						| Scenario						| Output				|
|---------------|-------------------------------|-------------------------------|-----------------------|
| `Bank`		| createCurrentAccount(Customer)| Creates a current account		| Returns Account		|
| `Bank`		| createSavingsAccount(Customer)| Creates a savings account		| Returns Account		|
| `Customer`    | getTransactionHistory(Account)| Get the transaction history	| Returns List          |
| `Customer`    | deposit(money, Accounnt)      | Deposits money to account     | true					|
| `Customer`    | withDraw(money, account)      | withdraws money from account  | true                  |
| `Account`		| getBalance()					| calculates balance from transactions| float			|
| `Account`		| getBranch()					| returns affiliated branch		| string				|
| `Customer`    | requestOverDraft(Account)     | requests an overdraft			| void					|
| `Bank`        | approveRequest(Request)		| Approve overdraft request     | void					|
| `Bank`		| rejectRequest(Request)		| rejects overdraft request		| void					|
| `Account`	    | sendTransaction()				| sends transaction data		| true					|
