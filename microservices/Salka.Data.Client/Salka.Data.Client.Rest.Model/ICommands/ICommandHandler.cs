using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Rest.Model.ICommands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        void Handle(T command);
    }
}
