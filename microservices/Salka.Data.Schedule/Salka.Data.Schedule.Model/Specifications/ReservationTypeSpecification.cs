using Ardalis.Specification;
using Salka.Data.Schedules.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Model.Specifications
{
    public class ReservationTypeSpecification : Specification<ReservationType>
    {
        public ReservationTypeSpecification(int reservationTypeId)
        {
            Query.Where(e => e.Id == reservationTypeId);
        }
    }
}
