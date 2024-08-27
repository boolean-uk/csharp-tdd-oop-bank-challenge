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
        internal Controller(Model.Model model, View.View view)
        {
            this.model = model;
            this.view = view;
        }

        internal bool createPerson(bool isCustomer)
        {
            // all view stuff is just for looks and prints since we do not actually run a interactable view
            model.createPerson(isCustomer, view.createPerson(isCustomer));
            return true;
        }

        internal List<Customer> GetCustomers() { return model.getCustomers(); }

        internal bool createBankAccount(Customer customer, Enum branch)
        {
            view.createBankAccount(customer);
            return model.createBankAccount(customer, branch);
        }

        internal BankAccount getBankAccount(int customerID)
        {
            BankAccount bankAccount = model.getBankAccount(customerID);

            if (bankAccount == null)
            {
                view.doesNotExistWarning();
            }
            return bankAccount;
        }

        internal bool depositMoneyIntoTransactionalAccount(float amount, int customerID)
        {
            view.depositingMoneyToAccount(amount);
            return model.depositMoneyIntoTransactionalAccount(amount, customerID);
        }

        internal bool depositMoneyIntoSavingsAccount(float amount, int customerID)
        {
            view.depositingMoneyToAccount(amount);
            return model.depositMoneyIntoSavingsAccount(amount, customerID);
        }

        internal bool withdrawMoneyFromTransactionalAccount(float amount, int customerID)
        {
            view.withdrawingMoneyFromAccount(amount);
            return model.withdrawMoneyFromTransactionalAccount(amount, customerID);
        }
        internal bool withdrawMoneyFromSavingsAccount(float amount, int customerID)
        {
            view.withdrawingMoneyFromAccount(amount);
            return model.withdrawMoneyFromSavingsAccount(amount,customerID);
        }

        internal void printBankStatements(int customerID)
        {
            view.printBankStatements(model.getBankAccount(customerID).getBankStatemets());
        }

        internal bool requestOverdraft(int customerID, float amount, string reason) 
        { 
            view.requestOverdraft(amount);
            return model.requestOverdraft(customerID, amount, reason);
        }

        internal List<OverdraftRequest> getOverdraftRequests()
        {
            view.printOverdraftRequests(model.getOverdraftRequests());
            return model.getOverdraftRequests();
        }

        internal void approveOverdraftRequest(OverdraftRequest overdraftRequest)
        {
            model.approveOverdraftRequest(overdraftRequest);
        }

    }
}
