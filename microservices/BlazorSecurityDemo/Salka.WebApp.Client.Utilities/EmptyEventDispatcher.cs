

namespace Salka.WebApp.Client.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class EmptyEventDispatcher : IEventDispatcher
    {
        #region IEventDispatcher

        public void Dispatch(Action eventAction)
        {
        }
        #endregion
    }
}
