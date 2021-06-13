using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Rest.Model.Dtos
{
    public class ReservationModelDto
    {
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public byte IsRegular { get; set; }
        public string Comment { get; set; }
        public string NumberOfVocals { get; set; }
        public string ReservationType { get; set; }

        public ReservationModelDto()
        {

        }

        public ReservationModelDto(DateTime date, DateTime start, DateTime end, byte isRegular, string comment, string numberOfVocals, string reservationType)
        {
            Date = date;
            Start = start;
            End = end;
            IsRegular = isRegular;
            Comment = comment;
            NumberOfVocals = numberOfVocals;
            ReservationType = reservationType;
        }
    }
}
