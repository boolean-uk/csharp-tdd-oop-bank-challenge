using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main
{
    public class App
    {
        private Model.Model model = new Model.Model();
        private View.View view = new View.View();
        private Controller.Controller controller { get;  }
        public App() { 
            this.controller = new Controller.Controller(model, view);
        }
        public void instanciate() {

        }

        //public Controller.Controller getController() { return controller; }
    }
}
