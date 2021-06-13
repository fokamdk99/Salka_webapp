

namespace Salka.WebApp.Client.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IEventDispatcher
    {
        void Dispatch(Action action);
    }
}
