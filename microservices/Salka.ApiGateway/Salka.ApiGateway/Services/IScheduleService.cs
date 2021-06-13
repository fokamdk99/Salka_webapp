using Salka.ApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Services
{
    public interface IScheduleService
    {
        Task<List<ReservationModel>> GetAllReservations();
        Task PostNewReservationAsync(ReservationModelDto reservationModelDto);
        Task<List<ReservationModel>> GetReservationsByDateScope();
    }
}
