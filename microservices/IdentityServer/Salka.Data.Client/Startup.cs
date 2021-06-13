using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Salka.Data.Clients.Logic.Interfaces;
using Salka.Data.Clients.Model.Data;
using Salka.Data.Clients.Model.Interfaces;
using Salka.Data.Clients.Rest.Logic.Services;
using Salka.Data.Clients.Rest.Model.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.Data.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<salkadbclientContext>(c =>
            c.UseMySQL(Configuration.GetConnectionString("salkadb")));
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IClientRepository, ClientsRepository>();
            //services.AddScoped<IRecordingStudioRepository, RecordingStudioRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
