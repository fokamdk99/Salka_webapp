using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var apiClient = await GetHttpClient();
            var response = await apiClient.GetAsync("https://localhost:10001/Equipment");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
                //Console.WriteLine(content);
            }

            response = await apiClient.GetAsync("https://localhost:10001/Schedule/reservationmodels");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
                //Console.WriteLine(content);
            }

            response = await apiClient.GetAsync("https://localhost:10001/Client");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
                //Console.WriteLine(content);
            }

        }

        public static async Task<HttpClient> GetHttpClient()
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(
                new DiscoveryDocumentRequest
                {
                    Address = "https://localhost:5001",
                    Policy =
                    {
                        ValidateIssuerName = false
                    },
                });
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return null;
            }
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,

                ClientId = "client",
                ClientSecret = "secret",
                Scope = "api1"
            });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }

            Console.WriteLine(tokenResponse.Json);

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);
            return apiClient;
        }

        public async Task Test(HttpClient apiClient)
        {
            var response = await apiClient.GetAsync("https://localhost:7001/identity/test");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(JArray.Parse(content));
                Console.WriteLine(content);
            }

            response = await apiClient.GetAsync("https://localhost:8001/identity/test");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(JArray.Parse(content));
                Console.WriteLine(content);
            }

            response = await apiClient.GetAsync("https://localhost:9001/identity/test");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(JArray.Parse(content));
                Console.WriteLine(content);
            }

            response = await apiClient.GetAsync("https://localhost:10001/identity/test");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(JArray.Parse(content));
                Console.WriteLine(content);
            }
        }
    }
}
