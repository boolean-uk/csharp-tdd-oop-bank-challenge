As a customer,
So I can safely store use my money,
I want to create a current account.

As a customer,
So I can save for a rainy day,
I want to create a savings account.

As a customer,
So I can keep a record of my finances,
I want to generate bank statements with transaction dates, amounts, and balance at the time of transaction.

something thet records money in/out that would probably be stored in the account itself

As a customer,
So I can use my account,
I want to deposit and withdraw funds.

_________________________________________________________________________

Acceptance Criteria

Given a client makes a deposit of 1000 on 10-01-2012
And a deposit of 2000 on 13-01-2012
And a withdrawal of 500 on 14-01-2012
When she prints her bank statement
Then she would see:

date       || credit  || debit  || balance
14/01/2012 ||         || 500.00 || 2500.00
13/01/2012 || 2000.00 ||        || 3000.00
10/01/2012 || 1000.00 ||        || 1000.00

_________________________________________________________________________________________

enum AccountType
{
	Generic, Saving
}

__________________________________________________________________________________________

public class customer()

Properties 


private IDictionary<string,Account>() _myBankAcounts 
- Holds each acount conected to a string that describes the account. 

public IDictionary<string,Account>() MyBankAcounts { Get{return _myBankAcounts } }

Methods

public Create Account(string accountName, AccountType) 

__________________________________________________________________________________________

public Class Account()

Properties

private double _balance; default 0;

public double Balance {Get{return _balance}}

private string _accountID

public string AccountID {Get{return _accountID}}



private List<Transaction> _transactionHistory;

public Account() constructor for instansiating the list.

public List<Transation> TransactionHistory {Get{return _transactionHistory}} // not possible because Transaction as an internal class can not exist in a public list


Methods 

public void GetAcountBalance() 
-retuns balance of account

public string DepositMoney(double amount)
if transaction is possible store the provided information in transation and then add it to the transactionList.
-returns a message saying if it was able to add money to the account.

public WithdrawalMoney(double amount)
if transaction is possible store the provided information in transation and then add it to the transactionList.
-returns a message saying if it was able to remove money from the account.

private bool IsTransactionPossible()
-internal method for testing if its posible to do a transaction.

____________________________________________________________________________________________

Internal Class Transaction() //Del av Account

Properties 
private string transactionDate
private string creditIn
private string debitOut


public Transaction(double MoneyIn, double MoneyOut) saves current Date to transactionDate

public string transactionDate
public string creditIn
public string debitOut
public string ballance


_____________________________________________________________________

public class SavingsAccount : Account




_____________________________________________________________________

public class GenericAccount : Account
