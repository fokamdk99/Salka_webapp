using Salka.WebApp.Client.Controller;
using Salka.WebApp.Client.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorClient
{
    public class ClientService : IHttpService
    {
        private readonly HttpClient httpClient;
        private readonly IController controller;
        public ClientService(HttpClient httpClient, IController controller)
        {
            this.httpClient = httpClient;
            this.controller = controller;
        }
        public string GetBaseUrl()
        {
            return httpClient.BaseAddress.ToString();
        }

        public async Task<ClientModel> GetClientData()
        {
            var client = await httpClient.GetFromJsonAsync<ClientModel>("https://localhost:10001/Client");
            return client;
        }
    }
}
