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
        public readonly float amount;
        public readonly string transactionType;
        public readonly string transactionId;

        //Constructor
        public Transaction(float amount) 
        {
            //Set date, amount & ID
            this.date = DateTime.Now.ToString("dd/MM/yyyy");
            this.amount = amount;
            this.transactionId = Guid.NewGuid().ToString();

            //transactionType is set automatically, in regards to which
            //amount you want to deposit/withdraw
            if (amount >= 0)
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
        public List<float> balanceList { get; private set; }
        public List<Transaction> transactionsList { get; private set; }
        public string AccountID { get; private set; }
        public string branch {  get; private set; }
        public bool haveOverdraftRequest { get; private set; }
        public bool approvedOverdraftRequest { get; private set; }
        public float overDraftRequestAmount { get; private set; }

        //Constructor, by default balance is 0.0,
        //transactionslists are empty
        //new GuID is generated
        public BankAccount()
        {
            this.currentBalance = 0.0f;
            this.balanceList = new List<float>();
            this.transactionsList = new List<Transaction>();
            this.AccountID = Guid.NewGuid().ToString();
            this.branch = "DefaultBranch";
            this.haveOverdraftRequest = false;
            this.approvedOverdraftRequest = false;
            this.overDraftRequestAmount = 0;
        }

        //MakeTransactionFunction
        public void MakeTransaction(float amount)
        {
            //check if there is enough money, and amount in transaction is'nt zero
            //Created a more simple if statement here
            //created other if statement for overdraft

            //Check amount != 0.0
            if (amount == 0.0f)
            {
                return;
            }

            //Deposit
            else if (amount > 0.0f) 
            {
                Transaction currentTransaction = new Transaction(amount);
                transactionsList.Add(currentTransaction);
                currentBalance += amount;
                balanceList.Add(currentBalance);
            }

            //withdraw
            else 
            {
                //overdraft
                if (approvedOverdraftRequest && haveOverdraftRequest && (currentBalance + amount >= (0.0f - overDraftRequestAmount))) 
                {
                    Transaction currentTransaction = new Transaction(amount);
                    transactionsList.Add(currentTransaction);
                    currentBalance += amount;
                    balanceList.Add(currentBalance);
                }

                //regular withdraw
                else if (currentBalance + amount >= 0.0f)
                {   
                    Transaction currentTransaction = new Transaction(amount);
                    transactionsList.Add(currentTransaction);
                    currentBalance += amount;
                    balanceList.Add(currentBalance);
                }
            }
        }

        //GetBankStatement
        public string GetBankStatement() 
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
                string amount = transactionsList[i].amount.ToString();
                string balance = balanceList[i].ToString();

                bankStatement = bankStatement + "\nDate: " + date + "|| TransactionType: " + transactionType + ": " + amount + "|| Balance: " + balance;
            }
            return bankStatement;
        }

        //set branch
        public void SetBranch(string branch)
        {
            this.branch = branch;
        }

        // Request overdraft
        public void RequestOverdraft(float amount)
        {
            this.overDraftRequestAmount = amount;
            this.haveOverdraftRequest = true;
        }

        //Approve overdraft request
        public void ApproveOverdraftRequest()
        {
            this.approvedOverdraftRequest = true;
        }

    }

    //CurrentAccount, almost identical to bankAccount, just one property differ
    public class CurrentAccount : BankAccount 
    {
        public string accountType { get; private set; }

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
