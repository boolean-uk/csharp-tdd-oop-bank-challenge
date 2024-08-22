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
            model.createPerson(view.createPerson(isCustomer));
            return true;
        }

        public List<Customer> GetCustomers() { return model.getCustomers(); }

        public void createBankAccount()
        {

        }
    }
}
