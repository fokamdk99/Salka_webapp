using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Rest.Model.Dtos
{
    public class ReservationTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public byte IsProducerRequired { get; set; }

        public ReservationTypeDto()
        {

        }

        public ReservationTypeDto(string type, byte isProducerRequired, int id) : this()
        {
            Type = type;
            IsProducerRequired = isProducerRequired;
            Id = id;
        }
    }
}
