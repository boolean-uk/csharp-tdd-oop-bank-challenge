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
- Holds each account conected to a string that describes the account. 

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

public string GetAcountBalance() 
-retuns balance of account

public string DepositMoney(double amount)
if transaction is possible store the provided information in transation and then add it to the transactionList.
-returns a message saying if it was able to add money to the account.

public WithdrawalMoney(double amount)
if transaction is possible store the provided information in transation and then add it to the transactionList.
-returns a message saying if it was able to remove money from the account.

public List<string> GetTransactionHistory()
returns a list of strings of all transaction history.
also prints it in the console.

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


______________________________________________________________________

Refactoring Extension

As an engineer,
So I don't need to keep track of state,
I want account balances to be calculated based on transaction history instead of stored in memory.

Remove balance and present value from a function that calculates the balance from transactions.

As a bank manager,
So I can expand,
I want accounts to be associated with specific branches.

create an enum for specific branches ad to base account.

As a customer,
So I have an emergency fund,
I want to be able to request an overdraft on my account.

create a overdraftrequest class. it should be sent to a manager. it should contain how much is requested and a bool for approved or rejected 
make it posible to take out more than what is on the account.

As a bank manager,
So I can safeguard our funds,
I want to approve or reject overdraft requests.

create a class for manager. it should have a list  of overdraft requests to approve or reject.

As a customer,
So I can stay up to date,
I want statements to be sent as messages to my phone.

figure it out or make the statements go to the console.

_________________________________________________________________________________________


enum BankBranch
{
	    London, 
        Stockholm, 
        Liverpool, 
        Gothenburg
}

__________________________________________________________________________________________

public class customer()

Properties 


private IDictionary<string,Account>() _myBankAcounts 
- Holds each account conected to a string that describes the account. 

public IDictionary<string,Account>() MyBankAcounts { Get{return _myBankAcounts } }

Methods

public Create Account(string accountName, AccountType) 

__________________________________________________________________________________________

public Class Account()

Properties


private string _accountID

public string AccountID {Get{return _accountID}}

 private OverdraftRequest _overdraftRequest;

private List<Transaction> _transactionHistory;

public Account() constructor for instansiating the list.

public List<Transation> TransactionHistory {Get{return _transactionHistory}} // not possible because Transaction as an internal class can not exist in a public list

private bool _makeAnOverdraftRequests default false  // to be able to do tests without human input i made a bool to determine weather or not a person wants to make an overdraft requests.

public bool makeAnOverdraftRequests {Get{return _makeAnOverdraftRequests}}

private BankBranch _bankBranch;
public BankBranch BankBranch {get{return _bankBranch}}

Methods 

public string GetAcountBalance() 
calculate balance from transaction history.
-retuns balance of account

public string DepositMoney(double amount)
if transaction is possible store the provided information in transation and then add it to the transactionList.
-returns a message saying if it was able to add money to the account.

public WithdrawalMoney(double amount)
if transaction is possible store the provided information in transation and then add it to the transactionList.
-returns a message saying if it was able to remove money from the account.
-if the withdrawal is larger than what is left calculate the excess and and "ask" if you want an overcharege request to be made.  
-if yes, make a request and depending on amount requested it might be approved or denied.

public List<string> GetTransactionHistory()
returns a list of strings of all transaction history.
also prints it in the console.

private bool IsTransactionPossible()
- calling this method throws an exception with a custom message.

private void SendMessageToPhone(string message) sends message to phone/Concole in this case
___________________________________________________________________________________________
public class TransactionNotPossible() used to throw custom errors where the code should throw errors.


____________________________________________________________________________________________

Internal Class Transaction() //Del av Account

Properties 
private string _transactionDate
private double _creditIn
private double _debitOut
private double _ballance //only used to store the balance at the time of the transacton. only used in displaying the history. not used for calculations


public Transaction(double MoneyIn, double MoneyOut) saves current Date to transactionDate

public string transactionDate readonly
public double creditIn readonly
public double debitOut readonly
public double ballance readonly



_____________________________________________________________________

public class SavingsAccount : Account




_____________________________________________________________________

public class GenericAccount : Account

______________________________________________________________________

public class BankManager

properties
private overdraftRequest


methods
public BankManager(overdraftRequest)

public overdraftRequest lookAtRequest() returns the given overdraftRequest with either of the status Approved or Denied




______________________________________________________________________

public class overdraftRequest

properties

enum RequestStatus Approved, Denied or default "waiting_for_answer"

private double _amountRequested
public double amountRequested.

private RequestStatus _status.
 
public RequestStatus status. readonly

methods 

public SetStatus(RequestStatus status) stets the status of the overdraftRequest status to the provided status.


