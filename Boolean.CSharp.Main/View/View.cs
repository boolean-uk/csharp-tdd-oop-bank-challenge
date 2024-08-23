using Boolean.CSharp.Main.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.View
{
    internal class View
    {
        internal void createBankAccount(Customer customer)
        {
            Console.WriteLine($"Bank account for {customer.FirstName} {customer.LastName} is being created!");
        }

        internal IPerson createPerson(bool isCustomer)
        {
            if (isCustomer)
            {
                Console.WriteLine("A customer is being created!");
                string FirstName = "Test";
                string LastName = "Testsson";
                string PhoneNumber = "1234567890";
                float CashOnHand = 1000.0f;
                return new Customer(FirstName, LastName, PhoneNumber, CashOnHand);
            }
            return null; //for engineer creation later
        }

        internal void depositingMoneyToAccount(float amount)
        {
            Console.WriteLine($"Depositing {amount} into your account!");
        }

        internal void withdrawingMoneyFromAccount(float amount)
        {
            Console.WriteLine($"Withdrawing {amount} from your account!");
        }

        internal void doesNotExistWarning()
        {
            Console.WriteLine("\n   Object does not exist!   \n");
        }

        internal void printBankStatements(List<BankStatement> bankStatements)
        {
            string formatString = "{0, -20} || {1, -21} || {2, -7} || {3, -7} || {4, -10} || {5, -10}";
            Console.WriteLine();
            Console.WriteLine(formatString, "Date", "account", "credit", "debit", "balance", "branch");

            bankStatements.ForEach(bankStatement =>
            {
                if (bankStatement.transactionalAccount() && bankStatement.branch() != null)
                {
                    if (bankStatement.withdraw())
                    {
                        Console.WriteLine(formatString, bankStatement.date(), "Transactional Account", bankStatement.transactionValue(), "", bankStatement.balanceAtTime(), bankStatement.branch().ToString());

                    }
                    else
                    {
                        Console.WriteLine(formatString, bankStatement.date(), "Transactional Account", "", bankStatement.transactionValue(), bankStatement.balanceAtTime(), bankStatement.branch().ToString());

                    }
                }
                else if (bankStatement.transactionalAccount() && bankStatement.branch() == null)
                {
                    if (bankStatement.withdraw())
                    {
                        Console.WriteLine(formatString, bankStatement.date(), "Transactional Account", bankStatement.transactionValue(), "", bankStatement.balanceAtTime(), "NaN");

                    }
                    else
                    {
                        Console.WriteLine(formatString, bankStatement.date(), "Transactional Account", "", bankStatement.transactionValue(), bankStatement.balanceAtTime(), "NaN");

                    }
                }
                else if (!bankStatement.transactionalAccount() && bankStatement.branch() != null)
                {
                    if (bankStatement.withdraw())
                    {
                        Console.WriteLine(formatString, bankStatement.date(), "Savings Account", bankStatement.transactionValue(), "", bankStatement.balanceAtTime(), bankStatement.branch().ToString());


                    }
                    else
                    {
                        Console.WriteLine(formatString, bankStatement.date(), "Savings Account", "", bankStatement.transactionValue(), bankStatement.balanceAtTime(), bankStatement.branch().ToString());

                    }
                }
                else
                {
                    if (bankStatement.withdraw())
                    {
                        Console.WriteLine(formatString, bankStatement.date(), "Savings Account", bankStatement.transactionValue(), "", bankStatement.balanceAtTime(), "NaN");


                    }
                    else
                    {
                        Console.WriteLine(formatString, bankStatement.date(), "Savings Account", "", bankStatement.transactionValue(), bankStatement.balanceAtTime(), "NaN");

                    }
                }

            });
        }
    }
}
