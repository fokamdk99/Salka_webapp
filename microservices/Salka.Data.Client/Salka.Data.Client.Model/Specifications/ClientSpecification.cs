using Ardalis.Specification;
using Salka.Data.Clients.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Clients.Model.Specifications
{
    public class ClientSpecification : Specification<Client>
    {
        public ClientSpecification(string bandname)
        {
            Query.Where(c => c.Bandname == bandname);
        }
    }
}
