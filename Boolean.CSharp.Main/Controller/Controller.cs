using Boolean.CSharp.Main.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Boolean.CSharp.Test")]

namespace Boolean.CSharp.Main.Controller
{
    internal class Controller
    {
        private Model.Model model;
        private View.View view;
        public Controller(Model.Model model, View.View view)
        {
            this.model = model;
            this.view = view;
        }

        public bool createPerson(bool isCustomer)
        {
            // all view stuff is just for looks and prints since we do not actually run a interactable view
            model.createPerson(isCustomer, view.createPerson(isCustomer));
            return true;
        }

        public List<Customer> GetCustomers() { return model.getCustomers(); }

        public bool createBankAccount(Customer customer)
        {
            view.createBankAccount(customer);
            return model.createBankAccount(customer);
        }

        public BankAccount getBankAccount(int customerID)
        {
            BankAccount bankAccount = model.getBankAccount(customerID);

            if (bankAccount == null)
            {
                view.doesNotExistWarning();
            }
            return bankAccount;
        }

        public bool depositMoneyIntoTransactionalAccount(float amount, int customerID)
        {
            view.depositingMoneyToAccount(amount);
            return model.depositMoneyIntoTransactionalAccount(amount, customerID);
        }

        public bool depositMoneyIntoSavingsAccount(float amount, int customerID)
        {
            view.depositingMoneyToAccount(amount);
            return model.depositMoneyIntoSavingsAccount(amount, customerID);
        }

        public bool withdrawMoneyFromTransactionalAccount(float amount, int customerID)
        {
            view.withdrawingMoneyFromAccount(amount);
            return model.withdrawMoneyFromTransactionalAccount(amount, customerID);
        }
        public bool withdrawMoneyFromSavingsAccount(float amount, int customerID)
        {
            view.withdrawingMoneyFromAccount(amount);
            return model.withdrawMoneyFromSavingsAccount(amount,customerID);
        }

        public void printBankStatements(int customerID)
        {
            view.printBankStatements(model.getBankAccount(customerID).getBankStatemets());
        }


    }
}
