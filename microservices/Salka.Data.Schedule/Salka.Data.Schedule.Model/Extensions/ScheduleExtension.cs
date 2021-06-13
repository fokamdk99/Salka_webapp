using Microsoft.EntityFrameworkCore;
using Salka.Data.Schedules.Model.Data;
using Salka.Data.Schedules.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Model.Extensions
{
    public static class ScheduleExtension
    {
        public static async Task<ReservationDate> ReservationDateByReservationId(this IAsyncRepository<Reservation> asyncRepository, int reservationId)
        {
            using (var db = new salkadbscheduleContext())
            {
                var reservationdate = await db.Reservationdates.Where(rd => rd.ReservationId == reservationId).SingleAsync();
                return reservationdate;
            }
        }

        public static async Task<ReservationType> ReservationTypeByReservationId(this IAsyncRepository<Reservation> asyncRepository, int reservationTypeId)
        {
            using (var db = new salkadbscheduleContext())
            {
                var reservationtype = await db.Reservationtypes.Where(rd => rd.Id == reservationTypeId).SingleAsync();
                return reservationtype;
            }
        }

        public static async Task PostNewReservationAsync(this IAsyncRepository<Reservation> asyncRepository, ReservationDate reservationDate, Reservation reservation, string reservationType)
        {
            using (var db = new salkadbscheduleContext())
            {
                var schedule = await db.Schedules.Where(s => s.Name == "Rexast_terminarz").SingleAsync();
                
                var reservationTypeEntity = await db.Reservationtypes.Where(rt => rt.Id == int.Parse(reservationType)).SingleAsync();
                
                reservation.ReservationTypeId = reservationTypeEntity.Id;
                reservation.ClientId = 1;
                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();

                reservationTypeEntity.Reservations.Add(reservation);

                reservationDate.ScheduleId = schedule.Id;
                reservationDate.ReservationId = reservation.Id;
                db.Reservationdates.Add(reservationDate);
                await db.SaveChangesAsync();

                schedule.ReservationDates.Add(reservationDate);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<List<Reservation>> GetReservationsByDateScope(this IAsyncRepository<Reservation> asyncRepository, DateTime start, DateTime end)
        {
            using (var db = new salkadbscheduleContext())
            {
                var reservations = await db.Reservations.
                    Join(db.Reservationdates,
                    r => r.Id,
                    d => d.ReservationId,
                    (r, d) => new { 
                    r,
                    d.Date
                    }).Where(r => r.Date > start).Where(r => r.Date < end).Select( r => r.r).ToListAsync();
                //var reservations = await db.Reservations
                //    .Where(r => r.ReservationDates.ElementAt(0).Date > start)
                //   .Where(r => r.ReservationDates.ElementAt(0).Date < end).ToListAsync();
                return reservations;
            }
        }
    }
}
