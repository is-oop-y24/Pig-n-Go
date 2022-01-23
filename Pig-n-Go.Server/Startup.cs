using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Pig_n_Go.BLL.Services;
using Pig_n_Go.BLL.Services.Tools;
using Pig_n_Go.DAL.DatabaseContexts;
using Pig_n_Go.DAL.Repositories;
using Pig_n_Go.Mappers.Order;

namespace Pig_n_Go
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(
                    options =>
                    {
                        options.SerializerSettings.Formatting = Formatting.Indented;
                    });

            services.AddDbContext<TaxiDbContext>(
                options =>
                {
                    options.UseSqlite("Filename=TaxiDatabase.db");
                });

            var mapperConfig = new MapperConfiguration(
                mc =>
                {
                    mc.AddProfile(new OrderMapper());
                    mc.AddProfile(new DriverMapper());
                    mc.AddProfile(new PassengerMapper());
                });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSwaggerGen(
                c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pig-n-Go.Server", Version = "v1" });
                });

            services.AddScoped<IDriverRepositoryAsync, DbDriverRepositoryAsync>();
            services.AddScoped<IPassengerRepositoryAsync, DbPassengerRepositoryAsync>();
            services.AddScoped<IOrderRepositoryAsync, DbOrderRepositoryAsync>();

            services.AddScoped<IPassengerServiceAsync, PassengerServiceAsync>();
            services.AddScoped<IDriverServiceAsync, DriverServiceAsync>();
            services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();

            services.AddScoped<IDistanceCalculator, NativeDistanceCalculator>();
            services.AddScoped<IDriverDistanceLimit, DriverDistanceLimit>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Program> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pig-n-Go.Server v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                logger.LogInformation($"Processing request: {context.Request.Path}{context.Request.QueryString}");
                await next.Invoke();
            });

            app.UseCors(
                policy =>
                {
                    policy.WithOrigins("http://localhost:6000", "https://localhost:6001")
                          .AllowAnyMethod()
                          .WithHeaders(HeaderNames.ContentType);
                });

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                logger.LogError(exception.Message);
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
        }
    }
}
