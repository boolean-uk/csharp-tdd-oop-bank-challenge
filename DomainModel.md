
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
```

----------------------------------------------------------

class User
	METHODS:
		public CurrentAccount CreateCurrent(BranchCode)
		public SavingsAccount CreateSavings(BranchCode)

----------------------------------------------------------

abstract class Account 
	PROPERTIES:
		public BranchCode branchCode {get;}
		public List<Transaction> transactions {get;}
		public Queue<Overdraft> overdraftRequests {get;}
		
	METHODS:
		public Account(BranchCode branchCode)

		public float GetBalance() //Return current balance

		public bool DepositMoney(float amount) 
			return false if depositing negative or 0 amount

		public bool WithdrawMoney(float amount)
			return false if withdrawing more than balance or negetive amount or 0

		public List<string> GenerateBankStatement() //Also print to console

		public bool RequestOverdraft(float amount)
			// Check that the withdrawal exceeds the balance amount, not 0, not -i

		public bool RejectOverdraft()

		public bool ApproveOverdraft()

		public void RequestSMSNotificaiton(Account account)

class savingsAccount : Account

class currentAccunt : Account

public enum BranchCode

----------------------------------------------------------

class Transaction
	PROPERTIES:
		pulic float amount {get;}

		public bool isCredit {get;}

		public DateOnly transactionDate {get;} // Initialized at creation

	METHODS:
		Transaction(float amount, bool isCredit) //constructor

class Overdraft : Transaction // isCredit locked to false

