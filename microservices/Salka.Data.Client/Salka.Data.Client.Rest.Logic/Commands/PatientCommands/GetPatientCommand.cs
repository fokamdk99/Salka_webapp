using Salka.Data.Clients.Rest.Model.ICommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Salka.Data.Clients.Rest.Logic.Commands.PatientCommands
{
    public class GetPatientCommand : ICommand
    {
        public string dbSet { get; set; }
    }
}
