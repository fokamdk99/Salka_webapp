using Salka.WebApp.Client.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorClient
{
    public class EquipmentService : IHttpService
    {
        private readonly HttpClient httpClient;
        private readonly IController controller;
        public EquipmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public string GetBaseUrl()
        {
            return httpClient.BaseAddress.ToString();
        }

        public async Task<List<EquipmentDto>> GetAllEquipment()
        {
            //return await httpClient.GetFromJsonAsync<List<EquipmentDto>>("https://localhost:6001/Equipment");
            return await httpClient.GetFromJsonAsync<List<EquipmentDto>>("https://localhost:9001/Equipment");
        }

        public async Task GetAllEquipmentAsync()
        {
            await controller.GetAllEquipmentAsync();
        }
    }
}
