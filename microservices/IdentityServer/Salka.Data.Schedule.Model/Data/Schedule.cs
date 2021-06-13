using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Schedules.Model.Data
{
    public partial class Schedule : BaseEntity
    {
        public Schedule()
        {
            ReservationDates = new HashSet<ReservationDate>();
        }

        public string Name { get; set; }

        public virtual ICollection<ReservationDate> ReservationDates { get; set; }
    }
}
