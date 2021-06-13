using BlazorClient.Security;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Salka.WebApp.Client.Controller;
using Salka.WebApp.Client.Model;
using Salka.WebApp.Client.Utilities;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient<WeatherForecast>("api")
                .AddHttpMessageHandler(sp =>
                {
                    var handler = sp.GetService<AuthorizationMessageHandler>()
                        .ConfigureHandler(
                            authorizedUrls: new[] { "https://localhost:10002" },
                            scopes: new[] { "api1" });

                    return handler;
                });

            builder.Services.AddHttpClient<EquipmentService>("api2")
                .AddHttpMessageHandler(sp =>
                {
                    var handler = sp.GetService<AuthorizationMessageHandler>()
                        .ConfigureHandler(
                            authorizedUrls: new[] { "https://localhost:10001" },
                            scopes: new[] { "api1" });

                    return handler;
                });

            builder.Services.AddHttpClient<ScheduleService>("api3")
                .AddHttpMessageHandler(sp =>
                {
                    var handler = sp.GetService<AuthorizationMessageHandler>()
                        .ConfigureHandler(
                            authorizedUrls: new[] { "https://localhost:10001" },
                            scopes: new[] { "api1" });

                    return handler;
                });

            builder.Services.AddHttpClient<ClientService>("api4")
                .AddHttpMessageHandler(sp =>
                {
                    var handler = sp.GetService<AuthorizationMessageHandler>()
                        .ConfigureHandler(
                            authorizedUrls: new[] { "https://localhost:10001" },
                            scopes: new[] { "api1" });

                    return handler;
                });

            builder.Services.AddSingleton<IEventDispatcher, EmptyEventDispatcher>();
            builder.Services.AddSingleton<IModel, Model>();
            builder.Services.AddSingleton<IController, Controller>();


            //builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));
            //builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("api2"));

            builder.Services
                .AddOidcAuthentication(options =>
                {
                    builder.Configuration.Bind("oidc", options.ProviderOptions);
                    options.UserOptions.RoleClaim = "role";
                })
                .AddAccountClaimsPrincipalFactory<ArrayClaimsPrincipalFactory<RemoteUserAccount>>();

            await builder.Build().RunAsync();
        }
    }
}
