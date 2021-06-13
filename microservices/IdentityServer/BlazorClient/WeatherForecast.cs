using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorClient
{
    public class WeatherForecast : IHttpService
    {
        public readonly HttpClient httpClient;
        public WeatherForecast(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public string GetBaseUrl()
        {
            return httpClient.BaseAddress.ToString();
        }
    }
}
