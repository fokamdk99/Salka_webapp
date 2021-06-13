using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Schedules.Model.Data
{
    public partial class ReservationDate : BaseEntity
    {
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ScheduleId { get; set; }
        public int ReservationId { get; set; }

        public ReservationDate()
        {

        }

        public ReservationDate(DateTime date, DateTime start, DateTime end) : this()
        {
            Date = date;
            Start = start;
            End = end;
        }

        public ReservationDate(DateTime date, DateTime start, DateTime end, int scheduleId, int reservationId) : this(date, start, end)
        {
            
            ScheduleId = scheduleId;
            ReservationId = reservationId;
        }

        public virtual Reservation Reservation { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
