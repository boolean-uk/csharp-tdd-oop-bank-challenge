# Bank - Domain Model

```
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
```

<table>
	<thead>
		<td>Class</td>
		<td>Method</td>
		<td>Description</td>
		<td>Output Type</td>
	</thead>
	<tbody>
		<td><code>Customer</code></td>
		<td><code>CreateAccount(string accountName, AccountType type)</code></td>
		<td>Creates an account for the user with the given account name</td>
		<td>Account</td>
	</tbody>
	<tbody>
		<td><code>Account</code></td>
		<td><code>GenerateBankStatements()</code></td>
		<td>Prints all transactions, showing transaction date, amount, and balance
		at the time of the transaction.</td>
		<td>void</td>
	</tbody>
	<tbody>
		<td></td>
		<td><code>Deposit(double amount)</code></td>
		<td>Deposit an amount of money into the specified account. 
		Returns true if successful, otherwise false</td>
		<td>bool</td>
	</tbody>	
	<tbody>
		<td></td>
		<td><code>Withdraw(double amount)</code></td>
		<td>Withdraw an amount of money from the specified account. Returns the amount withdrawn.</td>
		<td>double</td>
	</tbody>
</table>