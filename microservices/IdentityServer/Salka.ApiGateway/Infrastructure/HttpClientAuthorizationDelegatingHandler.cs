using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Salka.ApiGateway.Infrastructure
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        private readonly IHttpClientFactory _clientFactory;
        public HttpClientAuthorizationDelegatingHandler(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<TokenResponse> GetAccessToken()
        {
            var client = this._clientFactory.CreateClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://identity-server:5001");
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
            return tokenResponse;
        }

        public async Task<T> CallWebServiceAsync<T>(HttpMethod httpMethod, string webServiceUri)
        {
            //TokenResponse tokenResponse = await GetAccessToken();

            var apiClient = _clientFactory.CreateClient();
            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            string jsonResponseContent = await this.CallWebService(httpMethod, webServiceUri, apiClient);

            T result = this.ConvertJson<T>(jsonResponseContent);
            return result;
        }

        public async Task<string> CallWebService(HttpMethod httpMethod, string callUri, HttpClient httpClient)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, callUri);
            httpRequestMessage.Headers.Add("Accept", "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            //httpResponseMessage.EnsureSuccessStatusCode();
            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return httpResponseContent;
        }

        public async Task<T> CallWebServiceAsync<T>(HttpMethod httpMethod, string webServiceUri, string payload)
        {
            //TokenResponse tokenResponse = await GetAccessToken();

            var apiClient = _clientFactory.CreateClient();
            //apiClient.SetBearerToken(tokenResponse.AccessToken);
            //var jsonString = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            string jsonResponseContent = await this.CallWebService(httpMethod, webServiceUri, apiClient, payload);

            T result = this.ConvertJson<T>(jsonResponseContent);
            return result;
        }

        public async Task<string> CallWebService(HttpMethod httpMethod, string callUri, HttpClient httpClient, string payload)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, callUri);
            httpRequestMessage.Headers.Add("Accept", "application/json");
            httpRequestMessage.Headers.Add("bandname", payload);
            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            //httpResponseMessage.EnsureSuccessStatusCode();
            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            return httpResponseContent;
        }

        public async Task PostWebServiceAsync<T>(HttpMethod httpMethod, string webServiceUri, T payload)
        {
            //TokenResponse tokenResponse = await GetAccessToken();

            var apiClient = _clientFactory.CreateClient();
            //apiClient.SetBearerToken(tokenResponse.AccessToken);

            await this.PostWebService<T>(httpMethod, webServiceUri, apiClient, payload);
        }

        public async Task PostWebService<T>(HttpMethod httpMethod, string callUri, HttpClient httpClient, T payload)
        {
            var jsonString = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(callUri, jsonString);
            //httpResponseMessage.EnsureSuccessStatusCode();
        }

        private T ConvertJson<T>(string json)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();

            jsonSerializerOptions.PropertyNameCaseInsensitive = true;

            return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);
        }
    }
}
