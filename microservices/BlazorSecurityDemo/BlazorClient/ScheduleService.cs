using Salka.WebApp.Client.Controller;
using Salka.WebApp.Client.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorClient
{
    public class ScheduleService : IHttpService
    {
        private readonly HttpClient httpClient;
        private readonly IController controller;
        public ScheduleService(HttpClient httpClient, IController controller)
        {
            this.httpClient = httpClient;
            this.controller = controller;
        }
        public string GetBaseUrl()
        {
            return httpClient.BaseAddress.ToString();
        }

        public async Task<List<ReservationModel>> GetAllReservations()
        {
            var reservations = await httpClient.GetFromJsonAsync<List<ReservationModel>>("https://localhost:9001/Schedule/reservationmodels");
            return reservations;
        }

        public async Task PostNewReservationAsync(ReservationModel reservationModel)
        {
            var jsonString = new StringContent(JsonSerializer.Serialize(reservationModel), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("https://localhost:9001/Schedule/", jsonString);
        }

        public async Task<List<ReservationModel>> GetReservationsByDateScope()
        {
            var reservations = await httpClient.GetFromJsonAsync<List<ReservationModel>>("https://localhost:9001/Schedule/reservationsbydate");
            return reservations;
        }
    }
}
