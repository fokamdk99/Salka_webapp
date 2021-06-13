using Salka.Data.Schedules.Rest.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Rest.Model.IServices
{
    public interface IScheduleService
    {
        Task<List<ReservationDto>> GetAllReservationsInSchedule();
        Task PostNewReservationAsync(ReservationModelDto reservationModelDto);
        Task<ReservationDateDto> GetReservationDateByReservationId(ReservationDto reservationDto);
        Task<ReservationTypeDto> GetReservationTypeByReservationId(ReservationDto reservationDto);
        Task<List<ReservationModelDto>> GetReservationModels();
        Task<List<ReservationModelDto>> GetReservationsByDateScope(DateTime start, DateTime end);
    }
}
