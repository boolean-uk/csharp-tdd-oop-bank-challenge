using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main
{
    public class AccountList
    {
        public List<Account> allaccounts = new List<Account>();

        public void AddNewAccount(Account newaccount)
        {
            Console.WriteLine("Creating new account....");
            Thread.Sleep(2000);
            if (!allaccounts.Exists(x => x.accountNumber == newaccount.accountNumber))
            {
                allaccounts.Add(newaccount);
                WriteAccountstoFile();
                Console.WriteLine("\nSuccess! Your account was registered with the Seguro Bank. Make sure to keep you account information safe!");
                Console.WriteLine("You will automatically return to you personal account page.");
                Thread.Sleep(2500);
            }
            else
            {
                Console.WriteLine("Account number already exists! Try again.");
                Thread.Sleep(2500);
            }

        }

        public void LoadExistingAccounts()
        {
            //clear the list of accounts, reload them from file
            allaccounts.Clear();
            // path for existing accountfile
            string mypath = @"C:\Csharp\csharp-tdd-oop-bank-challenge\accounts.txt";

            // read existing customers from file:
            string[] readText = File.ReadAllLines(mypath, Encoding.UTF8);
            foreach (string s in readText)
            {
                if (s.Length > 1)
                {
                    string[] AccountInfo = s.Split(',');
                    var accountNumber = AccountInfo[0];
                    var customerName = AccountInfo[1];
                    var startBalance = AccountInfo[2];
                    var accountType = AccountInfo[3];
                    var allowOverdraft = AccountInfo[4];

                    //Convert startBalance to float:
                    float.TryParse(startBalance, out float startBalanceFloat);

                    //Convert overdraft to float:
                    float.TryParse(allowOverdraft, out float allowOverdraftFloat);

                    Account account = new Account(accountNumber, customerName, startBalanceFloat, accountType);

                    //Add existing account to accountlist:
                    allaccounts.Add(account);

                    //Add overdraft:
                    account.allowOverdraft = allowOverdraftFloat;

                    //Add list of transactions:
                    var transactions = AccountInfo[5];
                    string[] transactions_split = transactions.Split("*");
                    foreach (string t in transactions_split)
                    {
                        if ( t.Length > 1)
                        {
                            string[] transaction = t.Split("&");
                            string date = transaction[0].Trim();
                            string amount = transaction[1].Trim();
                            float.TryParse(amount, out float amountFloat);
                            DateTime.TryParse(date, out DateTime dateDT);
                            account.transactions.Add(new Transaction(amountFloat, dateDT));
                        }

                    }
                }
            }
        }

        public void WriteAccountstoFile()
        {
            //write the most current list of all acounts to file (over-writing file)
            string mypath = @"C:\Csharp\csharp-tdd-oop-bank-challenge\accounts.txt";
            File.WriteAllText(mypath, "-");
            //string newLine;
            // for each account in the accountlist
            foreach (Account account in allaccounts)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Transaction t in account.transactions)
                {
                    if (t.transactionAmount != 0) 
                    { 
                        sb.Append(t.transactionDate + "&" + t.transactionAmount + "*"); 
                    }

                }
                string transactionsString = sb.ToString();
                string newLine = '\n' + account.accountNumber + ',' + account.customerName + ',' + account.startBalance + ',' + account.accountType + ',' + account.allowOverdraft + ',' + transactionsString;
                //newLine.ToString();
                //string createText = '\n' + account.accountNumber + ',' + account.customerName + ',' + account.startBalance + ',' + account.accountType + ',' + account.allowOverdraft + ',' + transactionsString;
                //File.WriteAllText(mypath, createText, Encoding.UTF8);

                //Console.WriteLine(newLine);

                File.AppendAllText(mypath, newLine, Encoding.UTF8);
            }
        }

        public void ViewCustomerAccounts(string ProvidedCustomer)
        {
            StringBuilder thisCustAccounts = new StringBuilder();
            foreach (Account account in allaccounts)
            {
                if (account.customerName == ProvidedCustomer)
                {
                    thisCustAccounts.Append("\nAccountnumber: " + account.accountNumber + ", Type: " + account.accountType);
                }
            }
            Console.WriteLine(thisCustAccounts.ToString());
        }

        public bool CustomerHasAnyAccount(string ProvidedCustomer)
        {
            if (allaccounts.Exists(x => x.customerName == ProvidedCustomer))
            { return true; }
            else { return false; }
        }

        public bool CustomerHasCheckingAccount(string ProvidedCustomer)
        {
            if (allaccounts.Exists(x => x.customerName == ProvidedCustomer && x.accountType == "checking"))
            { return true; }
            else { return false; }
        }

        public bool CustomerHasSavingsAccount(string ProvidedCustomer)
        {
            if (allaccounts.Exists(x => x.customerName == ProvidedCustomer && x.accountType == "savings"))
            { return true; }
            else { return false; }
        }

        public bool AccessCheckingAccount(string ProvidedCustomer)
        {
            if (CustomerHasCheckingAccount(ProvidedCustomer) == true)
            {
                var checkingAccount = allaccounts.Where(x => x.customerName == ProvidedCustomer && x.accountType == "checking").First();
                string checkingAccountNr = checkingAccount.accountNumber.ToString();
                var currentbalance = checkingAccount.GetBalance();
                Console.WriteLine("Checking Account: " + checkingAccountNr);
                Console.WriteLine("Balance: " + currentbalance);
                return true;
            }
            else
            {
                Console.WriteLine("You have no checking account.");
                Thread.Sleep(2000);
                return false;
            }
        }

        public string GetCheckingAccountNr(string ProvidedCustomer)
        {
            if (CustomerHasCheckingAccount(ProvidedCustomer) == true)
            {
                var checkingAccount = allaccounts.Where(x => x.customerName == ProvidedCustomer && x.accountType == "checking").First();
                string checkingAccountNr = checkingAccount.accountNumber.ToString();
                return checkingAccountNr;
            }
            else
            {
                return "";
            }
        }

        public bool AccessSavingsAccount(string ProvidedCustomer)
        {
            if (CustomerHasSavingsAccount(ProvidedCustomer) == true)
            {
                var savingsAccount = allaccounts.Where(x => x.customerName == ProvidedCustomer && x.accountType == "savings").First();
                string savingsAccountNr = savingsAccount.accountNumber.ToString();
                var currentbalance = savingsAccount.GetBalance();
                Console.WriteLine("Savings Account: " + savingsAccountNr);
                Console.WriteLine("Balance: " + currentbalance);
                return true;
            }
            else
            {
                Console.WriteLine("You have no savings account.");
                Thread.Sleep(2000);
                return false;
            }
        }

        public string GetSavingsAccountNr(string ProvidedCustomer)
        {
            if (CustomerHasSavingsAccount(ProvidedCustomer) == true)
            {
                var savingsAccount = allaccounts.Where(x => x.customerName == ProvidedCustomer && x.accountType == "savings").First();
                string savingsAccountNr = savingsAccount.accountNumber.ToString();
                return savingsAccountNr;
            }
            else
            {
                return "";
            }
        }

        public void ViewTransactionHistory(string accountnumber)
        {
            StringBuilder sb = new StringBuilder();
            var currentaccount = allaccounts.Where(x => x.accountNumber == accountnumber).First();
            foreach (Transaction t in currentaccount.transactions)
            {
                if (t.transactionAmount != 0)
                {
                    sb.AppendLine("Date:" + t.transactionDate + ", Amount: "+ t.transactionAmount);
                }
            }
            Console.WriteLine("Transaction History:");
            if (sb.Length >0) { Console.WriteLine(sb.ToString()); }
            else { Console.WriteLine("No transactions available");  }
            
            Thread.Sleep(2000);
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        public void DepositAmount(string accountnumber, string amount)
        {
            DateTime current_date = DateTime.Now;
            var currentaccount = allaccounts.Where(x => x.accountNumber == accountnumber).First();
            float.TryParse(amount, out float AmountFloat);
            currentaccount.transactions.Add(new Transaction(AmountFloat, current_date));
            Console.WriteLine("Success!");
            Thread.Sleep(2000);
            WriteAccountstoFile();
        }

        public void WithdrawAmount(string accountnumber, string amount)
        {
            var currentaccount = allaccounts.Where(x => x.accountNumber == accountnumber).First();
            float.TryParse(amount, out float AmountFloat);
            // store as negative:
            float negative_amount = AmountFloat - (2 * AmountFloat);
            float expectedNewBalance = currentaccount.GetBalance() - AmountFloat;
            DateTime current_date = DateTime.Now;
            if (expectedNewBalance < 0 && currentaccount.allowOverdraft == 0)
            {
                Console.WriteLine("No overdraft allowed.");
                Thread.Sleep(2000);
            }
            else if (expectedNewBalance < currentaccount.allowOverdraft)
            {
                Console.WriteLine("This transaction exceeds your overdraft limit.");
                Thread.Sleep(2000);
            }
            else
            {
                currentaccount.transactions.Add(new Transaction(negative_amount, current_date));
                Console.WriteLine("Success!");
                Thread.Sleep(2000);
                WriteAccountstoFile();
            }

        }

        public void ActivateOverdraft(string accountnumber, string newfloorstring, string accountType)
        {
            var currentaccount = allaccounts.Where(x => x.accountNumber == accountnumber).First();
            float.TryParse(newfloorstring, out float newfloor);
            if (accountType == "savings")
            {
                Console.WriteLine("Overdraft on a savings account is not allowed.");
                Thread.Sleep(2000);
            }
            else if (accountType == "checking" && -1001 < newfloor)
            {
                currentaccount.allowOverdraft = newfloor;
                Console.WriteLine("Succes! New overdraft amount: " + currentaccount.allowOverdraft);
                WriteAccountstoFile();
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Invalid action.");
                Thread.Sleep(2500);
            }
        }
    }
}
