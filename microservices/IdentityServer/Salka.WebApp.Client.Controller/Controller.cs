

namespace Salka.WebApp.Client.Controller
{
    using Salka.WebApp.Client.Model;
    using Salka.WebApp.Client.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public partial class Controller : PropertyContainerBase, IController
    {
        public IModel Model { get; private set; }
        public Controller( IEventDispatcher dispatcher, IModel model) : base(dispatcher)
        {
            this.Model = model;
        }
    }
}
