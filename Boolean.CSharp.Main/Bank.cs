using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class Bank

    {
        CurrentAccount currentAccount = null!;
        SavingsAccount savingsAccount = null!;
        List<BankStatements> statements = new List<BankStatements>();
        Branches branch;


        public CurrentAccount CreateCurrentAccount(CurrentAccount currentaccount, Branches b)
        {
            this.currentAccount = currentaccount;
            branch = b;
            return this.currentAccount;
        }

        public SavingsAccount CreateSavingsAccount(SavingsAccount savingsaccount, Branches b)
        {
            this.savingsAccount = savingsaccount;
            branch = b;
            return this.savingsAccount;
        }

        public void Withdrawel(double amount, Account account)
        {
            if (account is CurrentAccount currentAccount) // Sjekker om account er av typen CurrentAccount
            {
                bool approval = RequestOverdraft(account.Balance - amount, account);
                if (approval)
                {
                    HandleWithdrawalForAccount(amount, currentAccount);
                }
            }
            else if (account is SavingsAccount savingsAccount) // Sjekker om account er av typen SavingsAccount
            {
             
                if (account.Balance - amount < 0)
                {

                    Console.WriteLine("you cannot make this withdrawel");
                }
                else
                {
                    HandleWithdrawalForAccount(amount, savingsAccount);
                }
                
            }
            else
            {
                throw new InvalidOperationException("This method only supports withdrawals for CurrentAccount and SavingsAccount types.");
            }
        }

        // Hjelpemetode for å håndtere uttak for en spesifikk kontotype
        private void HandleWithdrawalForAccount(double amount, Account account)
        {
            DateTime date = DateTime.Today;
            double newbalance = 0;

            // Beregn balansen for den spesifikke kontoen gjennom transaksjoner
            foreach (BankStatements bs in statements)
            {
                if (bs.Account == account) // Filtrer transaksjoner for denne kontoen
                {
                    if (bs.Type == "deposit")
                    {
                        newbalance += bs.Amount;
                    }
                    else if (bs.Type == "withdrawal")
                    {
                        newbalance -= bs.Amount;
                    }
                }
            }

            // Trekk ut beløpet fra balansen
            newbalance -= amount;

            // Opprett og legg til en ny transaksjon i listen for uttak
            BankStatements statement = new BankStatements(date.ToString("MM/dd/yyyy"), amount, "withdrawal", newbalance, account);
            statements.Add(statement);

            // Oppdater balansen for kontoen
            account.Balance = newbalance;
        }

        public int GetStatementsSize()
        {
            return statements.Count;
        }
        public void Deposit(int amount, Account account)
        {
            if (account is CurrentAccount currentAccount) // Sjekker om account er av typen CurrentAccount
            {
                HandleDepositForAccount(amount, currentAccount);
            }
            else if (account is SavingsAccount savingsAccount) // Sjekker om account er av typen SavingsAccount
            {
                HandleDepositForAccount(amount, savingsAccount);
            }
            else
            {
                throw new InvalidOperationException("This method only supports deposits for CurrentAccount and SavingsAccount types.");
            }
        }

        // Hjelpemetode for å håndtere innskudd for en spesifikk kontotype
        private void HandleDepositForAccount(int amount, Account account)
        {
            DateTime date = DateTime.Today;
            double newbalance = 0;

            // Beregn balansen for den spesifikke kontoen gjennom transaksjoner
            foreach (BankStatements bs in statements)
            {
                if (bs.Account == account) // Filtrer transaksjoner for denne kontoen
                {
                    if (bs.Type == "deposit")
                    {
                        newbalance += bs.Amount;
                    }
                    else if (bs.Type == "withdrawal")
                    {
                        newbalance -= bs.Amount;
                    }
                }
            }

            // Legg til beløpet som skal settes inn
            newbalance += amount;

            // Opprett og legg til en ny transaksjon i listen
            BankStatements statement = new BankStatements(date.ToString("MM/dd/yyyy"), amount, "deposit", newbalance, account);
            statements.Add(statement);

            // Oppdater balansen for kontoen
            account.Balance = newbalance;
        }



        public void ShowBankStatements()
        {
            Console.WriteLine("date      || credit  || debit  || balance");
            List<BankStatements> reversedStatements = statements.AsEnumerable().Reverse().ToList();
            ;
            foreach (BankStatements statement in reversedStatements)
            {
                Console.WriteLine(statement.ToString());
            }


        }
        public void manageOverdraft(bool newStautus, Account account)
        {
            if (account is CurrentAccount current)
            {
                current.Overdraftable = newStautus;

            }
            else
            {
                Console.WriteLine("only current account can be ovedraftable");
            }
        }


        public bool RequestOverdraft(double Overdraft, Account account)
        {
            if (account is CurrentAccount)
            {
                CurrentAccount cur = (CurrentAccount)account;
                if (cur.Overdraftable == true && cur.MaxOverdraft <= Overdraft)
                {
                    Console.WriteLine("you have gotten an overdraft!");
                    return true;


                }



            }
            else
            {

              
                Console.WriteLine("saving accounts can not have an overdraft!");
                return false;
            }

            Console.WriteLine("you can not have an overdraft!");
            return false;


        }

    

    }
}
