
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
```

class User
	PROPERTIES:
		private List<Account> accounts

	METHODS:
		public bool CreateCurrent()
			If there already is an current account return false

		public bool CreateSavings()
			If there already is an savings account return false

class Account 
	PROPERTIES:
		private float balance
		private List<Transaction> transactions
		
	METHODS:
		public bool DepositMoney(float money) 
			return false if depositing negative amount

		public bool WithdrawMoney(float money)
			return false if withdrawing more than balance or negetive amount

		public string[] GenerateBankStatement() //Also print to console

class savingsAccount : Account

class currentAccunt : Account

struct Transaction
	PROPERTIES:
		private DateOnly transactionDate {get;}
		private float amount {get;}
		private bool isCredit {get;}
		private float balance {get;}

	METHODS:
		Transaction(float amount, DateTime date, bool isCredit, float balance) //constructor