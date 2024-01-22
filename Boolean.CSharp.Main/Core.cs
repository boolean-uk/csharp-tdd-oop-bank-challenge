using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;


namespace Boolean.CSharp.Main
{
    
    //TransactionClass
    public class Transaction
    {
        //Properties
        public readonly string date;
        public readonly float ammount;
        public readonly string transactionType;
        public readonly string transactionId;

        //Constructor
        public Transaction(float ammount) 
        {
            //Set date, ammount & ID
            this.date = DateTime.Now.ToString("dd/MM/yyyy");
            this.ammount = ammount;
            this.transactionId = Guid.NewGuid().ToString();

            //transactionType is set automatically, in regards to which
            //amount you want to deposit/withdraw
            if (ammount >= 0)
            {
                this.transactionType = "Deposit";
            }
            else 
            {
                this.transactionType = "Withdraw";
            }

        }
    }

    //BankAccount Class
    public class BankAccount
    {
        //Properties
        public float currentBalance { get; private set; }
        public readonly List<float> balanceList;
        public List<Transaction> transactionsList { get; private set; }
        public readonly string AccountID;

        //Constructor, by default balance is 0.0,
        //transactionslists are empty
        //new GuID is generated
        public BankAccount()
        {
            this.currentBalance = 0.0f;
            this.balanceList = new List<float>();
            this.transactionsList = new List<Transaction>();
            this.AccountID = Guid.NewGuid().ToString();
        }

        //MakeTransactionfunction
        public void MakeTransaction(float ammount)
        {
            //check if there is enough money, and ammount in transaction is'nt zero
            //Probably there is much easier way to design this lol

            //Check ammount != 0.0
            if (ammount != 0.0f) 
            {
                //if ammount is negative and you want to make withdraw
                if (ammount < 0.0f) 
                {
                    //check if it's possible to withdraw given ammount
                    if (currentBalance + ammount >= 0)
                    {
                        //Register transaction
                        Transaction currentTransaction = new Transaction(ammount);
                        transactionsList.Add(currentTransaction);
                        currentBalance += ammount;
                        balanceList.Add(currentBalance);
                    }
                }
                //if you make deposit
                else
                {
                    //Register transaction
                    Transaction currentTransaction = new Transaction(ammount);
                    transactionsList.Add(currentTransaction);
                    currentBalance += ammount;
                    balanceList.Add(currentBalance);

                }
            }
        }

        //getBankStatement
        public string getBankStatement() 
        {
            //Empty string to begin with
            string bankStatement = string.Empty;
            int length = transactionsList.Count;

            //iterate through your transactionsList
            for (int i = 0; i< length; i++) 
            {
                //Add all info to the string (bankStatement)
                string date = transactionsList[i].date;
                string transactionType = transactionsList[i].transactionType;
                string ammount = transactionsList[i].ammount.ToString();
                string balance = balanceList[i].ToString();

                bankStatement = bankStatement + "\nDate: " + date + "|| TransactionType: " + transactionType + ": " + ammount + "|| Balance: " + balance;
            }
            return bankStatement;
        }

    }

    //CurrentAccount, almost identical to bankAccount, just one property differ
    public class CurrentAccount : BankAccount 
    {
        public readonly string accountType;

        public CurrentAccount()
        {
            this.accountType = "CurrentAccount";
        }
    }

    //Same with the savingsaccount, as the currentAccount
    public class  SavingsAccount : BankAccount
    {
        public readonly string accountType;

        public SavingsAccount() 
        {
            this.accountType = "SavingsAccount";
        }
    }
}
