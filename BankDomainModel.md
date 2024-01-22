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
		<tr>
			<td><code>Customer</code></td>
			<td><code>AddAccount(IAccount account)</code></td>
			<td>Creates an account for the user with the given account name</td>
			<td>void</td>
		</tr>
		<tr>
			<td><code>IAccount</code></td>
			<td><code>GenerateBankStatements(double amount)</code></td>
			<td>Prints all transactions, showing transaction date, amount, and balance
			at the time of the transaction.</td>
			<td>void</td>
		</tr>
		<tr>
			<td></td>
			<td><code>Deposit(double amount)</code></td>
			<td>Deposit an amount of money into the specified account. 
			Returns true if successful, otherwise false</td>
			<td>bool</td>
		</tr>
		<tr>
			<td></td>
			<td><code>Withdraw(double amount)</code></td>
			<td>Withdraw an amount of money from the specified account. Returns the amount withdrawn.</td>
			<td>double</td>
		</tr>
	</tbody>
</table>

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

<table>
	<thead>
		<td>Class</td>
		<td>Method</td>
		<td>Description</td>
		<td>Output Type</td>
	</thead>
	<tbody>
		<tr>
			<td><code>Branch</code></td>
			<td><code>ReviewRequests(bool approved)</code></td>
			<td>Reviews all requests from customer, allowing a manager to 
			approve or deny the requests</td>
			<td>void</td>
		</tr>
		<tr>
			<td><code>Customer</code></td>
			<td><code>RequestOverdraft(Account account)</code></td>
			<td>Requests an overdraft to the customers bank manager.
			Returns true if accepted, otherwise false</td>
			<td>bool</td>
		</tr>
		<tr>
			<td><code>IAccount</code></td>
			<td><code>MessageStatements()</code></td>
			<td>Sends the statements to the customers phone via SMS</td>
			<td>void</td>
		</tr>
	</tbody>
</table>