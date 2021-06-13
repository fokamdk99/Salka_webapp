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
    public class ClientService : IClientService
    {
        private readonly UrlsConfig _urls;
        IHttpClientFactory _clientFactory;
        public ClientService(UrlsConfig urls, IHttpClientFactory clientFactory)
        {
            _urls = urls;
            _clientFactory = clientFactory;
        }

        public async Task<ClientModel> GetClientDataAsync(string bandName)
        {
            var urls = new UrlsConfig();
            var url = urls.clientOperations.GetClientDataAsync();
            var handler = new HttpClientAuthorizationDelegatingHandler(_clientFactory);
            var response = await handler.CallWebServiceAsync<ClientModel>(HttpMethod.Get, url, bandName);
            return response;
        }
    }
}
