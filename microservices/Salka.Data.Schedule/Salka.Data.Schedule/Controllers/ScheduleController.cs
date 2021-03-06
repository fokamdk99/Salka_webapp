using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Salka.Data.Schedules.Model.Data;
using Salka.Data.Schedules.Rest.Model.Dtos;
using Salka.Data.Schedules.Rest.Model.IServices;
using Salka.Data.Schedules.Rest.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Salka.Data.Schedules.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<List<ReservationDto>> GetAllReservationsInSchedule()
        {
            return await _scheduleService.GetAllReservationsInSchedule();
        }

        [HttpGet]
        [Route("reservationmodels")]
        public async Task<List<ReservationModelDto>> GetAllReservationModels()
        {
            var user = User.FindFirst("bandname");

            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://identity-server:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return null;
            }

            // request token
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = "client",
                ClientSecret = "secret",

                Scope = "weatherapi"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return null;
            }

            // call api
            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetFromJsonAsync<int>("https://identity-server:8001/Clients/get/clientid/Najarani");

            return await _scheduleService.GetReservationModels();
        }

        [HttpPost]
        public async Task PostNewReservationAsync([FromBody] ReservationModelDto reservationModelDto)
        {
            var user = User;
            ReservationDate reservationDate = new ReservationDate(reservationModelDto.Date, reservationModelDto.Start, reservationModelDto.End);
            Reservation reservation = new Reservation(0, 0, reservationModelDto.IsRegular, 10, reservationModelDto.Comment, reservationModelDto.NumberOfVocals);

            await _scheduleService.PostNewReservationAsync(reservationModelDto);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("reservationsbydate")]
        public async Task<List<ReservationModelDto>> GetReservationsByDateScope()
        {
            var reservations = await _scheduleService.GetReservationsByDateScope(DateTime.Now, DateTime.Now.AddDays(31));
            return reservations;
        }
    }
}
