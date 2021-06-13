using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Schedules.Model.Data
{
    public partial class ReservationType : BaseEntity
    {
        public ReservationType()
        {
            Reservations = new HashSet<Reservation>();
        }

        public string Type { get; set; }
        public byte IsProducerRequired { get; set; }
        public ReservationType(string type, byte isProducerRequired) : this()
        {
                Type = type;
                IsProducerRequired = isProducerRequired;
        }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
