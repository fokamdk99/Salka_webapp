using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Schedule.Model.Data2
{
    public partial class Reservation
    {
        public Reservation()
        {
            Reservationdates = new HashSet<Reservationdate>();
        }

        public int Id { get; set; }
        public byte IsPaymentCompleted { get; set; }
        public byte IsAcknowledged { get; set; }
        public byte IsRegular { get; set; }
        public float? TotalCost { get; set; }
        public string Comment { get; set; }
        public string NumberOfVocals { get; set; }
        public int ClientId { get; set; }
        public int ReservationTypeId { get; set; }
        public int? StaffId { get; set; }

        public virtual Reservationtype ReservationType { get; set; }
        public virtual ICollection<Reservationdate> Reservationdates { get; set; }
    }
}
