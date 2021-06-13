using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Rest.Model.Dtos
{
    public class ReservationDateDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int ScheduleId { get; set; }
        public int ReservationId { get; set; }

        public ReservationDateDto()
        {

        }

        public ReservationDateDto(DateTime date, DateTime start, DateTime end, int scheduleId, int reservationId, int id)
        {
            Date = date;
            Start = start;
            End = end;
            ScheduleId = scheduleId;
            ReservationId = reservationId;
            Id = id;
        }
    }
}
