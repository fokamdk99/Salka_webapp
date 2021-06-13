using Salka.ApiGateway.Config;
using Salka.ApiGateway.Infrastructure;
using Salka.ApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly UrlsConfig _urls;
        IHttpClientFactory _clientFactory;
        public EquipmentService(UrlsConfig urls, IHttpClientFactory clientFactory)
        {
            _urls = urls;
            _clientFactory = clientFactory;
        }
        public async Task<List<EquipmentDto>> GetAllEquipmentAsync()
        {
            var urls = new UrlsConfig();
            var url = urls.equipmentOperations.GetAllEquipment();
            var handler = new HttpClientAuthorizationDelegatingHandler(_clientFactory);
            var response = await handler.CallWebServiceAsync<List<EquipmentDto>>(HttpMethod.Get, url);
            return response;
        }
    }
}
