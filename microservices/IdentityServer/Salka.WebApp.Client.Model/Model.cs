

namespace Salka.WebApp.Client.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Salka.WebApp.Client.Utilities;
    public partial class Model : PropertyContainerBase, IModel
    {
        public Model(IEventDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
