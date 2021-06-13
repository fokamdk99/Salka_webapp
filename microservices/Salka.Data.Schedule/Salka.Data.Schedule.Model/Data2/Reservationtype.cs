using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Schedule.Model.Data2
{
    public partial class Reservationtype
    {
        public Reservationtype()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public byte IsProducerRequired { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
