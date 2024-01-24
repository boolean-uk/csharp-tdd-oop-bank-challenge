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



Create Current Account(Should be able to withdraw and save money to account)

Create Savings Account(Should be able to withdraw and save money to account)

Generate Bank Statements(Print out transaction dates, amounts, currentBalance)

Deposit Funds
Withdraw Funds

When depositing and withdrawing funds, create DateTime.now()
the return of the deposit and withdrawals should be stored somewhere.

public class Transactions

double amount;
DateTime = _datetime;
double balance;


public abstract class Account
methods:
Deposit - Deposits a specified amount to the account calling the method.
Withdraw - Withraws a specified amount from the account calling the method.
printTransactions - prints out an iterated list of all transactions that have been made.
(Account needs a List of Transactions.)




-----------------------------------------------------------------------------------------------
|Classes:				| Methods:									| Scenario		| Output	|
|						|											|				|			|
|						|											|				|			|
|`Accounts`(Parent)		|`Deposit(Transactions transaction)`		|				|void		|
|`CurrentAccount`(Child)|`Withdraw(Transactions transaction)`		|				|void		|
|`SavingsAccount`(Child)|`getBalance()`								|				|int		|
|						|`printStatement()`							|				|void		|
|						|											|				|			|
|`Transaction`			|											|				|			|
|						|											|				|			|
|						|											|				|			|
|						|											|				|			|
|						|											|				|			|
|						|											|				|			|
|						|											|				|			|
