using Salka.Data.Schedules.Model.Data;
using Salka.Data.Schedules.Rest.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Rest.Logic.Mappers
{
    public static class Mappers
    {
        public static ReservationDto MapToReservationDto(this Reservation reservation)
        {
            if (reservation == null)
            {
                return null;
            }

            if (reservation.ReservationDates.Count() == 0 || reservation.ReservationType == null)
            {
                return new ReservationDto(reservation.IsPaymentCompleted, reservation.IsAcknowledged,
                reservation.IsRegular, reservation.TotalCost, reservation.Comment,
                reservation.NumberOfVocals, reservation.ClientId, reservation.ReservationTypeId,
                reservation.StaffId, null, null, reservation.Id);
            }

            return new ReservationDto(reservation.IsPaymentCompleted, reservation.IsAcknowledged,
                reservation.IsRegular, reservation.TotalCost, reservation.Comment,
                reservation.NumberOfVocals, reservation.ClientId, reservation.ReservationTypeId, 
                reservation.StaffId, reservation.ReservationDates.ElementAt(0).MapToReservationDateDto() ?? null, reservation.ReservationType.MapToReservationTypeDto() ?? null, reservation.Id);
        }

        public static Reservation MapToReservation(this ReservationDto reservationDto)
        {
            if (reservationDto == null)
            {
                return null;
            }

            return new Reservation(reservationDto.IsPaymentCompleted, reservationDto.IsAcknowledged,
                reservationDto.IsRegular, reservationDto.TotalCost, reservationDto.Comment,
                reservationDto.NumberOfVocals, reservationDto.ClientId, reservationDto.ReservationTypeId,
                reservationDto.StaffId);
        }

        public static ReservationDateDto MapToReservationDateDto(this ReservationDate reservationDate)
        {
            if (reservationDate == null)
            {
                return null;
            }

            return new ReservationDateDto(reservationDate.Date, reservationDate.Start,
                reservationDate.End, reservationDate.ScheduleId, reservationDate.ReservationId, reservationDate.Id);
        }

        public static ReservationDate MapToReservationDate(this ReservationDateDto reservationDateDto)
        {
            if (reservationDateDto == null)
            {
                return null;
            }

            return new ReservationDate(reservationDateDto.Date, reservationDateDto.Start,
                reservationDateDto.End, reservationDateDto.ScheduleId, reservationDateDto.ReservationId);
        }

        public static ReservationTypeDto MapToReservationTypeDto(this ReservationType reservationType)
        {
            if (reservationType == null)
            {
                return null;
            }

            return new ReservationTypeDto(reservationType.Type, reservationType.IsProducerRequired, reservationType.Id);
        }

        public static ReservationType MapToReservationType(this ReservationTypeDto  reservationTypeDto)
        {
            if (reservationTypeDto == null)
            {
                return null;
            }

            return new ReservationType(reservationTypeDto.Type, reservationTypeDto.IsProducerRequired);
        }
    }
}
