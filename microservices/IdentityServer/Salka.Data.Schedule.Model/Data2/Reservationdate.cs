using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Schedule.Model.Data2
{
    public partial class Reservationdate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ScheduleId { get; set; }
        public int ReservationId { get; set; }

        public virtual Reservation Reservation { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
