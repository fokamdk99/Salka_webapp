using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Salka.Data.Schedules.Logic.Interfaces;
using Salka.Data.Schedules.Model.Data;
using Salka.Data.Schedules.Model.Interfaces;
using Salka.Data.Schedules.Rest.Logic.Services;
using Salka.Data.Schedules.Rest.Model.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salka.Data.Schedules
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = "https://identity-server:5000";
                options.Audience = "weatherapi";
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    NameClaimType = "name"
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Salka.Data.Schedule", Version = "v1" });
            });

            services.AddDbContext<salkadbscheduleContext>(c =>
            c.UseMySQL(Configuration.GetConnectionString("salkadb")));
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));

            services.AddLogging(builder =>
                builder
                    .AddDebug()
                    .AddConsole()
                    .AddConfiguration(Configuration.GetSection("Logging"))
                    .SetMinimumLevel(LogLevel.Debug)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Salka.Data.Schedule v1"));
            }

            app.UseCors(config =>
            {
                config.AllowAnyOrigin();
                config.AllowAnyMethod();
                config.AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
