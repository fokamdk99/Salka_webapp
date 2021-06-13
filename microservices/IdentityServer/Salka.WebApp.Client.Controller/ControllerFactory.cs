

namespace Salka.WebApp.Client.Controller
{
    using Salka.WebApp.Client.Model;
    using Salka.WebApp.Client.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public static class ControllerFactory
    {
        private static IController controller;

        public static IController GetController(IEventDispatcher dispatch)
        {
            if (controller == null)
            {
                IModel newModel = new Model(dispatch) as IModel;

                IController newController = new Controller(dispatch, newModel);

                controller = newController;
            }
            return controller;
        }
    }
}
