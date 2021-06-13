using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salka.ApiGateway.Models;
using Salka.ApiGateway.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        
        [Route("reservationmodels")]
        public async Task<List<ReservationModel>> GetAllReservations()
        {

            return await _scheduleService.GetAllReservations();
        }

        [HttpPost]
        public async Task PostNewReservationAsync([FromBody] ReservationModelDto reservationModelDto)
        {
            await _scheduleService.PostNewReservationAsync(reservationModelDto);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("reservationsbydate")]
        public async Task<List<ReservationModel>> GetReservationsByDateScope()
        {
            return await _scheduleService.GetReservationsByDateScope();
        }
    }
}
