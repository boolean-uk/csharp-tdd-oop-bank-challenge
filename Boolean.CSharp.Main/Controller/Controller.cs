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
        Model.Model Model;
        View.View View;
        public Controller(Model.Model Model, View.View View)
        {
            this.Model = Model;
            this.View = View;
        }
    }
}
