using System;
using System.Collections.Generic;

#nullable disable

namespace Salka.Data.Schedules.Model.Data
{
    public partial class Reservation : BaseEntity
    {
        public Reservation()
        {
            ReservationDates = new HashSet<ReservationDate>();
        }

        public Reservation(byte isPaymentCompleted, byte isAcknowledged, byte isRegular, float? totalCost, string comment, string numberOfVocals) : this()
        {
            IsPaymentCompleted = isPaymentCompleted;
            IsAcknowledged = isAcknowledged;
            IsRegular = isRegular;
            TotalCost = totalCost;
            Comment = comment;
            NumberOfVocals = numberOfVocals;
        }


    public Reservation(byte isPaymentCompleted, byte isAcknowledged, byte isRegular, float? totalCost, string comment, string numberOfVocals, int clientId, int reservationTypeId, int? staffId) : this(isPaymentCompleted, isAcknowledged, isRegular, totalCost, comment, numberOfVocals)
        {
            
            ClientId = clientId;
            ReservationTypeId = reservationTypeId;
            StaffId = staffId;
        }

        public byte IsPaymentCompleted { get; set; }
        public byte IsAcknowledged { get; set; }
        public byte IsRegular { get; set; }
        public float? TotalCost { get; set; }
        public string Comment { get; set; }
        public string NumberOfVocals { get; set; }
        public int ClientId { get; set; }
        public int ReservationTypeId { get; set; }
        public int? StaffId { get; set; }

        public virtual ReservationType ReservationType { get; set; }
        public virtual ICollection<ReservationDate> ReservationDates { get; set; }
    }
}
