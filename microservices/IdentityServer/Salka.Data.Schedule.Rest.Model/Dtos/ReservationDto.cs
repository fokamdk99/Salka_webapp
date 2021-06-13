using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Rest.Model.Dtos
{
    public class ReservationDto
    {
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
        public ReservationDateDto ReservationDateDto {get; set; }
        public ReservationTypeDto ReservationTypeDto { get; set; }
        
        public ReservationDto()
        {

        }

        public ReservationDto(byte isPaymentCompleted, byte isAcknowledged, byte isRegular, float? totalCost, string comment, string numberOfVocals, int clientId, int reservationTypeId, int? staffId, ReservationDateDto reservationDateDto, ReservationTypeDto reservationTypeDto, int id) : this()
        {
            IsPaymentCompleted = isPaymentCompleted;
            IsAcknowledged = isAcknowledged;
            IsRegular = isRegular;
            TotalCost = totalCost;
            Comment = comment;
            NumberOfVocals = numberOfVocals;
            ClientId = clientId;
            ReservationTypeId = reservationTypeId;
            StaffId = staffId;
            ReservationDateDto = reservationDateDto;
            ReservationTypeDto = reservationTypeDto;
            Id = id;
        }
    }
}
