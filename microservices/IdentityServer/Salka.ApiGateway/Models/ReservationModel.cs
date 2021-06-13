using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Models
{
    public class ReservationModel
    {
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public byte IsRegular { get; set; }
        public string Comment { get; set; }
        public string NumberOfVocals { get; set; }
        public string ReservationType { get; set; }
    }
}
