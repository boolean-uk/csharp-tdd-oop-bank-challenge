
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
	METHODS:
		public CurrentAccount CreateCurrent()
		public SavingsAccount CreateSavings()


class Account 
	PROPERTIES:
		private float balance
		private List<Transaction> transactions
		
	METHODS:
		public float GetBalance()

		public bool DepositMoney(float amount) 
			return false if depositing negative or 0 amount

		public bool WithdrawMoney(float amount)
			return false if withdrawing more than balance or negetive amount or 0

		public List<string> GenerateBankStatement() //Also print to console

class savingsAccount : Account

class currentAccunt : Account

struct Transaction
	PROPERTIES:
		pulic float amount {get;}
		public float balance {get;}
		public bool isCredit {get;}
		public DateOnly transactionDate {get;} // Initialized at creation

	METHODS:
		Transaction(float amount, float balance, bool isCredit) //constructor