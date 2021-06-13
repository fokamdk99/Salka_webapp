using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Schedule.Model.Data2
{
    public partial class Schedule
    {
        public Schedule()
        {
            Reservationdates = new HashSet<Reservationdate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reservationdate> Reservationdates { get; set; }
    }
}
